using Entidades.Entidades;
using Negocios.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Negocios
{
    public class CidadeNegocio
    {
        private readonly CidadeRepositorio CidadeRepositorio;
        public CidadeNegocio()
        {
            CidadeRepositorio = new CidadeRepositorio();
        }

        public List<CidadeDto> BuscaCidadesPorEstadoETermo(string termo, long estadoId)
        {
            return CidadeRepositorio.GetCidade(estadoId, termo);
        }




        public CidadeDto RecuperaCidadePorId(long id)
        {
            return CidadeRepositorio.BuscaPorId(id);
        }
    }
}
