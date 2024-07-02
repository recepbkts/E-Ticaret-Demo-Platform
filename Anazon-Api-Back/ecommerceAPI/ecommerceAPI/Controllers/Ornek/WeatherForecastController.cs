using ecommerceAPI.Models.Ornek;
using Microsoft.AspNetCore.Mvc;

/*
 
 API => Application Programming Interface (Uygulama Programlama Arayüzü)

 ***** CRUD Ýþlemleri: *****

 POST(Create) => Data yollayýp karþýlýðýnda data olarak cevap gelir(Front Data gönderip Back kontrol edip veritabanýnda kayýt eder)

 GET(Read) => Data getirir (Front istek gönderir ve Backten GET eder yani veri alýr)

 PUT(Update) => Güncelleme yapar yani veritabanýndaki veriyi yeniler.

 Delete(Delete) => Silme iþi yapar. 
 
 */

namespace ecommerceAPI.Controllers.Ornek
{
    [ApiController]  //Attribute bizim classýn yapýsýný kontroler yapýyor ve normal konsol sýnýfýndan farklý olduðunu gösteriyor
    [Route("[controller]")]  //Kök demektýr ve controller yazýsýný her bir constroller classýn isminin sonundan kaldýrýp uri yolu yapar. örnek: /WeatherForecast
    public class WeatherForecastController : ControllerBase //oyuzden her zaman controller kelimesi class isminin sonuna yazýlmalý. ve ayný zamanda ControllerBase classýndan miras almalýdýr.
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //Aþaðýdaki kod paketin ismine Action denir yani iþlem yapan methodu:

        [HttpGet(Name = "GetWeatherForecast")]  //HttpPost HttpGet HttpPut HttpDelete 
        public IEnumerable<WeatherForecast> Get()  
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
