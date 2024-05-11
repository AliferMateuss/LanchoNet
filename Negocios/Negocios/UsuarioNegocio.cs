using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Entidades;
using Negocios.Repositorios;

namespace Negocios.Negocios
{
    public class UsuarioNegocio
    {
        private readonly UsuarioRepositorio UsuarioRepositorio;

        public UsuarioNegocio()
        {
            UsuarioRepositorio = new UsuarioRepositorio();
        }

        public void Salvar(UsuarioDto dto)
        {
            UsuarioRepositorio.Salvar(dto);
        }
        public void Alterar(UsuarioDto dto)
        {
            UsuarioRepositorio.Atualizar(dto);
        }
        public void Deletar(long id)
        {
            UsuarioRepositorio.DeletarComId(id);
        }
        public UsuarioDto BuscarPorId(long id)
        {
            return UsuarioRepositorio.BuscaPorId(id);
        }


        public List<UsuarioDto> RecuperarUsuarios()
        {
            return UsuarioRepositorio.RecuperarUsuarios();
        }

    }
}
