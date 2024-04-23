using Entidades.Entidades;
using Entidades.Repositorios;

namespace Negocios.Repositorios
{
    public class EstadoRepositorio : RepositorioGenerico<Estado, EstadoDto>
    {

        public List<EstadoDto> GetPaginado(int pagina, int tamanhoPagina)
        {
            var query = _context.Estado.AsQueryable();

            var resultadosPaginados = query.Skip((pagina - 1) * tamanhoPagina)
                                           .Take(tamanhoPagina)
                                           .ToList();
            var totalResultados = query.Count();


            MontaMapperEntidadeDto();

            return resultadosPaginados.Select(x => _mapper.Map<EstadoDto>(x)).ToList();
        }
    }
}
