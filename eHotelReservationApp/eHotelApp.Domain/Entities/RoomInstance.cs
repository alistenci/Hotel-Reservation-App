namespace eHotelApp.Domain.Entities
{
    public sealed class RoomInstance
    {
        public RoomInstance()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public HotelRooms? Room { get; set; }
        public int FloorNumber { get; set; }
        public int RoomNumber { get; set; }
        public bool IsAvailable { get; set; }
    }
}
