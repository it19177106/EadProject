using MongoDB.Driver;
using MongoDBTestProject.Model;
using static System.Collections.Specialized.BitVector32;

namespace MongoDBTestProject.Service
{
    public class FuelStationDetailsService : IFuelStationDetailsService

    {
        private readonly IMongoCollection<FuelStationDetails> _fuelStationDetails;
        private readonly IMongoCollection<FuelQueueDetails> _fuelQueueDetails;

        // Init DB Connections
        public FuelStationDetailsService(ICustomerDatabaseSettings settings, IMongoClient mongoClient)
        {
            // TODO: Add FuelQueue and FuelQueueHistory collections

            /* Using a single service for all Queue, History, and Fuel Station related 
             Model classes */

            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _fuelStationDetails = database.GetCollection<FuelStationDetails>(settings.FuelStationDetailsCollectionName);
            _fuelQueueDetails = database.GetCollection<FuelQueueDetails>(settings.FuelQueueDetailsCollectionName);

        }

        /*
          Fuel Station - Service Methods 
         */


        // Create a new FuelStation
        public FuelStationDetails CreateNewFuelStation(FuelStationDetails station)
        {
            _fuelStationDetails.InsertOne(station);
            return station;
        }
        // Get a single Fuel Station
        public FuelStationDetails GetFuelStationById(string id)
        {
            return _fuelStationDetails.Find(station => station.Id == id).FirstOrDefault();
        }
        // Get a List of Fuel Stations
        public List<FuelStationDetails> GetFuelStations()
        {
            return _fuelStationDetails.Find(station => true).ToList();
           
        }
        // Remove a fuel station (APP-ADMIN)
        public void RemoveFuelStationById(string id)
        {
            _fuelStationDetails.DeleteOne(station => station.Id == id);
        }

        // Update a existing Fuel Station
        public void UpdateFuelStation(string stationId, FuelStationDetails station)
        {
            _fuelStationDetails.ReplaceOne(station => station.Id == stationId, station);
        }

        // Specific update endpoint for update service starting time and end time.
        public void UpdateOpenTimeAndCloseTime(string stationId, FuelStationDetails station)
        {
            /* Find the existing document, update only the Starting time and Ending time.*/
            FuelStationDetails existingStation = GetFuelStationById(stationId);
            existingStation.OpeningTime = station.OpeningTime;
            existingStation.ClosingTime = station.ClosingTime;
            _fuelStationDetails.ReplaceOne(station => station.Id == existingStation.Id, existingStation);
        }



        /*
        FuelQueue, FuelQueueHistory - Service Methods 
       */




        public FuelQueueDetails CreateNewQueue(FuelQueueDetails queue)
        {
            _fuelQueueDetails.InsertOne(queue);
            return queue;
        }

        public List<FuelQueueDetails> GetAllQueue()
        {
            return _fuelQueueDetails.Find(station => station.Status == "IN").ToList();
        }

        public FuelQueueDetails GetQueueById(string id)
        {
            return _fuelQueueDetails.Find(station => station.VehicleNo == id).FirstOrDefault();
        }

        public void UpdateQueueStatus(string id)
        {
            DateTime now = DateTime.Now;
            FuelQueueDetails existingRequest = GetQueueById(id);
            existingRequest.Status = "OUT";
            existingRequest.DepartureAt = now.ToLongTimeString();
            _fuelQueueDetails.ReplaceOne(request => request.VehicleNo == existingRequest.VehicleNo, existingRequest);
        }

     
    }
}
