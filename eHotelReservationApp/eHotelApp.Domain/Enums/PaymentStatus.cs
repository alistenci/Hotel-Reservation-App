namespace eHotelApp.Domain.Enums
{
    public enum PaymentStatus
    {
        Pending,      // Beklemede
        Completed,    // Tamamlandı
        Failed,       // Başarısız
        Refunded       // İade edildi
    }
}
