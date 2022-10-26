namespace MongoDBTestProject.Model
{
    public class CustomerDatabaseSettings : ICustomerDatabaseSettings
    {
        public string CustomerDetailsCollectionName { get; set; } = String.Empty;

        public string CustomerCollectionName { get; set; } = String.Empty;

        public string DatabaseName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string FuelStationDetailsCollectionName { get; set; } = String.Empty;
        public string FuelQueueHistoryDetailsCollectionName { get; set; } = String.Empty;
        public string FuelQueueDetailsCollectionName { get; set; } = String.Empty;
        public string FuelQueueRequestDetailsCollectionName { get; set; } = String.Empty;
    }

    }
