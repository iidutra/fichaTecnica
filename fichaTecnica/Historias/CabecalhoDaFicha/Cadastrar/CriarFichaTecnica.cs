using fichaTecnica.Data;
using fichaTecnica.Models;
using System.Threading.Tasks;

namespace fichaTecnica.Historias.CabecalhoDaFicha.Cadastrar
{
    public class CriarFichaTecnica
    {
        private readonly DataContext contexto;
        public CriarFichaTecnica(DataContext contexto)
        {
            this.contexto = contexto;
        }
        public async Task Executar(CriarFichaTecnicaViewModel criarFichaTecnicaVm)
        {
            var ficha = new FichaTecnica(
                0,
                criarFichaTecnicaVm.DescricaoDaFichaTecnica,
                criarFichaTecnicaVm.Categoria,
                criarFichaTecnicaVm.RendimentoDaPorcao
                );

            await contexto.AddAsync(ficha);
            await contexto.SaveChangesAsync();
        }
    }
}
