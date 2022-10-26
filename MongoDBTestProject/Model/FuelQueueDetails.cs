using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDBTestProject.Model
{
    public class FuelQueueDetails
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; } = String.Empty;

        [BsonElement("stationId")]
        public String StationId { get; set; } = String.Empty;

        [BsonElement("vehicleNo")]
        public String VehicleNo { get; set; } = String.Empty;


        [BsonElement("customerId")]
        public String CustomerId { get; set; } = String.Empty;


        [BsonElement("noOfLiters")]
        public String Liters { get; set; } = String.Empty;

        [BsonElement("arrivalAt")]
        public String ArrivalAt { get; set; } = String.Empty;

        [BsonElement("departureAt")]
        public String DepartureAt { get; set; } = String.Empty;


        [BsonElement("status")]
        public String Status { get; set; } = String.Empty;

    }
}
