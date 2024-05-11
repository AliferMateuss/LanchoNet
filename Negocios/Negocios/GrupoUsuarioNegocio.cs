using Entidades.Entidades;
using Negocios.Repositorios;

namespace Negocios.Negocios
{
    public class GrupoUsuarioNegocio
    {
        private readonly GrupoUsuarioRepositorio GrupoUsuarioRepositorio;

        public GrupoUsuarioNegocio()
        {
            GrupoUsuarioRepositorio = new GrupoUsuarioRepositorio();
        }

        public void Salvar(GrupoUsuarioDto dto)
        {
            GrupoUsuarioRepositorio.Salvar(dto);
        }
        public void Alterar(GrupoUsuarioDto dto)
        {
            GrupoUsuarioRepositorio.Atualizar(dto);
        }
        public void Deletar(long id)
        {
            GrupoUsuarioRepositorio.DeletarComId(id);
        }
        public GrupoUsuarioDto BuscarPorId(long id)
        {
            return GrupoUsuarioRepositorio.BuscaPorId(id);
        }


        public List<GrupoUsuarioDto> RecuperarGrupoUsuarios()
        {
            return GrupoUsuarioRepositorio.RecuperarGrupoUsuarios();
        }

    }
}
