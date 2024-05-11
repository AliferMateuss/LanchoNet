using AutoMapper;
using Entidades.Entidades;
using Entidades.Repositorios;


namespace Negocios.Repositorios
{
    public class TipoPagamentoRepositorio : RepositorioGenerico<TipoPagamento, TipoPagamentoDto>
    {
        public override void Salvar(TipoPagamentoDto dto)
        {

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TipoPagamentoDto, TipoPagamento>()
                    .ForMember(dest => dest.Venda, opt => opt.Ignore())
                    .ForMember(x => x.Compras, opt => opt.Ignore());
            });

            _mapper = new Mapper(mapperConfig);
            var entityToAdd = _mapper.Map<TipoPagamento>(dto);
            _dbSet.Add(entityToAdd);
            Commit();
        }

        public TipoPagamentoDto BuscaPorId(long id)
        {

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TipoPagamento, TipoPagamentoDto>()
                    .ForMember(dest => dest.Venda, opt => opt.Ignore())
                    .ForMember(x => x.Compras, opt => opt.Ignore());
            });

            _mapper = new Mapper(mapperConfig);

            var entity = _dbSet.Find(id);
            return _mapper.Map<TipoPagamentoDto>(entity);
        }
        public void Atualizar(TipoPagamentoDto dto)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TipoPagamentoDto, TipoPagamento>()
                    .ForMember(dest => dest.Venda, opt => opt.Ignore())
                    .ForMember(x => x.Compras, opt => opt.Ignore());
            });

            _mapper = new Mapper(mapperConfig);

            var entityToUpdate = _mapper.Map<TipoPagamentoDto, TipoPagamento>(dto);

            var entidade = _dbSet.Find(entityToUpdate.GetType().GetProperty("Id").GetValue(entityToUpdate));
            if (entidade != null)
            {
                _context.Entry(entidade).CurrentValues.SetValues(entityToUpdate);
                Commit();
            }
        }

        public List<TipoPagamentoDto> RecuperarTipoPagamentos()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TipoPagamento, TipoPagamentoDto>()
                     .ForMember(dest => dest.Venda, opt => opt.Ignore())
                     .ForMember(x => x.Compras, opt => opt.Ignore());
            });

            _mapper = new Mapper(mapperConfig);

            var entidades = _dbSet.ToList();

            var lista = new List<TipoPagamentoDto>();

            entidades.ForEach(x => lista.Add(_mapper.Map<TipoPagamentoDto>(x)));

            return lista;
        }
    }
}
