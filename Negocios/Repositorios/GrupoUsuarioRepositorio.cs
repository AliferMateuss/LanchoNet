using AutoMapper;
using Entidades.Entidades;
using Entidades.Repositorios;


namespace Negocios.Repositorios
{
    public class GrupoUsuarioRepositorio : RepositorioGenerico<GrupoUsuario, GrupoUsuarioDto>
    {
        public override void Salvar(GrupoUsuarioDto dto)
        {

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GrupoUsuarioDto, GrupoUsuario>()
                    .ForMember(dest => dest.Usuarios, opt => opt.Ignore());
            });

            _mapper = new Mapper(mapperConfig);
            var entityToAdd = _mapper.Map<GrupoUsuario>(dto);
            _dbSet.Add(entityToAdd);
            Commit();
        }

        public GrupoUsuarioDto BuscaPorId(long id)
        {

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GrupoUsuario, GrupoUsuarioDto>()
                     .ForMember(dest => dest.Usuarios, opt => opt.Ignore());
            });

            _mapper = new Mapper(mapperConfig);

            var entity = _dbSet.Find(id);
            return _mapper.Map<GrupoUsuarioDto>(entity);
        }
        public void Atualizar(GrupoUsuarioDto dto)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GrupoUsuarioDto, GrupoUsuario>()
                    .ForMember(dest => dest.Usuarios, opt => opt.Ignore());
            });

            _mapper = new Mapper(mapperConfig);

            var entityToUpdate = _mapper.Map<GrupoUsuarioDto, GrupoUsuario>(dto);

            var entidade = _dbSet.Find(entityToUpdate.GetType().GetProperty("Id").GetValue(entityToUpdate));
            if (entidade != null)
            {
                _context.Entry(entidade).CurrentValues.SetValues(entityToUpdate);
                Commit();
            }
        }

        public List<GrupoUsuarioDto> RecuperarGrupoUsuarios()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GrupoUsuario, GrupoUsuarioDto>()
                     .ForMember(dest => dest.Usuarios, opt => opt.Ignore());
            });

            _mapper = new Mapper(mapperConfig);

            var entidades = _dbSet.ToList();

            var lista = new List<GrupoUsuarioDto>();

            entidades.ForEach(x => lista.Add(_mapper.Map<GrupoUsuarioDto>(x)));

            return lista;
        }
    }
}
