namespace eHotelApp.Domain.Entities
{
    public sealed class FloorRooms
    {
        public FloorRooms()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public HotelRooms? hotelRooms { get; set; }
        public int floorNumber { get; set; }
        public int roomNumber { get; set; }
        public int roomCount { get; set; }
        public string? RoomName { get; set; }
        public string? RoomType { get; set; }
        public bool isAvailable { get; set; }
    }
}