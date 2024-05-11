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
    [Route("api/TipoPagamento")]
    public class TipoPagamentoController : ControllerBase
    {
        private readonly ILogger<TipoPagamentoController> _logger;
        private readonly TipoPagamentoNegocio TipoPagamentoNegocio;

        public TipoPagamentoController(ILogger<TipoPagamentoController> logger)
        {
            _logger = logger;
            TipoPagamentoNegocio = new TipoPagamentoNegocio();
        }

        [HttpPost("Salvar")]
        public void Salvarproduto(TipoPagamentoDto dto)
        {
            this.TipoPagamentoNegocio.Salvar(dto);
        }

        [HttpPost("Atualizar")]
        public void Atualizar(TipoPagamentoDto dto)
        {
            this.TipoPagamentoNegocio.Alterar(dto);
        }

        [HttpGet("RertornaPorId")]
        public TipoPagamentoDto RetornaPorId(long id)
        {
            return TipoPagamentoNegocio.BuscarPorId(id);
        }

        [HttpGet("RecuperarTipoPagamentos")]
        public List<TipoPagamentoDto> RecuperarTipoPagamentos()
        {
            return TipoPagamentoNegocio.RecuperarTipoPagamentos();
        }

        [HttpGet("Deletar")]
        public void Deletar(long id)
        {
            TipoPagamentoNegocio.Deletar(id);
        }
    }
}
