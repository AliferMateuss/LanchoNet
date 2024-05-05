using AutoMapper;
using Entidades.Entidades;
using Entidades.Repositorios;
using Microsoft.EntityFrameworkCore;
using Negocios.Dtos.APIsDto.Pessoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace Negocios.Repositorios
{
    public class PessoaRepositorio : RepositorioGenerico<Pessoa, PessoaDto>
    {

        public long SalvarRetornandoId(PessoaDto dto)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PessoaDto, Pessoa>().ForMember(x => x.Enderecos, opt => opt.Ignore())
                .ForMember(x => x.Usuarios, opt => opt.Ignore())
                .ForMember(x => x.Venda, opt => opt.Ignore())
                .ForMember(x => x.Compras, opt => opt.Ignore())
                .ForMember(x => x.ContasAReceber, opt => opt.Ignore());
            });

            _mapper = new Mapper(mapperConfig);

            var entityToAdd = _mapper.Map<Pessoa>(dto);
            _dbSet.Add(entityToAdd);
            Commit();
            return entityToAdd.Id.Value;
        }

        public PessoaDto BuscaPorId(long id)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Endereco, EnderecoDto>();
                cfg.CreateMap<Pessoa, PessoaDto>();
            });

            _mapper = new Mapper(mapperConfig);
            var entidade = _context.Pessoas.Include(x => x.Enderecos).Where(x => x.Id == id).FirstOrDefault();
            return _mapper.Map<PessoaDto>(entidade);
        }

        public ListaPessoasDto GetPaginado(int pagina, int tamanhoPagina)
        {
            var query = _context.Pessoas.AsQueryable();

            var resultadosPaginados = query.Skip((pagina - 1) * tamanhoPagina)
                                           .Take(tamanhoPagina)
                                           .ToList();
            var totalResultados = query.Count();

            var dto = new ListaPessoasDto();

            dto.Quantidade = totalResultados;

            dto.ListaPessoas = new List<PessoaResumoDto>();

            MontaMapperEntidadeDto();

            resultadosPaginados.ForEach(x => dto.ListaPessoas.Add(MontaPessoaResumo(x)));

            return dto;
        }


        public ListaPessoasDto GetPaginadoComFiltro(PessoaResumoDto dto, int pagina, int tamanhoPagina)
        {
            var query = _context.Pessoas.AsQueryable();


            if (string.IsNullOrEmpty(dto.Nome))
                query = query.Where(x => x.Nome.ToLower().StartsWith(dto.Nome) || x.RazaoSocial.ToLower().StartsWith(dto.Nome));


            if (string.IsNullOrEmpty(dto.Documento))
            {
                if (dto.Documento.Length == 11)
                    query = query.Where(x => x.Cpf.Equals(dto.Documento));
                else if (dto.Documento.Length == 14)
                    query = query.Where(x => x.Cnpj.Equals(dto.Documento));
            }

            if (dto.Cliente)
                query = query.Where(x => x.Cliente == true);

            if (dto.Fornecedor)
                query = query.Where(x => x.Fornecedor == true);

            if (dto.Funcionario)
                query = query.Where(x => x.Funcionario == true);



            var resultadosPaginados = query.Skip((pagina - 1) * tamanhoPagina)
                                           .Take(tamanhoPagina)
                                           .ToList();
            var totalResultados = query.Count();



            var dtoPessoas = new ListaPessoasDto();

            dtoPessoas.Quantidade = totalResultados;

            dtoPessoas.ListaPessoas = new List<PessoaResumoDto>();

            MontaMapperEntidadeDto();

            resultadosPaginados.ForEach(x => dtoPessoas.ListaPessoas.Add(MontaPessoaResumo(x)));

            return dtoPessoas;
        }

        public long AtualizaRetornandoId(PessoaDto dto)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PessoaDto, Pessoa>().ForMember(x => x.Enderecos, opt => opt.Ignore())
                .ForMember(x => x.Usuarios, opt => opt.Ignore())
                .ForMember(x => x.Venda, opt => opt.Ignore())
                .ForMember(x => x.Compras, opt => opt.Ignore())
                .ForMember(x => x.ContasAReceber, opt => opt.Ignore());
            });

            _mapper = new Mapper(mapperConfig);

            var entidade = _mapper.Map<Pessoa>(dto);
            entidade = _dbSet.Find(entidade.GetType().GetProperty("Id").GetValue(entidade));
            if (entidade != null)
            {
                _dbSet.Update(_mapper.Map(dto, entidade));
                Commit();
            }
            return entidade.Id.Value;
        }


        private PessoaResumoDto MontaPessoaResumo(Pessoa pessoa)
        {
            var dto = new PessoaResumoDto();
            dto.Id = pessoa.Id.Value;
            dto.Documento = !string.IsNullOrEmpty(pessoa.Cpf) ? pessoa.Cpf : pessoa.Cnpj;
            dto.Nome = !string.IsNullOrEmpty(pessoa.Nome) ? pessoa.Nome : pessoa.RazaoSocial;
            dto.Cliente = pessoa.Cliente;
            dto.Funcionario = pessoa.Funcionario;
            dto.Fornecedor = pessoa.Fornecedor;
            return dto;
        }
    }
}
