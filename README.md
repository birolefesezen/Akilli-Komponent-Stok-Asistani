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
- Stok durumunu badge yapısı ile görsel olarak belirtme
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
