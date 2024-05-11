using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Entidades;
using Negocios.Repositorios;

namespace Negocios.Negocios
{
    public class ProdutoNegocio
    {
        private readonly ProdutoRepositorio ProdutoRepositorio;

        public ProdutoNegocio()
        {
            ProdutoRepositorio = new ProdutoRepositorio();
        }

        public void Salvar(ProdutoDto dto)
        {
            ProdutoRepositorio.Salvar(dto);
        }
        public void Alterar(ProdutoDto dto)
        {
            ProdutoRepositorio.Atualizar(dto);
        }
        public void Deletar(long id)
        {
            ProdutoRepositorio.DeletarComId(id);
        }
        public ProdutoDto BuscarPorId(long id)
        {
            return ProdutoRepositorio.BuscaPorId(id);
        }


        public List<ProdutoDto> RecuperarProdutos()
        {
            return ProdutoRepositorio.RecuperarProdutos();
        }

    }
}
