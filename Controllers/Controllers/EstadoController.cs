using Entidades.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Negocios.Negocios;

namespace Controllers.Controllers
{

    [ApiController]
    [Route("api/Estado")]
    public class EstadoController : ControllerBase
    {

        private readonly ILogger<EstadoController> _logger;
        private readonly EstadoNegocio EstadoNegocio;

        public EstadoController(ILogger<EstadoController> logger)
        {
            _logger = logger;
            EstadoNegocio = new EstadoNegocio();
        }

        [HttpGet("BuscaPaginado")]
        public List<EstadoDto> BuscaPaginado( int pagina, int tamanhoPagina)
        {
            return EstadoNegocio.BuscaPaginado(pagina, tamanhoPagina);
        }
    }
}
