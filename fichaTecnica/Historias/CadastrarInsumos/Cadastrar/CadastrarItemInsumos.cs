using fichaTecnica.Data;
using fichaTecnica.Models;
using System.Threading.Tasks;

namespace fichaTecnica.Historias.CadastrarInsumos.Cadastrar
{
    public class CadastrarItemInsumos
    {
        private readonly DataContext contexto;

        public CadastrarItemInsumos(DataContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task Executar(CadastrarItemInsumosViewModel cadastrarItemInsumoVm)
        {
            var itemInsumo = new ItemInsumo(
               0,
               cadastrarItemInsumoVm.DescricaoItemInsumo,
               cadastrarItemInsumoVm.Quantidade,
               cadastrarItemInsumoVm.TipoDeUnidadeDeMedida,
               cadastrarItemInsumoVm.CustoUnitario,
               cadastrarItemInsumoVm.CustoTotal
                );
            await contexto.AddAsync(itemInsumo);
            await contexto.SaveChangesAsync();
        }
    }
}
