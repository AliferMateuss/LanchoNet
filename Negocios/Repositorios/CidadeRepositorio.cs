using AutoMapper;
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
                resultado = _context.Cidade.Where(x => x.EstadoId == idestado && x.Nome.ToLower().StartsWith(termo.ToLower())).ToList();
            }
            else
            {
                resultado = _context.Cidade.Where(x => x.EstadoId == idestado).ToList() ;
            }


            MontaMapperEntidadeDto();

            return resultado.Select(x => _mapper.Map<CidadeDto>(x)).ToList();
        }

        public CidadeDto RecuperaCidadePorId(long id)
        {
            var cidade = _context.Cidade.Where(x => x.Id == id).FirstOrDefault();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Cidade, CidadeDto>().ForMember(x => x.Enderecos, opt => opt.Ignore()).ForMember(x => x.Estado, opt => opt.Ignore()).ForMember(x => x.LatLon, opt => opt.Ignore())
                .ForMember(x => x.Idestado, opt => opt.MapFrom(x => x.EstadoId));
            });

            _mapper = new Mapper(mapperConfig);
            return _mapper.Map<CidadeDto>(cidade);
        }
    }
}
