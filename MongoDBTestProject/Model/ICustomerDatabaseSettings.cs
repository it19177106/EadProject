namespace MongoDBTestProject.Model
{
    public interface ICustomerDatabaseSettings
    {
        string CustomerDetailsCollectionName { get; set; }
        string FuelStationDetailsCollectionName { get; set; }
        string FuelQueueHistoryDetailsCollectionName { get; set; }
        string FuelQueueDetailsCollectionName { get; set; }
        string FuelQueueRequestDetailsCollectionName { get; set; }

        string CustomerCollectionName { get; set; }
        string DatabaseName { get; set; } 
        string ConnectionString { get; set; }   


    }
}
