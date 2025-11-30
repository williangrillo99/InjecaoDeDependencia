using InjecaoDeDependencia.Models;
using Microsoft.AspNetCore.Mvc;

namespace InjecaoDeDependencia.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(IServiceProvider provider) : ControllerBase
{
    [HttpGet("Metodo1")]
    public IActionResult Metodo1()
    {
        var singleton = provider.GetRequiredService<Singleton>();
        var scoped = provider.GetRequiredService<Scoped>();
        var transient = provider.GetRequiredService<Transient>();

        singleton.Contar();
        scoped.Contar();
        transient.Contar();

        return Ok(new
        {
            Scoped = scoped.Contador,
            Transient = transient.Contador,
            Singleton = singleton.Contador,
        });
    }
    
    [HttpGet("Metodo2")]
    public IActionResult Metodo2()
    {
        var singleton = provider.GetRequiredService<Singleton>();
        var scoped = provider.GetRequiredService<Scoped>();
        var transient = provider.GetRequiredService<Transient>();

        var singleton2 = provider.GetRequiredService<Singleton>();
        var scoped2 = provider.GetRequiredService<Scoped>();
        var transient2 = provider.GetRequiredService<Transient>();
        
        singleton2.Contar();
        scoped2.Contar();
        transient2.Contar();

        singleton.Contar();
        scoped.Contar();
        transient.Contar();
        
        return Ok(new
        {
            Scoped = scoped.Contador,
            Scoped2 = scoped2.Contador,

            Transient = transient.Contador,
            Transient2 = transient.Contador,

            Singleton = singleton.Contador,
            Singleton2 = singleton.Contador,

        });
    }
}