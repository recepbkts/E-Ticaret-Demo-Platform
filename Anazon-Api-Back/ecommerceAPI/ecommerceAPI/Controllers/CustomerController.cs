using ecommerceAPI.Helpers;
using ecommerceAPI.Models;
using ecommerceAPI.Models.Database;
using Microsoft.AspNetCore.Mvc;

namespace ecommerceAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")] //localhost/customer
    public class CustomerController : ControllerBase
    {

        //1.read müşteri listesını getır(sql de  select * from custemers gibi)
        [HttpGet] //yani http sayufası gitsin backend den data alsın (get data from backend)
        [Route("[action]")] //localhost/customer/list

        public IActionResult List() //bu aksıyon tüm müşterileri listeleyip fronta gönderecektir
        {
            try
            {
                using var context = new AnazonDbContext();

                var customers = context.Customers.Select(c => new {

                    c.CustomerId,
                    c.FirstName,
                    c.LastName,
                    c.Gender,
                    c.BirthDate,
                    c.Country,
                    c.Province,
                    c.City,
                    c.Address,
                    c.PostalCode,
                    c.Mobile,
                    c.RegisterDate,
                    c.Username,
                    c.Password,
                    Photo = İmageHelper.ByteToString( c.Photo)
                }).ToList();
                return Ok(customers);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //.2.create --> yeni müşteri ekleme 
        [HttpPost] //frontend posts data to the backend
        [Route("[action]")]

        public IActionResult Create([FromBody] CustomerCreateModel model)
        {
            try
            {
                using var context = new AnazonDbContext();
                var YeniMusteri = new Customer
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Gender = model.Gender,
                    BirthDate = model.BirthDate,
                    Country = model.Country,
                    Province = model.Province,
                    City = model.City,
                    Address = model.Address,
                    Mobile = model.Mobile,
                    Password = model.Password,
                    Username = model.Username,
                    PostalCode = model.PostalCode,
                    Photo = İmageHelper.StringToByte(model.Photo),
                    RegisterDate=DateTime.Now,
                };
                context.Customers.Add(YeniMusteri);
                context.SaveChanges();
                return Ok(new
                {
                    message = "customer has been added successfully"
                });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        //3.find -->müşterinin detaylarını görmek için filtreleyip bulunması
        [HttpGet] 
        [Route("[action]")]

        public IActionResult Details(int customerID) //müşteri ıdsını alıp detaylarını verecek 
        {
            try
            {
                using var context = new AnazonDbContext();
                var customer = context.Customers.Find(customerID);

                if(customer == null)
                {
                    return NotFound(new
                    {
                        message = "customer was not found"
                    });
                }

                return Ok(new
                {
                    customer.CustomerId,
                    customer.FirstName,
                    customer.LastName,
                    customer.Gender,
                    customer.BirthDate,
                    customer.Country,
                    customer.Province,
                    Photo=İmageHelper.ByteToString(customer.Photo),
                    customer.RegisterDate,
                    customer.Address,
                    customer.City,
                    customer.PostalCode,
                    customer.Username,
                    customer.Password,
                    customer.Mobile,


                });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //4.update
        [HttpPost]
        [Route("[action]")]

        public IActionResult Edit([FromBody] CustomerEditModel model)
        {
            try
            {
                using var context = new AnazonDbContext();
                var customer = context.Customers.Find(model.CustomerId);

                if (customer == null)
                {
                    return NotFound(new
                    {
                        Message = "Customer not found."
                    });     
                }
                customer.FirstName = model.FirstName;
                customer.LastName = model.LastName;
                customer.Gender = model.Gender;
                customer.BirthDate = model.BirthDate;
                customer.Country = model.Country;
                customer.Province = model.Province;
                customer.City = model.City;
                customer.Address = model.Address;
                customer.Photo= İmageHelper.StringToByte(model.Photo);
                customer.Country=model.Country;
                customer.Password = model.Password;
                customer.Mobile = model.Mobile;
                customer.Username =model.Username;
                
                context.SaveChanges();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
