using fichaTecnica.Data;
using fichaTecnica.Historias.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace fichaTecnica.Historias.CabecalhoDaFicha.Editar
{
    public class EditarCabecalhoDaFicha
    {
        private readonly DataContext contexto;

        public EditarCabecalhoDaFicha(DataContext contexto)
        {
            this.contexto = contexto;
        }
        
        public async Task<Resultado> Executar(EditarCabecalhoDaFichaViewModel editarCabecalhoDaFichaVm)
        {
            if(editarCabecalhoDaFichaVm.Id == 0)
            {
                return Resultado.Erros(new string[] { "Ficha técnica não existente" });
            }
            var fichaTecnica = await contexto.FichaTecnicas
                .FirstOrDefaultAsync(x => x.Id.Equals(editarCabecalhoDaFichaVm.Id));

            if(fichaTecnica == null)
            {
                return Resultado.Erros(new string[] { "Ficha técnica não existente!" });
            }

            contexto.Update(fichaTecnica);
            await contexto.SaveChangesAsync();
            return Resultado.Sucesso();

        }
    }
}
