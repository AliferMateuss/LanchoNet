using AutoMapper;
using Entidades.Contexto;
using Entidades.Entidades;
using Entidades.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Repositorios
{
    public class EnderecoRepositorio: RepositorioGenerico<Endereco, EnderecoDto>
    {
        public EnderecoRepositorio(PostgresContexto contexto):base(contexto) { }


        public List<EnderecoDto> RecuperarTodosEnderecosPessoa(long id)
        {
            var resultado = new List<EnderecoDto>();
            var enderecos =  _context.Enderecos.Include(x => x.Cidade).Where(x => x.IdPessoa == id).ToList();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Endereco, EnderecoDto>().ForMember(x => x.Cidade, opt => opt.Ignore()).ForMember(x => x.Pessoa, opt => opt.Ignore());
            });

            _mapper = new Mapper(mapperConfig);

            if (enderecos != null || !enderecos.Any())
            {
                enderecos.ForEach(x => resultado.Add(_mapper.Map<EnderecoDto>(x)));
            }

            return resultado;
        }
    }
}
