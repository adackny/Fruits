using Microsoft.AspNetCore.Mvc;

namespace FruitsProducer.Api;


[Route("api/fruits")]
public class FruitsPriceController(FruitsService _fruitsService) : ControllerBase
{

    [HttpGet("{fruitName}")]
    public IAsyncEnumerable<FruitDto> Get(string fruitName)
    {
        return _fruitsService.AllAsync(fruitName);
    }
}
