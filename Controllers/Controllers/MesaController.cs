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
    [Route("api/Mesa")]
    public class MesaController : ControllerBase
    {
        private readonly ILogger<MesaController> _logger;
        private readonly MesaNegocio MesaNegocio;

        public MesaController(ILogger<MesaController> logger)
        {
            _logger = logger;
            MesaNegocio = new MesaNegocio();
        }

        [HttpPost("Salvar")]
        public void Salvarproduto(MesaDto dto)
        {
            this.MesaNegocio.Salvar(dto);
        }

        [HttpPost("Atualizar")]
        public void Atualizar(MesaDto dto)
        {
            this.MesaNegocio.Alterar(dto);
        }

        [HttpGet("RertornaPorId")]
        public MesaDto RetornaPorId(long id)
        {
            return MesaNegocio.BuscarPorId(id);
        }

        [HttpGet("RecuperarMesas")]
        public List<MesaDto> RecuperarMesas()
        {
            return MesaNegocio.RecuperarMesas();
        }

        [HttpGet("Deletar")]
        public void Deletar(long id)
        {
            MesaNegocio.Deletar(id);
        }
    }
}
