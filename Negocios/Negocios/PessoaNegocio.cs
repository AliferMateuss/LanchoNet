using Entidades.Entidades;
using Negocios.Dtos.APIsDto.Pessoas;
using Negocios.Repositorios;

namespace Negocios.Negocios
{
    public class PessoaNegocio
    {
        private readonly PessoaRepositorio PessoaRepositorio;
        private readonly EnderecoRepositorio EnderecoRepositorio;
        private readonly CidadeRepositorio CidadeRepositorio;

        public PessoaNegocio()
        {
            this.PessoaRepositorio = new PessoaRepositorio();
            this.EnderecoRepositorio = new EnderecoRepositorio(this.PessoaRepositorio._context);
            this.CidadeRepositorio = new CidadeRepositorio();
        }

        public void SalvarPessoa(PessoaDto dto)
        {
            if (dto.DataNascimento != null)
                dto.DataNascimento = dto.DataNascimento.Value.ToUniversalTime();

            if (dto.Enderecos == null || !dto.Enderecos.Any())
            {
                this.PessoaRepositorio.Salvar(dto);
            }
            else
            {
                var id = this.PessoaRepositorio.SalvarRetornandoId(dto);
                dto.Enderecos.ToList().ForEach(endereco =>
                {

                    endereco.IdPessoa = id;
                    this.EnderecoRepositorio.Salvar(endereco);
                });
                this.PessoaRepositorio.Commit();
            }
        }

        public void AlterarPessoa(PessoaDto dto)
        {
            if (dto.DataNascimento != null)
                dto.DataNascimento = dto.DataNascimento.Value.ToUniversalTime();

            var enderecos = this.EnderecoRepositorio.RecuperarTodosEnderecosPessoa(dto.Id.Value);

            if (dto.Enderecos == null || !dto.Enderecos.Any())
            {
                this.PessoaRepositorio.Atualizar(dto);
            }
            else
            {
                var id = this.PessoaRepositorio.AtualizaRetornandoId(dto);
                dto.Enderecos.ToList().ForEach(endereco =>
                {
                    var enderecoCadastrado = enderecos.FirstOrDefault(x => x.Id == endereco.Id);

                    if (enderecoCadastrado != null)
                    {
                        this.EnderecoRepositorio.Atualizar(endereco);
                    }
                    else
                    {
                        endereco.IdPessoa = id;
                        this.EnderecoRepositorio.Salvar(endereco);
                    }
                });

                enderecos.ForEach(endereco =>
                {
                    var ender = dto.Enderecos.FirstOrDefault(x => x.Id == endereco.Id);

                    if (ender == null)
                    {
                        EnderecoRepositorio.DeletarComId(endereco.Id);
                    }
                });

            }
        }

        public PessoaDto RecuperaPessoa(long id)
        {
            var dto = this.PessoaRepositorio.BuscaPorId(id);

            dto.DataNascimento = dto.DataNascimento.HasValue ? dto.DataNascimento.Value.ToLocalTime() : null;

            if (dto.Enderecos != null && dto.Enderecos.Any())
                dto.Enderecos.ToList().ForEach(x => 
                {
                    var cidade = CidadeRepositorio.RecuperaCidadePorId(x.IdCidade);
                    x.CidadeNome = cidade.Nome;
                    x.IdEstado = cidade.Idestado.Value;
                    
                 });

            return dto;
        }

        public ListaPessoasDto RecuperaPessoaPorFiltro(PessoaResumoDto dto, int pagina, int tamanhoPagina)
        {
            return PessoaRepositorio.GetPaginadoComFiltro(dto, pagina, tamanhoPagina);
        }

        public void DeletaPessoa(long id)
        {
            this.PessoaRepositorio.DeletarComId(id);
        }

        public ListaPessoasDto RecuperarPessoas(int pagina, int tamanhoPagina)
        {
            return PessoaRepositorio.GetPaginado(pagina, tamanhoPagina);
        }
    }
}
