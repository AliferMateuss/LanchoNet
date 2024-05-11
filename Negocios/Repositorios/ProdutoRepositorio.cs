using AutoMapper;
using Entidades.Entidades;
using Entidades.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using static System.Net.Mime.MediaTypeNames;


namespace Negocios.Repositorios
{
    public class ProdutoRepositorio : RepositorioGenerico<Produto, ProdutoDto>
    {
        public override void Salvar(ProdutoDto dto)
        {

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProdutoDto, Produto>()
                    .ForMember(dest => dest.Imagem, opt => opt.MapFrom(x => CopiarImagem(x)))
                    .ForMember(x => x.ItensCompras, opt => opt.Ignore())
                    .ForMember(x => x.ItensVenda, opt => opt.Ignore());
            });

            _mapper = new Mapper(mapperConfig);
            var entityToAdd = _mapper.Map<Produto>(dto);
            _dbSet.Add(entityToAdd);
            Commit();
        }

        public ProdutoDto BuscaPorId(long id)
        {

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Produto, ProdutoDto>()
                    .ForMember(dest => dest.Imagem, opt => opt.MapFrom(x => CriarFormFile(x.Imagem)))
                    .ForMember(x => x.ItensCompras, opt => opt.Ignore())
                    .ForMember(x => x.ItensVenda, opt => opt.Ignore());
            });

            _mapper = new Mapper(mapperConfig);

            var entity = _dbSet.Find(id);
            return _mapper.Map<ProdutoDto>(entity);
        }
        public void Atualizar(ProdutoDto dto)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProdutoDto, Produto>()
                    .ForMember(dest => dest.Imagem, opt => opt.MapFrom(x => CopiarImagemAtualizar(x)))
                    .ForMember(x => x.ItensCompras, opt => opt.Ignore())
                    .ForMember(x => x.ItensVenda, opt => opt.Ignore());
            });

            _mapper = new Mapper(mapperConfig);

            var entityToUpdate = _mapper.Map<ProdutoDto, Produto>(dto);

            var entidade = _dbSet.Find(entityToUpdate.GetType().GetProperty("Id").GetValue(entityToUpdate));
            if (entidade != null)
            {
                _context.Entry(entidade).CurrentValues.SetValues(entityToUpdate);
                Commit();
            }
        }

        public List<ProdutoDto> RecuperarProdutos()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Produto, ProdutoDto>()
                    .ForMember(dest => dest.Imagem, opt => opt.MapFrom(x => CriarFormFile(x.Imagem)))
                    .ForMember(x => x.ItensCompras, opt => opt.Ignore())
                    .ForMember(x => x.ItensVenda, opt => opt.Ignore());
            });

            _mapper = new Mapper(mapperConfig);

            var entidades = _dbSet.ToList();

            var lista = new List<ProdutoDto>();

            entidades.ForEach(x => lista.Add(_mapper.Map<ProdutoDto>(x)));

            return lista;
        }

        private string CriarFormFile(byte[] imagem)
        {
            return Convert.ToBase64String(imagem);
        }

        private byte[] CopiarImagemAtualizar(ProdutoDto source)
        {
            return Convert.FromBase64String(source.Imagem);
        }

        private byte[] CopiarImagem(ProdutoDto source)
        {
            var arr = source.Imagem.Split(',');
            return Convert.FromBase64String(arr[1]);
        }
    }
}
