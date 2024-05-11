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
    [Route("api/GrupoUsuario")]
    public class GrupoUsuarioController : ControllerBase
    {
        private readonly ILogger<GrupoUsuarioController> _logger;
        private readonly GrupoUsuarioNegocio GrupoUsuarioNegocio;

        public GrupoUsuarioController(ILogger<GrupoUsuarioController> logger)
        {
            _logger = logger;
            GrupoUsuarioNegocio = new GrupoUsuarioNegocio();
        }

        [HttpPost("Salvar")]
        public void Salvarproduto(GrupoUsuarioDto dto)
        {
            this.GrupoUsuarioNegocio.Salvar(dto);
        }

        [HttpPost("Atualizar")]
        public void Atualizar(GrupoUsuarioDto dto)
        {
            this.GrupoUsuarioNegocio.Alterar(dto);
        }

        [HttpGet("RertornaPorId")]
        public GrupoUsuarioDto RetornaPorId(long id)
        {
            return GrupoUsuarioNegocio.BuscarPorId(id);
        }

        [HttpGet("RecuperarGrupoUsuarios")]
        public List<GrupoUsuarioDto> RecuperarGrupoUsuarios()
        {
            return GrupoUsuarioNegocio.RecuperarGrupoUsuarios();
        }

        [HttpGet("Deletar")]
        public void Deletar(long id)
        {
            GrupoUsuarioNegocio.Deletar(id);
        }
    }
}
