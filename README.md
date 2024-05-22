# Okul Yönetim Sistemi Projesi
## Projenin Genel Amacı
###
Mezuniyet tezi kapsamında geliştirmiş olduğum Okul Yönetim Sistemi platformu herhangi bir ilkokul, ortaokul ya da ortaöğretim kurumlarına yönelik hazırlanmış bir web sitesidir. Bu sitede Admin, Öğrenci ve Öğretmen için ayrı paneller hazırlanmış olup 
rolüyle birlikte yeni bir kullanıcı oluşturma işlemini Admin rolüne sahip kullanıcılar yapabilmektedir. 

Admin paneli, yalnızca admin kullanıcılarına özel olup haber yükleme, duyuru yapma, ders kaynakları ve öğrencilere ait ders notları gibi işlemleri kapsamaktadır. Ayrıca sistemi tümüyle dinamik hale getirebilme yetkisine sahiptir. 
Öğretmenler kendi panelleri üzerinden ilgili dersler için öğrencilere yönelik video ya da doküman yüklemesi yapabilir, öğrencilerin sınav veya performans notlarını girebilir, öğrencilere hızlı ulaşabilmeleri amacıyla duyurular yapabilirler. 
Öğrenciler ise öğrenci paneli sayesinde yapılan duyuruları görebilir, ilgili derslere yüklenen kaynaklara erişim sağlayarak ders tekrarları ile bilgilerini tazeleyebilir ve ders notlarını görüntüleyebilirler.

Asp.Net Core 7.0 kullanılarak geliştirilen bu uygulamada, Entity Framework Code First yaklaşımı kullanılmaktadır. N katmanlı mimari yapısı kullanılarak CRUD (Create, Read, Update, Delete) işlemleri daha etkili ve basit bir şekilde gerçekleştirilmektedir.
###

# Kullanılan Teknolojiler
- Asp.Net Core 7.0
- Entity Framework Code First
- MSSQL Server
- Identity
- LINQ
- Unit Of Work
- Html
- Css
- JavaScript
- AJAX
- Bootstrap
- SweetAlert
- Fluent Validation
- AutoMapper
- Toastr Bildirimleri
- MailKit
- CKEditor

# Teknik Özellikler
- N Katmanlı Mimari Yapısı
- Repository Tasarım Deseni
- Unit Of Work Tasarım Deseni
- PagedList ile sayfalama yapısı
- Fluent Validation ile doğrulama
- Identity ile kullanıcı ve rol işlemleri
- AutoMapper ile DTO(Data Transfer Object) kullanımları
- Code First Yaklaşımı
  
# Sitenin Öne Çıkan Özellikleri
- Admin Paneli, Öğretmen Paneli, Öğrenci Paneli
- Identity kütüphanesi ile giriş yapma özelliği.
- Rolleme ve yetkilendirme ile erişim kısıtlamaları
- FluentValidation kütüphanesi yardımıyla doğrulamalar
- AJAX ile işlemler
- MailKit ile Mesajlaşma özelliği
- PagedList ile sayfalama yapısı
- Panellerde ilgili CRUD işlemleri & Profil ayarları sayfaları
- Silme işlemi sonrasında silinen verileri Silinmiş Öğeler menüsü altında bulabilme & geri döndürebilme
- Admin panelinde rolüyle birlikte kullanıcı oluşturma
- Ders Videosunu izleyen öğrencileri görüntüleyebilme
- Panellerde, birçok tablo kullanımlarında DataTable kullanımı
- Panellerde ilgili kısımlarda metin editörü (CKEditor) kullanımı
- Öğrenciler listesini Excel formatında indirebilme
- Şifremi Unuttum özelliği
- Arama işlemleri

# Admin Paneli Özellikleri
- İstatistikleri görme
- Profil düzenleme işlemleri
- Mesajlaşma sistemi
- Kullanıcılar & Dersler & Sınıflar & Haberler gibi sayfalarda CRUD işlemleri
- Sitede gösterilmek üzere Adres & Hakkımızda & Sosyal Medya bilgilerini güncelleyebilme
- Öğretmen ya da Öğrencilere yönelik Duyuru yapabilme
- Derslere yüklenen videoları ve dosyaları görüntüleyebilme & düzenleyebilme
- Öğrencilere girilmiş ders notlarını görüntüleyebilme & düzenleyebilme
- İletişim sayfasından gelen mesajları görebilme/yanıtlayabilme
- Haber bültenine abone olanlara toplu mail gönderebilme
- Sınıf ekleme işleminde AJAX kullanımı
- İlgili sınıfta bulunan öğrenciler listesini Excel formatında indirebilme
- Silinmiş Öğeler menüsü (silinen veriyi geri döndürebilme ya da tamamen sistemden kaldırabilme)
- Arama işlemi

# Öğretmen Paneli Özellikleri
- İstatistikleri görme
- Profil düzenleme işlemleri
- Mesajlaşma Sistemi
- Admin kullanıcılarından gelen duyuruları görüntüleyebilme
- Öğrencilere yönelik duyuru yapabilme
- Verdiği dersin bulunduğu sınıftaki öğrencilere not girişi yapabilme (yalnızca kendi dersleri için not girişi yapılıyor)
- Kendi verdiği derslere ait doküman & video yüklemesi yapabilme
- İlgili sınıfta bulunan öğrenciler listesini Excel formatında indirebilme
- Silinmiş Öğeler menüsü (silinen veriyi geri döndürebilme ya da tamamen sistemden kaldırabilme)
- Arama işlemi

# Öğrenci Paneli Özellikleri
- İstatistikleri görme
- İzlememiş ve izlemiş olduğu video sayısı oranını grafikte görüntüleme & izlememiş olduğu videoları tabloda görüntüleme
- Profil düzenleme işlemleri
- Mesajlaşma Sistemi
- Bulunduğu sınıfta yer alan tüm dersleri görebilme
- Kendi derslerine ait yüklenmiş doküman & videoları görüntüleyebilme
- Not sistemi üzerinden girilmiş sınav & performans notlarını görüntüleyebilme ve genel ortalamasını görebilme
- Admin veya öğretmenlerden gelen duyuruları görüntüleyebilme
- Arama işlemi

# Sitenin Görselleri

### Ana Sayfa 
![Ana ekran](https://github.com/busraozdemir0/SchoolManagementSystem/blob/master/PresentationLayer/wwwroot/Proje_ScreenShots/home.png)

### Ana Sayfa - Haberler Sayfası
![Ana sayfa](https://github.com/busraozdemir0/SchoolManagementSystem/blob/master/PresentationLayer/wwwroot/Proje_ScreenShots/news.png)

### Giriş Yap Sayfası
![Ana sayfa](https://github.com/busraozdemir0/SchoolManagementSystem/blob/master/PresentationLayer/wwwroot/Proje_ScreenShots/login.png)

### Şifremi Unuttum İşlemi
![Ana sayfa](https://github.com/busraozdemir0/SchoolManagementSystem/blob/master/PresentationLayer/wwwroot/Proje_ScreenShots/sifremiUnuttum.png)

### Admin Paneli
![Ana sayfa](https://github.com/busraozdemir0/SchoolManagementSystem/blob/master/PresentationLayer/wwwroot/Proje_ScreenShots/adminPanel.png)

### Admin Paneli - Profil Ayarları
![Ana sayfa](https://github.com/busraozdemir0/SchoolManagementSystem/blob/master/PresentationLayer/wwwroot/Proje_ScreenShots/profilSettings.png)

### Admin Paneli - Gelen Kutusu
![Ana sayfa](https://github.com/busraozdemir0/SchoolManagementSystem/blob/master/PresentationLayer/wwwroot/Proje_ScreenShots/adminInbox.png)

### Admin Paneli - Derslere Yüklenmiş Videolar
![Ana sayfa](https://github.com/busraozdemir0/SchoolManagementSystem/blob/master/PresentationLayer/wwwroot/Proje_ScreenShots/lessonVideos.png)

### Admin Paneli - Hakkımızda Sayfası
![Ana sayfa](https://github.com/busraozdemir0/SchoolManagementSystem/blob/master/PresentationLayer/wwwroot/Proje_ScreenShots/aboutUpdate.png)

### Admin Paneli - Arama İşlemi
![Ana sayfa](https://github.com/busraozdemir0/SchoolManagementSystem/blob/master/PresentationLayer/wwwroot/Proje_ScreenShots/search.png)

### Öğretmen Paneli
![Ana sayfa](https://github.com/busraozdemir0/SchoolManagementSystem/blob/master/PresentationLayer/wwwroot/Proje_ScreenShots/teacherPanel.png)

### Öğretmen Paneli - Mesaj Oluşturma
![Ana sayfa](https://github.com/busraozdemir0/SchoolManagementSystem/blob/master/PresentationLayer/wwwroot/Proje_ScreenShots/teacherCreateMessage.png)

### Öğretmen Paneli - Silinmiş Öğeler Menüsü
![Ana sayfa](https://github.com/busraozdemir0/SchoolManagementSystem/blob/master/PresentationLayer/wwwroot/Proje_ScreenShots/sweetAlert.png)

### Öğrenci Paneli
![Ana sayfa](https://github.com/busraozdemir0/SchoolManagementSystem/blob/master/PresentationLayer/wwwroot/Proje_ScreenShots/studentPanel.png)

### Öğrenci Paneli - İstatistikler Sayfası
![Ana sayfa](https://github.com/busraozdemir0/SchoolManagementSystem/blob/master/PresentationLayer/wwwroot/Proje_ScreenShots/istatistikler.png)

### Öğrenci Paneli - Not Sistemi
![Ana sayfa](https://github.com/busraozdemir0/SchoolManagementSystem/blob/master/PresentationLayer/wwwroot/Proje_ScreenShots/student_notSistemi.png)

### Öğrenci Paneli - İlgili Derse Yüklenmiş Ders Videoları
![Ana sayfa](https://github.com/busraozdemir0/SchoolManagementSystem/blob/master/PresentationLayer/wwwroot/Proje_ScreenShots/student_lessonVideos.png)

