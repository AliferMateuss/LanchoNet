using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Entidades;
using Negocios.Repositorios;

namespace Negocios.Negocios
{
    public class TipoPagamentoNegocio
    {
        private readonly TipoPagamentoRepositorio TipoPagamentoRepositorio;

        public TipoPagamentoNegocio()
        {
            TipoPagamentoRepositorio = new TipoPagamentoRepositorio();
        }

        public void Salvar(TipoPagamentoDto dto)
        {
            TipoPagamentoRepositorio.Salvar(dto);
        }
        public void Alterar(TipoPagamentoDto dto)
        {
            TipoPagamentoRepositorio.Atualizar(dto);
        }
        public void Deletar(long id)
        {
            TipoPagamentoRepositorio.DeletarComId(id);
        }
        public TipoPagamentoDto BuscarPorId(long id)
        {
            return TipoPagamentoRepositorio.BuscaPorId(id);
        }


        public List<TipoPagamentoDto> RecuperarTipoPagamentos()
        {
            return TipoPagamentoRepositorio.RecuperarTipoPagamentos();
        }

    }
}
