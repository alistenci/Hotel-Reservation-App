 namespace eHotelApp.Domain.Entities
{
    public sealed class HotelRooms
    {
        public HotelRooms()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string? RoomName { get; set; }
        public Guid RoomTypeId { get; set; }
        public string? RoomType { get; set; }
        public string? Description { get; set; }
        public int minGuests { get; set; }
        public int maxGuests { get; set; }
        public int maxChildren { get; set; }
        public int floorNumber { get; set; }
        public int roomNumber { get; set; }
        public int roomCount { get; set; }
        public bool isAvailable { get; set; }
        public decimal price { get; set; }
        public string? imageURL { get; set; }
    }
}




