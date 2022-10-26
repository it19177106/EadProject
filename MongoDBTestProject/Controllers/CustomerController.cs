using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MongoDBTestProject.Auth;
using MongoDBTestProject.Model;
using MongoDBTestProject.Service;
using System.Security;

namespace MongoDBTestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        private readonly IAuthHashService authService;
        public CustomerController(ICustomerService customerService, IAuthHashService authService)
        {
            this.customerService = customerService;
            this.authService = authService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<List<Customer>> Get()
        {
            return customerService.GetCustomerDetails();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(String id)
        {
            var customer = customerService.Get(id);
            if (customer == null)
            {
                return NotFound($"user with Id = {id} not found");
            }
            
            return customer;
        }

        // POST api/<UserController>
        [HttpPost("registration")]
        public ActionResult<Customer> Registration([FromBody] CustomerRequest request)
        {
            if (request.Customername == null || request.EmailAddress == null || request.Password == null || request.TypeOfVehicle == null)
            {
                return BadRequest("Fail to registre");
            }
            authService.PasswordHashing(request.Password, out byte[] passwordHash, out byte[] passwordKey);

            Customer customer = new Customer();
            customer.Customername = request.Customername;
            customer.EmailAddress = request.EmailAddress;
            customer.Password = passwordHash;
            customer.PasswordKay = passwordKey;
            customer.JobRole = request.JobRole;
            customer.TypeOfVehicle = request.TypeOfVehicle;

            customerService.Create(customer);
            return  CreatedAtAction(nameof(Get), new { id = customer.Id }, customer);
        }

        [HttpPost("login")]
        public ActionResult<Customer> Login([FromBody] CustomerRequest request)
        {
            if (request.Customername == null || request.Password == null)
            {
                return BadRequest("Fail to login");
            }
            var existingUser = customerService.GetCustomerByCustomername(request.Customername);

            if (existingUser == null)
            {
                return NotFound($"customer with username = {request.Customername} not found");
            }
            bool verification = authService.VerifyPassword(request.Password, existingUser.Password, existingUser.PasswordKay);

            if (!verification)
            {
                return NotFound("Wrong username or password");
            }
            
            return Ok(existingUser);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult Put(String id, [FromBody] Customer customer)
        {
            var existingUser = customerService.Get(id);

            if (existingUser == null)
            {
                return NotFound($"CustomerDeatils with Id = {id} not found");
            }

            customerService.Update(id, customer);

            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(String id)
        {
            var customer = customerService.Get(id);

            if (customer == null)
            {
                return NotFound($"CustomerDeatils with Id = {id} not found");
            }

            customerService.Remove(customer.Id);

            return Ok($"CustomerDeatils with Id = {id} deleted");
        }
    }
}
