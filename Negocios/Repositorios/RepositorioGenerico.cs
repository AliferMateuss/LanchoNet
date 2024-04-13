using AutoMapper;
using Entidades.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Entidades.Repositorios
{

    public class RepositorioGenerico<TEntity, TDto> where TEntity : class
    {
        public readonly PostgresContexto _context;
        public readonly DbSet<TEntity> _dbSet;
        public IMapper _mapper;
        public TEntity _entity;
        public TDto _dto;

        public RepositorioGenerico(PostgresContexto context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<TEntity>();
        }

        public RepositorioGenerico() : this(new PostgresContexto()) { }

        public IEnumerable<TDto> BuscaTodos()
        {
            MontaMapperEntidadeDto();
            var entities = _dbSet.ToList();
            Dispose();
            return entities.Select(e => _mapper.Map<TEntity, TDto>(e));
        }

        public IEnumerable<TDto> GetByCondition(Expression<Func<TEntity, bool>> condition)
        {
            MontaMapperEntidadeDto();
            var entities = _dbSet.Where(condition).ToList();
            return entities.Select(e => _mapper.Map<TEntity, TDto>(e));
        }

        public TDto? BuscaPorId(object id)
        {
            MontaMapperEntidadeDto();
            var entity = _dbSet.Find(id);
            return _mapper.Map<TEntity, TDto>(entity);
        }

        public TEntity? BuscaPorIdEntity(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Salvar(TDto dto)
        {
            MontaMapperDtoEntidade();
            var entityToAdd = _mapper.Map<TEntity>(dto);
            _dbSet.Add(entityToAdd);
            Commit();
        }

        public void SalvarSemCommit(TDto dto)
        {
            MontaMapperDtoEntidade();
            var entityToAdd = _mapper.Map<TEntity>(dto);
            _dbSet.Add(entityToAdd);
        }

        public void Atualizar(TDto dto)
        {
            MontaMapperDtoEntidade();
            var entityToUpdate = _mapper.Map<TDto, TEntity>(dto);

            var existingEntity = _dbSet.Find(entityToUpdate.GetType().GetProperty("Id").GetValue(entityToUpdate));
            if (existingEntity != null)
            {
                _dbSet.Update(_mapper.Map(dto, existingEntity));
                Commit();
            }
        }

        public void AtualizarSemCommit(TDto dto)
        {
            MontaMapperDtoEntidade();
            var entityToUpdate = _mapper.Map<TDto, TEntity>(dto);
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public void DeletarComId(object id)
        {
            var entityToDelete = _dbSet.Find(id);
            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
            }
            Commit();
        }

        public void Deletar(TDto dto)
        {
            MontaMapperDtoEntidade();
            var entityToDelete = _mapper.Map<TDto, TEntity>(dto);
            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
            }
            Commit();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void MontaMapperDtoEntidade()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TDto, TEntity>();
            });
            _mapper = new Mapper(mapperConfig);
        }
        public void MontaMapperEntidadeDto()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TEntity, TDto>();
            });
            _mapper = new Mapper(mapperConfig);
        }
    }

}
