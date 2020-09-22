﻿using fichaTecnica.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace fichaTecnica.Historias.CabecalhoDaFicha.Editar
{
    public class BuscarCabecalhoDaFichaTecnica
    {
        private readonly DataContext contexto;

        public BuscarCabecalhoDaFichaTecnica(DataContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task<EditarCabecalhoDaFichaViewModel> Executar(int id)
        {
            var fichaTecnica = await contexto.FichaTecnicas.FirstAsync(x => x.Id.Equals(id));

            var fichaTecnicaVm = new EditarCabecalhoDaFichaViewModel()
            {
                Id = fichaTecnica.Id,
                DescricaoDaFichaTecnica = fichaTecnica.DescricaoDaFichaTecnica,
                Categoria = fichaTecnica.Categoria,
                RendimentoDaPorcao = fichaTecnica.RendimentoDaPorcao
            };
            return fichaTecnicaVm;
        }
    }
}
