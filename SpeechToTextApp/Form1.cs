using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using NAudio.Wave;
using Vosk;
using System.IO;

namespace SpeechToTextApp
{
    public partial class Form1 : Form
    {
        private Model modelTr = null;
        private Model modelEn = null;
        private VoskRecognizer recognizer = null;
        private WaveInEvent waveIn = null;
        private bool tanimaCalisiyor = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbDiller.Items.Clear();
            cmbDiller.Items.Add("tr-TR - Türkçe");
            cmbDiller.Items.Add("en-US - English");
            cmbDiller.SelectedIndex = 0;
        }

        private void btnDilleriYukle_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Türkçe ve İngilizce modelleri yüklenmiş olmalı.\n\n" +
                            "Klasör yolu: bin\\Debug\\models\\vosk-model-small-tr-0.3\n" +
                            "ve bin\\Debug\\models\\vosk-model-small-en-us-0.15",
                            "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBaslatDurdur_Click(object sender, EventArgs e)
        {
            if (tanimaCalisiyor)
                Durdur();
            else
                Baslat();
        }

        private void Baslat()
        {
            if (cmbDiller.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir dil seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string selected = cmbDiller.SelectedItem.ToString();
                string appPath = Application.StartupPath;
                string modelsFolder = Path.Combine(appPath, "models");

                string trModelPath = Path.Combine(modelsFolder, "vosk-model-small-tr-0.3");
                string enModelPath = Path.Combine(modelsFolder, "vosk-model-small-en-us-0.15");

                if (selected.StartsWith("tr"))
                {
                    if (modelTr == null)
                    {
                        if (!Directory.Exists(trModelPath))
                        {
                            MessageBox.Show("Türkçe modeli bulunamadı: " + trModelPath,
                                "Model Eksik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        modelTr = new Model(trModelPath);
                    }
                    recognizer = new VoskRecognizer(modelTr, 16000.0f);
                }
                else
                {
                    if (modelEn == null)
                    {
                        if (!Directory.Exists(enModelPath))
                        {
                            MessageBox.Show("İngilizce modeli bulunamadı: " + enModelPath,
                                "Model Eksik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        modelEn = new Model(enModelPath);
                    }
                    recognizer = new VoskRecognizer(modelEn, 16000.0f);
                }

                waveIn = new WaveInEvent();
                waveIn.DeviceNumber = 0;
                waveIn.WaveFormat = new WaveFormat(16000, 1);
                waveIn.DataAvailable += WaveIn_DataAvailable;
                waveIn.RecordingStopped += WaveIn_RecordingStopped;

                waveIn.StartRecording();
                tanimaCalisiyor = true;
                btnBaslatDurdur.Text = "Durdur";
                rtbSonuc.Text = $"Dinleniyor... ({selected})";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Başlatma hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Durdur();
            }
        }

        private void Durdur()
        {
            try
            {
                if (waveIn != null)
                {
                    waveIn.StopRecording();
                    waveIn.Dispose();
                    waveIn = null;
                }

                if (recognizer != null)
                {
                    string finalJson = recognizer.FinalResult();
                    string finalText = ExtractText(finalJson);
                    if (!string.IsNullOrWhiteSpace(finalText))
                        rtbSonuc.AppendText("\n" + finalText);

                    recognizer.Dispose();
                    recognizer = null;
                }

                tanimaCalisiyor = false;
                btnBaslatDurdur.Text = "Başlat";
                rtbSonuc.AppendText("\n\nTanıma durduruldu.\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Durdurma hatası: " + ex.Message);
            }
        }

        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (recognizer == null) return;

            bool isFinal = recognizer.AcceptWaveform(e.Buffer, e.BytesRecorded);
            if (isFinal)
            {
                string resultJson = recognizer.Result();
                string text = ExtractText(resultJson);
                if (!string.IsNullOrWhiteSpace(text))
                {
                    rtbSonuc.Invoke(new Action(() =>
                    {
                        rtbSonuc.AppendText(" " + text);
                    }));
                }
            }
        }

        private void WaveIn_RecordingStopped(object sender, StoppedEventArgs e)
        {
            if (e.Exception != null)
                MessageBox.Show("Kayıt hatası: " + e.Exception.Message);
        }

        private string ExtractText(string json)
        {
            if (string.IsNullOrEmpty(json)) return string.Empty;
            var match = Regex.Match(json, "\"text\"\\s*:\\s*\"([^\"]*)\"");
            return match.Success ? match.Groups[1].Value : string.Empty;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Durdur();
            modelTr?.Dispose();
            modelEn?.Dispose();
        }
    }
}
