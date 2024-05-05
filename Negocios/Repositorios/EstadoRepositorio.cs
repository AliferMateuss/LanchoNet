using Entidades.Entidades;
using Entidades.Repositorios;

namespace Negocios.Repositorios
{
    public class EstadoRepositorio : RepositorioGenerico<Estado, EstadoDto>
    {

        public List<EstadoDto> RecuperaEstados()
        {
            var resultados = _context.Estado.ToList();


            MontaMapperEntidadeDto();

            return resultados.Select(x => _mapper.Map<EstadoDto>(x)).ToList();
        }
    }
}
