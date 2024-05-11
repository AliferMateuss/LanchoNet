using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Entidades;
using Negocios.Repositorios;

namespace Negocios.Negocios
{
    public class MesaNegocio
    {
        private readonly MesaRepositorio MesaRepositorio;

        public MesaNegocio()
        {
            MesaRepositorio = new MesaRepositorio();
        }

        public void Salvar(MesaDto dto)
        {
            MesaRepositorio.Salvar(dto);
        }
        public void Alterar(MesaDto dto)
        {
            MesaRepositorio.Atualizar(dto);
        }
        public void Deletar(long id)
        {
            MesaRepositorio.DeletarComId(id);
        }
        public MesaDto BuscarPorId(long id)
        {
            return MesaRepositorio.BuscaPorId(id);
        }


        public List<MesaDto> RecuperarMesas()
        {
            return MesaRepositorio.RecuperarMesas();
        }

    }
}
