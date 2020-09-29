using fichaTecnica.Data;
using fichaTecnica.Historias.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fichaTecnica.Historias.CabecalhoDaFicha.Editar
{
    public class EditarCabecalhoDaFicha
    {
        private readonly DataContext contexto;
        public Dictionary<string, string> Erros { get; private set; }
        public EditarCabecalhoDaFicha(DataContext contexto)
        {
            this.contexto = contexto;
            Erros = new Dictionary<string, string>();
        }

        public async Task<Resultado> Executar(EditarCabecalhoDaFichaViewModel editarCabecalhoDaFichaVm)
        {
            if(editarCabecalhoDaFichaVm.Id == 0)
            {
                return Resultado.Erros(new string[] { "Ficha técnica não encontrada!" });
            }

            var fichaTecnica = await contexto.FichaTecnicas.FirstOrDefaultAsync(x => x.Id.Equals(editarCabecalhoDaFichaVm.Id));

            if(fichaTecnica == null)
            {
                return Resultado.Erros(new string[] { "Ficha técnica não existente" });
            }
            contexto.Update(fichaTecnica);
            await contexto.SaveChangesAsync();
            return Resultado.Sucesso();
        }
    }
}
