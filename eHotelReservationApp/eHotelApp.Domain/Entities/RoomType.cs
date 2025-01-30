using Microsoft.AspNetCore.Http;

namespace eHotelApp.Domain.Entities
{
    public sealed class RoomType
    {
        public RoomType()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string? TypeName { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
    }
}
