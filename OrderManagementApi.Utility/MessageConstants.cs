namespace OrderManagementApi.Utility
{
    public static class MessageConstants
    {
     
        public const string VALIDATION_ERROR = "Veri doğrulama hatası";
        public const string RECORD_NOT_FOUND = "Kayıt bulunamadı";
        public const string INSUFFICIENT_STOCK = "Yeterli stok yok";
        public const string DUPLICATE_RECORD = "Bu kayıt zaten mevcut";
        public const string INVALID_ID = "Geçersiz ID";
        public const string DUPLICATE_PRODUCT_IN_ORDER = "Aynı ürün birden fazla kez eklenemez.";
        public const string RATE_LIMIT_EXCEEDED = "Saatlik giriş isteği sınırına ulaşıldı (en fazla 5)";
        public const string RESPONSE_DESERIALIZE_ERROR = "Response deserialize edilemedi";

        
        public const string GENERAL_ERROR = "Bir hata oluştu";
        public const string DATABASE_ERROR = "Veritabanı hatası";
        public const string NETWORK_ERROR = "Ağ bağlantı hatası";
        public const string TIMEOUT_ERROR = "İşlem zaman aşımına uğradı";
        public const string AUTH_ERROR = "Geçersiz kullanıcı adı veya şifre";
    }
}
