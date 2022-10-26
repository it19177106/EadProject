using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace MongoDBTestProject.Model
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; } = String.Empty;
        [BsonElement("customer")]
        public String Customername { get; set; } = String.Empty;
        [BsonElement("emailaddress")]
        public String EmailAddress { get; set; } = String.Empty;
        [BsonElement("password")]
        public byte[]? Password { get; set; }
        [BsonElement("passwordKay")]
        public byte[]? PasswordKay { get; set; }
        [BsonElement("role")]
        public String JobRole { get; set; } = String.Empty;
        [BsonElement("typeOfVehicle")]
        public String TypeOfVehicle { get; set; } = String.Empty;
    }
}
