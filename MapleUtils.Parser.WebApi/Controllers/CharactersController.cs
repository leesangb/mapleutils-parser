using Microsoft.AspNetCore.Mvc;

namespace MapleUtils.Parser.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharactersController : ControllerBase
    {
        private readonly IMapleUtilsParser _parser;
        private readonly ILogger<CharactersController> _logger;

        public CharactersController(ILogger<CharactersController> logger, IMapleUtilsParser mapleUtilsParser)
        {
            _parser = mapleUtilsParser;
            _logger = logger;
        }

        [HttpGet("/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var character = await _parser.GetCharacterAsync(name);

            return Ok(character);
        }
    }
}