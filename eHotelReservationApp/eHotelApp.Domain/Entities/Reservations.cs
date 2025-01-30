using eHotelApp.Domain.Enums;

namespace eHotelApp.Domain.Entities
{
    public sealed class Reservations
    {
        public Reservations()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public Guid RoomId { get; set; }
        public HotelRooms? ReservedRooms { get; set; }  // Rezervasyonu yapılan odalar
        public decimal TotalPrice { get; set; }
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;
        public string? Notes { get; set; }
        public string? fullName { get; set; }
        public string? eMail { get; set; }
        public string? phoneNumber { get; set; }
        public string? identityNumber { get; set; }
        public int floorNumber { get; set; }
        public int roomNumber { get; set; }
    }
}
