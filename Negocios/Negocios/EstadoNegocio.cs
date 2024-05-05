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


        public List<EstadoDto> RecuperaEstados()
        {
            return EstadoRepositorio.RecuperaEstados();
        }
    }
}
