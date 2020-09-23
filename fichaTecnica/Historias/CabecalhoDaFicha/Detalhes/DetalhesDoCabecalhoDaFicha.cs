using fichaTecnica.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace fichaTecnica.Historias.CabecalhoDaFicha.Detalhes
{
    public class DetalhesDoCabecalhoDaFicha
    {
        public readonly DataContext contexto;

        public DetalhesDoCabecalhoDaFicha(DataContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task<DetalhesDoCabecalhoDaFichaViewModel> Executar(int id)
        {
            var fichaTecnica = await contexto.FichaTecnicas.FirstAsync(x => x.Id.Equals(id));

            var detalhes = new DetalhesDoCabecalhoDaFichaViewModel()
            {
                Id = fichaTecnica.Id,
                DescricaoDaFichaTecnica = fichaTecnica.DescricaoDaFichaTecnica,
                Categoria = fichaTecnica.Categoria,
                RendimentoDaPorcao = fichaTecnica.RendimentoDaPorcao
            };

            return detalhes;
        }
    }
}
