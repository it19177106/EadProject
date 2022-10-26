using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Xml.Linq;
using System.Numerics;

namespace MongoDBTestProject.Model
{
    public class FuelStationDetails
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; } = String.Empty;
        [BsonElement("location")]
        public String Location { get; set; } = String.Empty;
        [BsonElement("pumpsCount")]
        public int PumpsCount { get; set; }
        [BsonElement("fuelavailability")]
        public String FuelavAilability { get; set; } = String.Empty;
        [BsonElement("openingTime")]
        public DateTime OpeningTime { get; set; }

        [BsonElement("closingTime")]
        public DateTime ClosingTime { get; set; }
        [BsonElement("typeOfFuel")]
        public String TypeOfFuel { get; set; } = String.Empty;

    }
}
