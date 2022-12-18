using Microsoft.EntityFrameworkCore;
using web_api_test.Models;

namespace web_api_test.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {

        }

        public DbSet<HotelBooking> Bookings { get; set; }
    }
}
