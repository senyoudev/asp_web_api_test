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

        //Get
        [HttpGet]
        public JsonResult GetPostById(int id)
        {
            var bookings = _context.Bookings.Find(id);
            if(bookings == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(Ok(bookings));
        }

        //Get
        [HttpGet]
        public JsonResult GetPosts()
        {
            var bookings = _context.Bookings.ToList();
            if (bookings == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(Ok(bookings));
        }

        //Delete
        [HttpDelete]
        public JsonResult DeletePost(int id)
        {
            var result = _context.Bookings.Find(id);

            if(result == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Bookings.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

    }


}
