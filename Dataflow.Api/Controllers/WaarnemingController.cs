using System;
using System.Threading;
using System.Threading.Tasks;
using Dataflow.ResultStore;
using Microsoft.AspNetCore.Mvc;

namespace Dataflow.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WaarnemingController(WaarnemingCache cache) : ControllerBase
{
    [HttpGet("{id:guid}", Name = "GetWaarneming")]
    public async Task<Waarneming> Get([FromRoute] Guid id, CancellationToken ct)
    {
        return (await cache.GetAsync(id, ct))!;
    }
}
