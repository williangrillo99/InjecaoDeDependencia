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
            Transient1Count = transient.Contador,
            Transient1Id= transient.Id,
            
            Transient2Count = transient2.Contador,
            Transient2Id= transient2.Id,
            
            Scoped1Count = scoped.Contador,
            Scoped1Id = scoped.Id,

            Scoped2Count = scoped2.Contador,
            Scoped2Id = scoped2.Id, 
            
            Singleton1Count = singleton.Contador,
            Singleton1Id = singleton.Id,
            
            Singleton2Count = singleton2.Contador,
            Singleton2Id = singleton2.Id,

        });
    }
}