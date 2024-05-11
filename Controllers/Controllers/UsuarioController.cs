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
    [Route("api/Usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly UsuarioNegocio UsuarioNegocio;

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
            UsuarioNegocio = new UsuarioNegocio();
        }

        [HttpPost("Salvar")]
        public void Salvarproduto(UsuarioDto dto)
        {
            this.UsuarioNegocio.Salvar(dto);
        }

        [HttpPost("Atualizar")]
        public void Atualizar(UsuarioDto dto)
        {
            this.UsuarioNegocio.Alterar(dto);
        }

        [HttpGet("RertornaPorId")]
        public UsuarioDto RetornaPorId(long id)
        {
            return UsuarioNegocio.BuscarPorId(id);
        }

        [HttpGet("RecuperarUsuarios")]
        public List<UsuarioDto> RecuperarUsuarios()
        {
            return UsuarioNegocio.RecuperarUsuarios();
        }

        [HttpGet("Deletar")]
        public void Deletar(long id)
        {
            UsuarioNegocio.Deletar(id);
        }
    }
}
