# Proje Veritabanı Kurulumu

1. **Veritabanı Oluşturma**  
   SQL Server üzerinde **`OrderManagement`** adında bir veritabanı oluşturun.

2. **SQL Script'i Çalıştırma**  
   `OrderManagementApi\OrderManagementApi\SqlScript\28062025_Script.sql` dosyasını açın ve içeriğini oluşturduğunuz veritabanında çalıştırın.

3. **Scaffold Komutunu Güncelleme ve Çalıştırma**  
   `OrderManagementApi\OrderManagementApi\ScaffoldText\Scaffold.text` dosyasındaki Scaffold komutunu kendi veritabanı bağlantı string’inize göre güncelleyin.  
   Güncellenmiş komutu **Package Manager Console** üzerinde çalıştırarak kod üretimini gerçekleştirin.



# Sipariş Listesi Token Yönetimi
1. **TokenCacheService:**  
   - İlk token alındığında saklanır.  
   - Token süresi dolmadığı sürece tekrar token alınmaz.  
   - Süresi dolmak üzereyken (örneğin 30 saniye kala) token yenilenir.

2. **Rate Limiter:**  
   - Saatlik token alma isteği 5 ile sınırlandırılmıştır.  
   - Limit aşılırsa kullanıcıya uygun mesaj verilir.

3. **Sipariş Listeleme:**  
   - Token alındıktan sonra, her 5 dakikada bir sipariş listesi API çağrısı yapılır.  
   - Siparişler JSON olarak çekilir ve istenirse işlenir.

## Token Yönetimi Akışı ve Periyodik Sipariş Çekme Önerisi

- **İstek yapılacaksa önce `GetToken()` metodu çağrılır.**  
- `GetToken()` elimizde geçerli ve süresi dolmamış token varsa onu döner.  
- Eğer token yoksa veya süresi dolmak üzereyse, API’den yeni token almak için istek yapılır.  
- Yeni token alındığında önbelleğe kaydedilir ve kullanılır.  
- Bu token ile sipariş listesi API’sine istek yapılır.

---

## 5 Dakikada Bir Sipariş Listesi Çekme

Projede henüz 5 dakikada bir otomatik sipariş çekme mekanizması eklenmedi.  
Bunun için .NET Core’un `BackgroundService` yapısını kullanarak arka planda periyodik çalışan bir servis yazılabilir.  
