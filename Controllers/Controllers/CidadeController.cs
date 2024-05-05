using Entidades.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Negocios.Negocios;

namespace Controllers.Controllers
{

    [ApiController]
    [Route("api/Cidade")]
    public class CidadeController : ControllerBase
    {

        private readonly ILogger<CidadeController> _logger;
        private readonly CidadeNegocio CidadeNegocio;

        public CidadeController(ILogger<CidadeController> logger)
        {
            _logger = logger;
            CidadeNegocio = new CidadeNegocio();
        }

        [HttpGet("BuscaCidadesPorEstadoETermo")]
        public List<CidadeDto> BuscaCidadesPorEstadoETermo( int estadoId, string termo)
        {
            return CidadeNegocio.BuscaCidadesPorEstadoETermo(termo, estadoId);
        }

        [HttpGet("RecuperaCidadePorId")]
        public CidadeDto RecuperaCidadePorId(long id)
        {
            return CidadeNegocio.RecuperaCidadePorId(id);
        }

    }
}
