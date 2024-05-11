using AutoMapper;
using Entidades.Entidades;
using Entidades.Repositorios;


namespace Negocios.Repositorios
{
    public class UsuarioRepositorio : RepositorioGenerico<Usuario, UsuarioDto>
    {
        public override void Salvar(UsuarioDto dto)
        {

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UsuarioDto, Usuario>()
                    .ForMember(dest => dest.Venda, opt => opt.Ignore())
                    .ForMember(x => x.Compras, opt => opt.Ignore());
            });

            _mapper = new Mapper(mapperConfig);
            var entityToAdd = _mapper.Map<Usuario>(dto);
            _dbSet.Add(entityToAdd);
            Commit();
        }

        public UsuarioDto BuscaPorId(long id)
        {

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Usuario, UsuarioDto>()
                    .ForMember(dest => dest.Venda, opt => opt.Ignore())
                    .ForMember(x => x.Compras, opt => opt.Ignore());
            });

            _mapper = new Mapper(mapperConfig);

            var entity = _dbSet.Find(id);
            return _mapper.Map<UsuarioDto>(entity);
        }
        public void Atualizar(UsuarioDto dto)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UsuarioDto, Usuario>()
                    .ForMember(dest => dest.Venda, opt => opt.Ignore())
                    .ForMember(x => x.Compras, opt => opt.Ignore());
            });

            _mapper = new Mapper(mapperConfig);

            var entityToUpdate = _mapper.Map<UsuarioDto, Usuario>(dto);

            var entidade = _dbSet.Find(entityToUpdate.GetType().GetProperty("Id").GetValue(entityToUpdate));
            if (entidade != null)
            {
                _context.Entry(entidade).CurrentValues.SetValues(entityToUpdate);
                Commit();
            }
        }

        public List<UsuarioDto> RecuperarUsuarios()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Usuario, UsuarioDto>()
                     .ForMember(dest => dest.Venda, opt => opt.Ignore())
                     .ForMember(x => x.Compras, opt => opt.Ignore());
            });

            _mapper = new Mapper(mapperConfig);

            var entidades = _dbSet.ToList();

            var lista = new List<UsuarioDto>();

            entidades.ForEach(x => lista.Add(_mapper.Map<UsuarioDto>(x)));

            return lista;
        }
    }
}
