using Entidades.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Negocios.Dtos.APIsDto.Pessoas;
using Negocios.Negocios;
using Negocios.Repositorios;

namespace Controllers.Controllers
{
    [ApiController]
    [Route("api/Pessoas")]
    public class PessoasController : ControllerBase
    {
        private readonly ILogger<PessoasController> _logger;
        private readonly PessoaNegocio PessoaNegocio;

        public PessoasController(ILogger<PessoasController> logger)
        {
            _logger = logger;
            PessoaNegocio = new PessoaNegocio();
        }


        [HttpPost("SalvarPessoa")]
        public void SalvarPessoa(PessoaDto dto)
        {
            this.PessoaNegocio.SalvarPessoa(dto);
        }

        [HttpGet("RecuperarPessoas")]
        public ListaPessoasDto RecuperarPessoas(int pagina, int tamanhoPagina)
        {
            return PessoaNegocio.RecuperarPessoas(pagina, tamanhoPagina);
        }

        [HttpPost("RecuperaPessoaPorFiltro")]
        public ListaPessoasDto RecuperaPessoaPorFiltro(PessoaResumoDto dto, int pagina, int tamanhoPagina)
        {
            return PessoaNegocio.RecuperaPessoaPorFiltro(dto, pagina, tamanhoPagina);
        }

        [HttpPost("Atualizar")]
        public void Atualizar(PessoaDto dto)
        {
            PessoaNegocio.AlterarPessoa(dto);
        }

        [HttpGet("RetornaPessoaPorId")]
        public PessoaDto RetornaPessoaPorId(long id)
        {
            return PessoaNegocio.RecuperaPessoa(id);
        }

        [HttpGet("Deletar")]
        public void Deletar(long id)
        {
           PessoaNegocio.DeletaPessoa(id);
        }

    }
}
