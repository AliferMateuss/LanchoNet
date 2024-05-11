using Entidades.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Negocios.Dtos.APIsDto.Pessoas;
using Negocios.Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Controllers
{
    [ApiController]
    [Route("api/Produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly ILogger<ProdutoController> _logger;
        private readonly ProdutoNegocio ProdutoNegocio;

        public ProdutoController(ILogger<ProdutoController> logger)
        {
            _logger = logger;
            ProdutoNegocio = new ProdutoNegocio();
        }

        [HttpPost("Salvar")]
        public void Salvarproduto(ProdutoDto dto)
        {
            this.ProdutoNegocio.Salvar(dto);
        }

        [HttpPost("Atualizar")]
        public void Atualizar(ProdutoDto dto)
        {
            this.ProdutoNegocio.Alterar(dto);
        }

        [HttpGet("RertornaPorId")]
        public ProdutoDto RetornaPorId(long id)
        {
            return ProdutoNegocio.BuscarPorId(id);
        }

        [HttpGet("RecuperarProdutos")]
        public List<ProdutoDto> RecuperarProdutos()
        {
            return ProdutoNegocio.RecuperarProdutos();
        }

        [HttpGet("Deletar")]
        public void Deletar(long id)
        {
            ProdutoNegocio.Deletar(id);
        }
    }
}
