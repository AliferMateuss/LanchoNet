using Entidades.Entidades;
using Negocios.Repositorios;

namespace Negocios.Negocios
{
    public class EstadoNegocio
    {
        private readonly EstadoRepositorio EstadoRepositorio;

        public EstadoNegocio()
        {
            this.EstadoRepositorio = new EstadoRepositorio();
        }


        public List<EstadoDto> BuscaPaginado(int pagina, int tamanho)
        {
            return EstadoRepositorio.GetPaginado(pagina, tamanho);
        }
    }
}
