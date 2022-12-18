using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api_test.Data;
using web_api_test.Models;

namespace web_api_test.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelBookingController : ControllerBase
    {
        private readonly ApiContext _context;

        public HotelBookingController(ApiContext context)
        {
            _context = context;
        }


        // Create/
        [HttpPost]
        public JsonResult Create(HotelBooking booking)
        {
            if (booking.Id == 0)
            {
                _context.Bookings.Add(booking);
            }
          

            _context.SaveChanges();

            return new JsonResult(Ok(booking));

        }

        // Edit/
        [HttpPost]
        public JsonResult Edit(HotelBooking booking)
        {
            if (booking.Id != 0)
            {
                var bookingInDb = _context.Bookings.Find(booking.Id);

                if (bookingInDb == null)
                    return new JsonResult(NotFound());

                bookingInDb = booking;
            }
           

            _context.SaveChanges();

            return new JsonResult(Ok(booking));

        }


    }


}
