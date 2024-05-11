using Entidades.Entidades;
using Negocios.Repositorios;
namespace Negocios.Negocios
{
    public class CidadeNegocio
    {
        private readonly CidadeRepositorio CidadeRepositorio;
        public CidadeNegocio()
        {
            CidadeRepositorio = new CidadeRepositorio();
        }

        public List<CidadeDto> BuscaCidadesPorEstadoETermo(string termo, long estadoId)
        {
            return CidadeRepositorio.GetCidade(estadoId, termo);
        }




        public CidadeDto RecuperaCidadePorId(long id)
        {
            return CidadeRepositorio.BuscaPorId(id);
        }
    }
}
