using AutoMapper;
using Entidades.Entidades;
using Entidades.Repositorios;


namespace Negocios.Repositorios
{
    public class MesaRepositorio : RepositorioGenerico<Mesa, MesaDto>
    {
        public override void Salvar(MesaDto dto)
        {

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MesaDto, Mesa>()
                    .ForMember(dest => dest.Venda, opt => opt.Ignore());
            });

            _mapper = new Mapper(mapperConfig);
            var entityToAdd = _mapper.Map<Mesa>(dto);
            _dbSet.Add(entityToAdd);
            Commit();
        }

        public MesaDto BuscaPorId(long id)
        {

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Mesa, MesaDto>()
                    .ForMember(dest => dest.Venda, opt => opt.Ignore());
            });

            _mapper = new Mapper(mapperConfig);

            var entity = _dbSet.Find(id);
            return _mapper.Map<MesaDto>(entity);
        }
        public void Atualizar(MesaDto dto)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MesaDto, Mesa>()
                    .ForMember(dest => dest.Venda, opt => opt.Ignore());
            });

            _mapper = new Mapper(mapperConfig);

            var entityToUpdate = _mapper.Map<MesaDto, Mesa>(dto);

            var entidade = _dbSet.Find(entityToUpdate.GetType().GetProperty("Id").GetValue(entityToUpdate));
            if (entidade != null)
            {
                _context.Entry(entidade).CurrentValues.SetValues(entityToUpdate);
                Commit();
            }
        }

        public List<MesaDto> RecuperarMesas()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Mesa, MesaDto>()
                     .ForMember(dest => dest.Venda, opt => opt.Ignore());
            });

            _mapper = new Mapper(mapperConfig);

            var entidades = _dbSet.ToList();

            var lista = new List<MesaDto>();

            entidades.ForEach(x => lista.Add(_mapper.Map<MesaDto>(x)));

            return lista;
        }
    }
}
