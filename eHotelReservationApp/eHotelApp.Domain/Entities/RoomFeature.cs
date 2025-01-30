namespace eHotelApp.Domain.Entities
{
    public sealed class RoomFeature
    {
        public RoomFeature() {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string? FeatureName { get; set; } = string.Empty;
       // public List<RoomTypeFeature> RoomTypeFeatures { get; set; } = new List<RoomTypeFeature>();  // Many-to-many ilişkisi
    }
}
 