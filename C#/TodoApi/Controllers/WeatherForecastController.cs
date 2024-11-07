using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
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

    [HttpGet(Name = "GetWeatherForecast")]
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

[HttpGet("new-route")]
public IActionResult GetNewRoute()
{
    // Variable estática para mantener el contador de `hola`
    int holaCounter = 0;

    // Incrementa el contador en cada solicitud
    holaCounter++;

    // Genera un número aleatorio para `numero`
    int numeroAleatorio = Random.Shared.Next(1, 100);

    // Retorna el JSON con los valores solicitados
    return Ok(new
    {
        hola = holaCounter,
        numero = numeroAleatorio
    });
}


}



