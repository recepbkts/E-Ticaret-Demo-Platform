using ecommerceAPI.Models.Ornek;
using Microsoft.AspNetCore.Mvc;

/*
 
 API => Application Programming Interface (Uygulama Programlama Aray�z�)

 ***** CRUD ��lemleri: *****

 POST(Create) => Data yollay�p kar��l���nda data olarak cevap gelir(Front Data g�nderip Back kontrol edip veritaban�nda kay�t eder)

 GET(Read) => Data getirir (Front istek g�nderir ve Backten GET eder yani veri al�r)

 PUT(Update) => G�ncelleme yapar yani veritaban�ndaki veriyi yeniler.

 Delete(Delete) => Silme i�i yapar. 
 
 */

namespace ecommerceAPI.Controllers.Ornek
{
    [ApiController]  //Attribute bizim class�n yap�s�n� kontroler yap�yor ve normal konsol s�n�f�ndan farkl� oldu�unu g�steriyor
    [Route("[controller]")]  //K�k demekt�r ve controller yaz�s�n� her bir constroller class�n isminin sonundan kald�r�p uri yolu yapar. �rnek: /WeatherForecast
    public class WeatherForecastController : ControllerBase //oyuzden her zaman controller kelimesi class isminin sonuna yaz�lmal�. ve ayn� zamanda ControllerBase class�ndan miras almal�d�r.
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

        //A�a��daki kod paketin ismine Action denir yani i�lem yapan methodu:

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
