using Entidades.Entidades;
using Entidades.Repositorios;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;

namespace Negocios.Repositorios
{
    public class CidadeRepositorio : RepositorioGenerico<Cidade, CidadeDto>
    {

        public List<CidadeDto> GetCidade(long idestado, string termo = "")
        {
            List<Cidade> resultado;
            if (!string.IsNullOrEmpty(termo))
            {
                resultado = _context.Cidades.Where(x => x.EstadoId == idestado && x.Nome.ToLower().StartsWith(termo.ToLower())).ToList();
            }
            else
            {
                resultado = _context.Cidades.Where(x => x.EstadoId == idestado).ToList() ;
            }


            MontaMapperEntidadeDto();

            return resultado.Select(x => _mapper.Map<CidadeDto>(x)).ToList();
        }
    }
}
