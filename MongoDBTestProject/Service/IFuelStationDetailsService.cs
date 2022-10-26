using MongoDBTestProject.Model;

namespace MongoDBTestProject.Service
{
    /* SERVICE CLASS - Fuel Stations */
    public interface IFuelStationDetailsService
    {
        /* Fuel Station Related Service methods */

        // List of fuel stations for the queue users references.
        List<FuelStationDetails> GetFuelStations();
        // Single fuel station details for the Station Owner.
        FuelStationDetails GetFuelStationById(String id);
        FuelStationDetails CreateNewFuelStation(FuelStationDetails station);
        // Update fuel station queue starting time and ending time.
        void UpdateFuelStation(String stationId, FuelStationDetails station);
        void RemoveFuelStationById(String id);
        void UpdateOpenTimeAndCloseTime(String id, FuelStationDetails station);

        /* Fuel Queue Request Related Service methods */
        //void UpdateApprovalStatusFuelRequest(String approaval, String id);
      


        // Insert Queue
        FuelQueueDetails CreateNewQueue(FuelQueueDetails queue);

        // Get all Queue
        List<FuelQueueDetails> GetAllQueue();

        // Specific get Queue
        FuelQueueDetails GetQueueById(String id);


        // Remove from Queue
        void UpdateQueueStatus(String id);

        

        // Queue History Add

        // Status 



    }
}
