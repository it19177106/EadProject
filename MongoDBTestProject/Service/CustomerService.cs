using MongoDB.Driver;
using MongoDBTestProject.Model;

namespace MongoDBTestProject.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IMongoCollection<Customer> _customer;

        public CustomerService(ICustomerDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _customer = database.GetCollection<Customer>(settings.CustomerCollectionName);
        }
        public Customer Create(Customer customer)
        {
            _customer.InsertOne(customer);
            return customer;
        }

        public Customer Get(string id)
        {
            return _customer.Find(customer => customer.Id == id).FirstOrDefault();
        }

        public Customer GetCustomerByCustomername(string customername)
        {
            return _customer.Find(customer => customer.Customername == customername).FirstOrDefault();
        }

        public List<Customer> GetCustomerDetails()
        {
            return _customer.Find(customer => true).ToList();
        }

        public void Remove(string id)
        {
            _customer.DeleteOne(customer => customer.Id == id);
        }

        public void Update(string id, Customer customer)
        {
            _customer.ReplaceOne(customer => customer.Id == id, customer);
        }
    }
}
