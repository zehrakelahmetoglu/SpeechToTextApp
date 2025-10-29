using System;

namespace SpeechToTextApp
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbSonuc = new System.Windows.Forms.RichTextBox();
            this.cmbDiller = new System.Windows.Forms.ComboBox();
            this.btnBaslatDurdur = new System.Windows.Forms.Button();
            this.btnDilleriYükle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbSonuc
            // 
            this.rtbSonuc.Location = new System.Drawing.Point(50, 115);
            this.rtbSonuc.Name = "rtbSonuc";
            this.rtbSonuc.Size = new System.Drawing.Size(636, 122);
            this.rtbSonuc.TabIndex = 0;
            this.rtbSonuc.Text = "";
            // 
            // cmbDiller
            // 
            this.cmbDiller.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbDiller.FormattingEnabled = true;
            this.cmbDiller.Location = new System.Drawing.Point(8, 8);
            this.cmbDiller.Name = "cmbDiller";
            this.cmbDiller.Size = new System.Drawing.Size(211, 30);
            this.cmbDiller.TabIndex = 1;
            // 
            // btnBaslatDurdur
            // 
            this.btnBaslatDurdur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBaslatDurdur.Location = new System.Drawing.Point(26, 353);
            this.btnBaslatDurdur.Name = "btnBaslatDurdur";
            this.btnBaslatDurdur.Size = new System.Drawing.Size(150, 32);
            this.btnBaslatDurdur.TabIndex = 2;
            this.btnBaslatDurdur.Text = "Başlat";
            this.btnBaslatDurdur.UseVisualStyleBackColor = true;
            this.btnBaslatDurdur.Click += new System.EventHandler(this.btnBaslatDurdur_Click);
            // 
            // btnDilleriYükle
            // 
            this.btnDilleriYükle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDilleriYükle.Location = new System.Drawing.Point(196, 353);
            this.btnDilleriYükle.Name = "btnDilleriYükle";
            this.btnDilleriYükle.Size = new System.Drawing.Size(206, 32);
            this.btnDilleriYükle.TabIndex = 3;
            this.btnDilleriYükle.Text = "Dilleri Yükle";
            this.btnDilleriYükle.UseVisualStyleBackColor = true;
            this.btnDilleriYükle.Click += new System.EventHandler(this.btnDilleriYukle_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDilleriYükle);
            this.Controls.Add(this.btnBaslatDurdur);
            this.Controls.Add(this.cmbDiller);
            this.Controls.Add(this.rtbSonuc);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbSonuc;
        private System.Windows.Forms.ComboBox cmbDiller;
        private System.Windows.Forms.Button btnBaslatDurdur;
        private System.Windows.Forms.Button btnDilleriYükle;
        private EventHandler btnDilleriYükle_Click;
    }
}

