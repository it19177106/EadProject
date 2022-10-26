using MongoDBTestProject.Model;

namespace MongoDBTestProject.Service
{
    public interface ICustomerService
    {
        List<Customer> GetCustomerDetails();
        Customer Get(String id);
        Customer Create(Customer customer);
        Customer GetCustomerByCustomername(string customer);
        void Update(String id, Customer customer);
        void Remove(String id);
    }
}
