# Speech-to-Text WinForms App

Bu proje, **C# ve Windows Forms** kullanılarak geliştirilmiş bir **çok dilli konuşmayı yazıya dönüştürme (speech-to-text)** uygulamasıdır. Kullanıcılar, mikrofon üzerinden konuşmalarını söyleyebilir ve uygulama bu konuşmayı metin olarak ekranda görüntüler.

---

ÖZELLİKLER

- Canlı **ses tanıma** ve metne dönüştürme  
- **Türkçe ve İngilizce** dillerini destekleme  
- **Basit ve kullanıcı dostu arayüz**  
- Gerçek zamanlı **TextBox** güncelleme  

---

GEREKSİNİMLER

- Windows 10 veya üzeri  
- Visual Studio 2019 veya 2022  
- .NET Framework 4.7.2 veya üzeri  
- Mikrofon  

---

KULLANILAN TEKNOLOJİLER

- **C# / WinForms** – Kullanıcı arayüzü  
- **System.Speech** – Microsoft’un yerleşik Speech-to-Text kütüphanesi  
- **Multilingual Support** – Konuşma dilini seçme imkânı  

---

KURULUM

1. Bu projeyi bilgisayarınıza klonlayın veya zip olarak indirin.  
2. Visual Studio’da `SpeechToTextApp.sln` dosyasını açın.  
3. Gerekli NuGet paketlerini yükleyin (`System.Speech` dahil).  
4. Projeyi derleyin ve çalıştırın.  

---

KULLANIM

1. Uygulamayı başlatın.  
2. Menüden veya ComboBox’tan konuşma dilini seçin.  
3. **Başlat** butonuna basın.  
4. Mikrofonunuza konuşun, metin **TextBox**’ta görünür.  
5. **Durdur** butonuna basarak tanımayı durdurabilirsiniz.  

---

KOD YAPISI

- **Form1.cs** – Ana form ve kullanıcı arayüzü  
- **SpeechRecognitionEngine** – Konuşmayı algılayan ve metne çeviren sınıf  
- **ComboBox cmbDiller** – Kullanıcı tarafından seçilen dil  
- **TextBox txtSonuc** – Tanınan metnin görüntülendiği alan  

---


