using ecommerceAPI.Models;
using ecommerceAPI.Models.Database;
using Microsoft.AspNetCore.Mvc;

namespace ecommerceAPI.Controllers
{
    [Route("[controller]")] //Bu sayfanın sonundan controller kelimesini kaldırır ve uri yolu olarak yollendirir.
    [ApiController] //Bu sayfanın bir Api kontroler olduğunu belirliyor.

    public class UserController : ControllerBase  //ControllerBase den miras alıyoruz
    {
        #region ********** 1.Adım **********
        /*
        [HttpPost] //front den --> backende veri gönderir.
        [Route("/signin")] //veri gönderen sayfanın uri adresi  --> localhost/user/signin
        public IActionResult UserPassSignin()
        {
            return Ok();  //http status code: 200 yani giriş başarılı olsun.
        }

        [HttpPost]
        [Route("/signout")]
        public IActionResult UserPassSignout()
        {
            return Ok();
        }
        */
        #endregion


        #region ********** 2.Adım **********
        /*
        [HttpPost]
        [Route("/signin")]
        public IActionResult UserPassSignin(string username, string password)
        {
            return Ok(new
            {
                UserName = username,
                Password = password
            });
        }
        */
        #endregion

        #region ********** 3.Adım **********
        /*
        [HttpPost]
        [Route("/signin")]
        public IActionResult UserPassSignin(SignInModel model)
        {
            return Ok(new
            {
                UserName = model.Username,
                Password = model.Password,
            });
        }
        */
        #endregion

        #region ********** 4.Adım **********
        /*
        //request (istek)  --> front den backende gönderilir (istek arayüzden arkaya gönderilir)

        //response (cevap) --> (action result) işlemin sonuçu backend'den fronta yollar.


        [HttpPost]
        [Route("/signin")]
        public IActionResult UserPassSignin([FromBody] SignInModel model) //[FromBody] yani verileri arayüzden alsın.
        {
            return Ok(new
            {
                UserName = model.Username,
                Password = model.Password,
            });
        }
        */
        #endregion

        #region ********** 5.Adım **********
        /*
        [HttpPost]
        [Route("/signin")]
        public IActionResult UserPassSignin([FromBody] SignInModel model)
        {
            if (string.IsNullOrEmpty(model.Username))
                return BadRequest(); //yanlış veya hatalı istek

            if (string.IsNullOrEmpty(model.Password))
                return BadRequest();

            if(model.Username =="admin" && model.Password =="123")
                return Ok();

            return NotFound();
        }
        */
        #endregion

        #region ********** 6.Adım **********
        /*
        [HttpPost]
        [Route("/signin")]
        public IActionResult UserPassSignin([FromBody] SignInModel model)
        {
            if (model.Username == "") //Modelde zaten null olamadığını söylediğimiz için kontroluna gerek yoktur.
                return BadRequest(new
                {
                    Message = "Username cannot be empty!"
                });

            if (model.Password == string.Empty)
                return BadRequest(new
                {
                    Message = "Password cannot be empty!"
                });

            if (model.Username == "admin" && model.Password == "123")
                return Ok();

            return NotFound(new
            {
                Message = "User account not found or your credentials might be wrong.",
                Status = 404
            });
        }


        [HttpPost]
        [Route("[action]")]
        public IActionResult SignUp([FromBody] SignUpModel model)
        {
            try
            {
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError); //server hatası
            }
        }
        */
        #endregion

        #region ********** Final **********

        //Müşteri giriş kontrolu:
        [HttpPost]
        [Route("Customer/signin")]
        public IActionResult CustomerSignin([FromBody] SignInModel model)
        {
            try
            {
                if (model.Username == "") //Modelde zaten null olamadığını söylediğimiz için kontroluna gerek yoktur.
                    return BadRequest(new
                    {
                        Message = "Username cannot be empty!"
                    });

                if (model.Password == string.Empty)
                    return BadRequest(new
                    {
                        Message = "Password cannot be empty!"
                    });


                using var context = new AnazonDbContext(); //veritabanını çağırıp kullanıyoruz.

                var user = context.Customers.FirstOrDefault(c => c.Username != null && c.Username.ToLower() == model.Username.ToLower() && c.Password != null && c.Password == model.Password);

                if (user != null) //Kullanıcı bulundu ve bilgilerini elde tut
                {
                    return Ok(new
                    {
                        //Username = user.Username,  .net 8 de artık kısa yazmayı öneriyor ve değişkenin adını yazmaya gerek yoktur. kendisi otomatik hafizada tutuyor.
                        user.Username,
                        user.FirstName,
                        user.LastName,
                    });

                }

                return NotFound(new
                {
                    Message = "User account not found or your credentials might be wrong.",
                    Status = 404
                });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Message = "The Server has encountered an unexpected Error"
                });
            }
        }


        //Çalışan giriş kontrolu:
        [HttpPost]
        [Route("Employee/signin")]
        public IActionResult EmployeeSignin([FromBody] SignInModel model)
        {
            try
            {
                if (model.Username == "")
                    return BadRequest(new
                    {
                        Message = "Username cannot be empty!"
                    });

                if (model.Password == string.Empty)
                    return BadRequest(new
                    {
                        Message = "Password cannot be empty!"
                    });


                using var context = new AnazonDbContext();

                var user = context.Employees.FirstOrDefault(c => c.Username != null && c.Username.ToLower() == model.Username.ToLower() && c.Password != null && c.Password == model.Password);

                if (user != null) //Kullanıcı bulundu ve bilgilerini elde tut
                {
                    return Ok(new
                    {
                        user.Username,
                        user.FirstName,
                        user.LastName,
                    });

                }

                return NotFound(new
                {
                    Message = "User account not found or your credentials might be wrong.",
                    Status = 404
                });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Message = "The Server has encountered an unexpected Error"
                });
            }
        }





        //Üye olmak için:

        [HttpPost]
        [Route("Customer/SignUp")]
        public IActionResult CustomerSignUp([FromBody] SignUpModel model)
        {
            try
            {
                using var context = new AnazonDbContext();
                var customer = new Customer
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Username = model.Username,
                    Password = model.Password,
                };
                context.Customers.Add(customer);

                context.SaveChanges();

                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError); //server hatası
            }
        }

        #endregion
    }
}
