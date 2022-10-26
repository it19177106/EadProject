using Microsoft.AspNetCore.Mvc;
using MongoDBTestProject.Model;
using MongoDBTestProject.Service;

namespace MongoDBTestProject.Controllers
{
    public class FuelStationDetailsController : Controller
    {
        private readonly IFuelStationDetailsService fuelStationDeatilsService;
        public FuelStationDetailsController(IFuelStationDetailsService fuelStationDetailsService)
        {
            this.fuelStationDeatilsService = fuelStationDeatilsService;
        }


        // GET api/<FuelStationController>/<id>
        [HttpGet("{id}")]
        public ActionResult<FuelStationDetails> GetFuelStationById(String id)
        {
            var station = fuelStationDeatilsService.GetFuelStationById(id);
            if (station == null)
            {
                return NotFound($"Fuel Station with Id = {id} not found");
            }

            return station;
        }
         


        //Queue

        //Create Queue
        [HttpPost("addFuelStationQueue")]
        public ActionResult<FuelQueueDetails> AddQueue([FromBody] FuelQueueDetails request)
        {
            if (request.VehicleNo == null || request.CustomerId == null || request.StationId == null || request.Liters == null)
            {
                return BadRequest("Missing Fuel Station Details!");
            }
            DateTime now = DateTime.Now;

            FuelQueueDetails queue = new FuelQueueDetails();
            queue.VehicleNo = request.VehicleNo;
            queue.StationId = request.StationId;
            queue.CustomerId = request.CustomerId;
            queue.Liters = request.Liters;
            queue.ArrivalAt = now.ToLongTimeString();
            queue.DepartureAt = "0.00.00";
            queue.Status = "IN";
            fuelStationDeatilsService.CreateNewQueue(queue);
            return CreatedAtAction(nameof(GetFuelStationById), new { id = queue.Id }, queue);
        }

        //Get All Queue 
        [HttpGet("getFuelQueue")]
        public ActionResult<List<FuelQueueDetails>> GetAllFuelQueue()
        {
            return fuelStationDeatilsService.GetAllQueue();
        }

        //Get One Queue
        [HttpGet("getqueue/{id}")]
        public ActionResult<FuelQueueDetails> GetQueue(String id)
        {
            var station = fuelStationDeatilsService.GetQueueById(id);
            if (station == null)
            {
                return NotFound($"Fuel Queue with Id = {id} not found");
            }

            return station;
        }

        [HttpPut("updateQueueState/{id}")]
        public ActionResult updateQueueStatus(String id, [FromBody] FuelQueueDetails station)
        {
            String status = "OUT";

            fuelStationDeatilsService.UpdateQueueStatus( id);
            return Content(id+" Status Updated!");
        }

    }
}
