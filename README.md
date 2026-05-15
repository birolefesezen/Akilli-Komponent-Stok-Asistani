# Akıllı Komponent Stok Asistanı

Akıllı Komponent Stok Asistanı, elektronik komponentlerin stok durumunu takip etmek, kritik stok seviyelerini belirlemek ve ilerleyen aşamada yapay zeka destekli stok raporu üretmek amacıyla geliştirilen bir ASP.NET Core MVC web uygulamasıdır.

Bu proje, yapay zeka destekli yazılım geliştirme dersi kapsamında; clean code, katmanlı mimari, veritabanı kullanımı, yapay zeka destekli geliştirme süreci ve teknik dokümantasyon kriterlerine uygun olarak geliştirilmektedir.

---

## Proje Amacı

Elektronik komponentlerle çalışan kişiler veya küçük ekipler için stok yönetimini daha kolay hale getirmek hedeflenmiştir.

Uygulama sayesinde kullanıcılar:

- Elektronik komponentleri sisteme ekleyebilir.
- Komponent stok miktarlarını takip edebilir.
- Kritik stok seviyesine düşen komponentleri görüntüleyebilir.
- Komponent bilgilerini güncelleyebilir veya silebilir.
- Stok durumunu web arayüzü üzerinden yönetebilir.
- İlerleyen aşamada yapay zeka destekli stok raporu alabilir.

---

## Temel Özellikler

- Komponent listeleme
- Yeni komponent ekleme
- Komponent detaylarını görüntüleme
- Komponent bilgilerini düzenleme
- Komponent silme
- Kritik stoktaki komponentleri listeleme
- Stok durumunu görsel olarak belirtme
- SQLite veritabanı kullanımı
- Entity Framework Core ile veri erişimi
- Repository ve Service katmanları ile clean code yaklaşımı
- Bootstrap destekli kullanıcı arayüzü
- Yapay zeka destekli stok raporu için genişletilebilir altyapı

---

## Kullanılan Teknolojiler

- ASP.NET Core MVC
- C#
- .NET 9
- Entity Framework Core
- SQLite
- Razor View Engine
- Bootstrap 5
- xUnit
- Git / GitHub
- Visual Studio Code
- AI Agent / Yapay Zeka Destekli Kod Üretimi

---

## Proje Mimarisi

Projede katmanlı ve sade bir mimari yaklaşım tercih edilmiştir.

Genel akış şu şekildedir:

```text
Controller
   ↓
Service
   ↓
Repository
   ↓
AppDbContext
   ↓
SQLite Database
```

### Katmanların Sorumlulukları

#### Controller Katmanı

Kullanıcıdan gelen HTTP isteklerini karşılar ve uygun view dosyalarını döndürür. Controller katmanında doğrudan veritabanı işlemi yapılmaz.

#### Service Katmanı

İş kurallarının uygulandığı katmandır.

Örnek iş kuralları:

- Komponent adı boş olamaz.
- Kategori boş olamaz.
- Fiyat negatif olamaz.
- Stok miktarı negatif olamaz.
- Minimum stok seviyesi negatif olamaz.
- Güncelleme işleminde `UpdatedAt` alanı güncellenir.

#### Repository Katmanı

Veritabanı erişiminden sorumludur. Entity Framework Core üzerinden CRUD işlemlerini gerçekleştirir. Repository katmanında iş kuralları tutulmaz.

#### Data Katmanı

`AppDbContext` sınıfı ile Entity Framework Core yapılandırması ve seed data işlemleri yapılır.

---

## Klasör Yapısı

```text
Akilli-Komponent-Stok-Asistani
│
├── AkilliKomponentStokAsistani.Web
│   ├── Controllers
│   │   ├── HomeController.cs
│   │   └── ComponentsController.cs
│   │
│   ├── Data
│   │   └── AppDbContext.cs
│   │
│   ├── Models
│   │   └── ComponentItem.cs
│   │
│   ├── Repositories
│   │   ├── IComponentRepository.cs
│   │   └── ComponentRepository.cs
│   │
│   ├── Services
│   │   ├── IComponentService.cs
│   │   └── ComponentService.cs
│   │
│   ├── Views
│   │   ├── Components
│   │   │   ├── Index.cshtml
│   │   │   ├── Details.cshtml
│   │   │   ├── Create.cshtml
│   │   │   ├── Edit.cshtml
│   │   │   ├── Delete.cshtml
│   │   │   └── CriticalStock.cshtml
│   │   │
│   │   ├── Home
│   │   └── Shared
│   │
│   ├── Migrations
│   ├── Program.cs
│   └── appsettings.json
│
├── AkilliKomponentStokAsistani.Tests
│   └── UnitTest1.cs
│
├── .gitignore
├── LICENSE
├── README.md
└── AkilliKomponentStokAsistani.sln
```

---

## Veritabanı Tasarımı

Projede SQLite veritabanı kullanılmaktadır. Veritabanı işlemleri Entity Framework Core ile yönetilmektedir.

Ana entity sınıfı `ComponentItem` olarak belirlenmiştir.

### ComponentItem Alanları

| Alan | Açıklama |
|---|---|
| `Id` | Komponentin benzersiz kimliği |
| `ComponentName` | Komponent adı |
| `Category` | Komponent kategorisi |
| `PackageType` | Komponent paket tipi |
| `Price` | Komponent fiyatı |
| `StockQuantity` | Mevcut stok miktarı |
| `MinimumStockLevel` | Minimum stok seviyesi |
| `Description` | Komponent açıklaması |
| `DatasheetUrl` | Komponent datasheet bağlantısı |
| `CreatedAt` | Kayıt oluşturulma tarihi |
| `UpdatedAt` | Kayıt güncellenme tarihi |
| `IsCriticalStock` | Stok miktarının kritik seviyede olup olmadığını hesaplayan property |

### Kritik Stok Mantığı

Bir komponentin kritik stokta sayılması için aşağıdaki koşul kullanılır:

```text
StockQuantity <= MinimumStockLevel
```

Bu koşul sağlanıyorsa komponent kritik stokta kabul edilir.

---

## Seed Data

Uygulama ilk kurulumda örnek elektronik komponent verileri ile başlatılmaktadır.

Örnek komponentler:

- 1k Ohm Resistor
- 10uF Capacitor
- STM32F103C8T6
- BC547 Transistor
- LM7805 Voltage Regulator

Bu veriler, uygulamanın test edilmesini ve demo sunumlarında hızlıca kullanılmasını sağlar.

---

## Kurulum

Projeyi kendi bilgisayarınızda çalıştırmak için aşağıdaki adımları izleyebilirsiniz.

### 1. Repoyu klonlayın

```bash
git clone https://github.com/birolefesezen/Akilli-Komponent-Stok-Asistani.git
```

### 2. Proje klasörüne girin

```bash
cd Akilli-Komponent-Stok-Asistani
```

### 3. Paketleri geri yükleyin

```bash
dotnet restore
```

### 4. Projeyi derleyin

```bash
dotnet build
```

### 5. Veritabanını oluşturun

```bash
dotnet ef database update --project AkilliKomponentStokAsistani.Web
```

### 6. Uygulamayı çalıştırın

```bash
dotnet run --project AkilliKomponentStokAsistani.Web
```

Uygulama varsayılan olarak aşağıdaki adreste çalışabilir:

```text
http://localhost:5185
```

---

## Kullanım

Uygulama çalıştırıldıktan sonra tarayıcı üzerinden aşağıdaki sayfalara erişilebilir.

### Komponent Listesi

```text
/Components
```

Bu sayfada sistemde kayıtlı tüm elektronik komponentler listelenir.

### Yeni Komponent Ekleme

```text
/Components/Create
```

Bu sayfa üzerinden yeni komponent kaydı oluşturulabilir.

### Kritik Stoklar

```text
/Components/CriticalStock
```

Bu sayfada yalnızca minimum stok seviyesine ulaşmış veya minimum seviyenin altına düşmüş komponentler listelenir.

---

## Yapay Zeka Kullanımı

Bu proje yapay zeka destekli yazılım geliştirme süreciyle geliştirilmektedir.

Geliştirme sürecinde AI Agent, Gemini veya benzeri yapay zeka araçlarından şu amaçlarla yararlanılmıştır:

- Proje mimarisinin planlanması
- Entity modelinin oluşturulması
- Repository ve Service katmanlarının tasarlanması
- CRUD ekranlarının oluşturulması
- Kod kalitesinin iyileştirilmesi
- README ve dokümantasyon taslaklarının hazırlanması

İlerleyen aşamada uygulamaya doğrudan bir yapay zeka özelliği de eklenecektir.

Planlanan AI özelliği:

> Veritabanındaki komponent stoklarını analiz ederek Türkçe stok değerlendirme raporu oluşturmak.

AI destekli stok raporu şu bilgileri içerecektir:

- Kritik stoktaki ürünler
- Satın alma öncelikleri
- Stok durumu özeti
- Teknik riskler
- Kısa öneriler

---

## Kullanılan Prompt Yaklaşımı

Projede yapay zeka araçları tek seferde bütün projeyi üretmek için değil, kontrollü ve aşamalı geliştirme için kullanılmıştır.

Kullanılan prompt yaklaşımı:

- Önce proje amacı ve teknoloji yığını açıklandı.
- Her görev küçük parçalara ayrıldı.
- AI Agent’a sadece belirli dosyalar üzerinde işlem yapması söylendi.
- Eski proje klasörlerine dokunmaması özellikle belirtildi.
- Kod üretiminden sonra `dotnet build` ile kontrol yapıldı.
- Başarılı her aşama GitHub’a ayrı commit olarak gönderildi.

Örnek geliştirme aşamaları:

```text
1. Proje iskeleti oluşturma
2. Entity ve DbContext oluşturma
3. Repository ve Service katmanı ekleme
4. CRUD ekranlarını oluşturma
5. Dashboard geliştirme
6. AI stok raporu ekleme
7. Dokümantasyon hazırlama
```

---

## Clean Code Yaklaşımı

Projede clean code ilkelerine uygunluk için aşağıdaki kurallara dikkat edilmiştir:

- Controller içinde doğrudan veritabanı erişimi yapılmamıştır.
- İş kuralları Service katmanında toplanmıştır.
- Veri erişimi Repository katmanına ayrılmıştır.
- Dependency Injection kullanılmıştır.
- Async metotlar tercih edilmiştir.
- Validasyonlar model seviyesinde tanımlanmıştır.
- Gereksiz build çıktıları GitHub reposundan çıkarılmıştır.
- `.gitignore` dosyası ile `bin`, `obj`, `.db` gibi dosyalar takip dışı bırakılmıştır.

---

## Testler

Projede xUnit test projesi oluşturulmuştur.

Test projesi:

```text
AkilliKomponentStokAsistani.Tests
```

İlerleyen aşamada aşağıdaki testlerin eklenmesi planlanmaktadır:

- Kritik stok kontrolü testi
- Negatif fiyat kontrolü testi
- Negatif stok miktarı kontrolü testi
- Boş komponent adı kontrolü testi
- Service katmanı iş kuralları testi

Testleri çalıştırmak için:

```bash
dotnet test
```

---

## Teknik Borç ve Kod Kalitesi

Proje geliştirme sürecinde teknik borcun düşük tutulması hedeflenmektedir.

Planlanan kalite kontrolleri:

- `dotnet build`
- `dotnet test`
- `dotnet format`
- Statik kod analizi
- SonarQube veya benzeri analiz aracı ile teknik borç kontrolü

Hedef:

```text
Teknik borç oranı %5'in altında tutulacaktır.
```

---

## Git ve Commit Süreci

Proje geliştirilirken her önemli aşama ayrı commit olarak GitHub’a gönderilmiştir.

Örnek commit aşamaları:

```text
Initial ASP.NET Core MVC project setup
Add Entity Framework Core SQLite packages
Add component model and SQLite database context
Remove generated build artifacts from repository
Add repository and service layers
Add component CRUD pages
```

Bu yaklaşım sayesinde proje geliştirme süreci daha takip edilebilir hale getirilmiştir.

---

## Mevcut Durum

Tamamlanan aşamalar:

- GitHub repo oluşturuldu.
- ASP.NET Core MVC proje yapısı kuruldu.
- Test projesi oluşturuldu.
- Entity Framework Core ve SQLite yapılandırıldı.
- ComponentItem modeli oluşturuldu.
- AppDbContext oluşturuldu.
- Migration işlemleri tamamlandı.
- Seed data eklendi.
- Repository ve Service katmanları oluşturuldu.
- CRUD ekranları oluşturuldu.
- Kritik stok listeleme ekranı oluşturuldu.
- Navbar bağlantıları güncellendi.
- `.gitignore` düzenlendi.
- Build çıktıları GitHub reposundan temizlendi.

Devam edecek aşamalar:

- Dashboard ekranı geliştirilecek.
- AI stok raporu özelliği eklenecek.
- Testler genişletilecek.
- Teknik borç analizi yapılacak.
- Proje dokümantasyonu tamamlanacak.
- Sunum ve video anlatım hazırlanacak.

---

## Planlanan Geliştirmeler

- Modern dashboard ekranı
- Kategori bazlı stok özeti
- En düşük stoklu ürünlerin gösterimi
- AI destekli stok raporu
- Kullanıcı dostu hata mesajları
- Daha gelişmiş arama ve filtreleme
- Unit test kapsamının artırılması
- Teknik borç raporu
- Proje mimari dokümantasyonu

---

## Ders Kriterleri ile Uyum

| Kriter | Durum |
|---|---|
| En az bir yapay zeka dil modeli kullanımı | Geliştirme sürecinde kullanıldı, uygulama içi AI özelliği planlandı |
| Veritabanı kullanımı | SQLite kullanıldı |
| Clean code ilkeleri | Repository + Service katmanı ile desteklendi |
| Mimari dokümantasyon | README ve ek dokümanlarla hazırlanıyor |
| AI araçları için kullanılan tekniklerin açıklanması | README içinde açıklandı, ayrıca docs dosyaları planlandı |
| Teknik borç oranı | Analiz aşaması planlandı |
| Sunum / video anlatım | Proje tamamlandığında hazırlanacak |

---

## Lisans

Bu proje MIT lisansı ile lisanslanmıştır. Detaylar için `LICENSE` dosyasına bakınız.

---

## Geliştirici

**BIROL EFE SEZEN**

GitHub: https://github.com/birolefesezen
