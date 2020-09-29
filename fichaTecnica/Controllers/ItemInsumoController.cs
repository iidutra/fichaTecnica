using fichaTecnica.Data;
using fichaTecnica.Historias.CadastrarInsumos.Cadastrar;
using fichaTecnica.Historias.CadastrarInsumos.Editar;
using fichaTecnica.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace fichaTecnica.Controllers
{
    public class ItemInsumoController : Controller
    {
        public readonly DataContext contexto;

        public ItemInsumoController(DataContext contexto)
        {
            this.contexto = contexto;
        }

        public IActionResult Index()
        {
            return View(contexto.ItemInsumos.ToList());
        }

        public IActionResult Cadastrar() => View();

        [HttpPost]
        public async Task<IActionResult> Cadastrar(
            [FromServices] CadastrarItemInsumos cadastrarItemInsumos,
            CadastrarItemInsumosViewModel cadastrarItemInsumosViewModel)
        {
            if (!ModelState.IsValid)
                return View(cadastrarItemInsumosViewModel);

            await cadastrarItemInsumos.Executar(cadastrarItemInsumosViewModel);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Editar(int id)
        {
            var itemInsumo = contexto.ItemInsumos.Find(id);
            var cadastrar = EditarCabecalho(itemInsumo);
            return View(cadastrar);
        }

        [HttpPost]
        public IActionResult Editar(EditarItemInsumoViewModel editarItemInsumoVm)
        {
            if (!ModelState.IsValid)
                return View();
            var itemInsumo = contexto.ItemInsumos.FirstOrDefault(x => x.Id == editarItemInsumoVm.Id);
            itemInsumo.AlterarDados(
                editarItemInsumoVm.DescricaoItemInsumo,
                editarItemInsumoVm.Quantidade,
                editarItemInsumoVm.TipoDeUnidadeDeMedida,
                editarItemInsumoVm.CustoUnitario,
                editarItemInsumoVm.CustoTotal
                );

            contexto.Update(itemInsumo);
            contexto.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Detalhes(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var itemInsumo = contexto.ItemInsumos.FirstOrDefault(x => x.Id == id);

            if(itemInsumo == null)
            {
                return NotFound();
            }

            return View(itemInsumo);
        }

        public EditarItemInsumoViewModel EditarCabecalho(ItemInsumo itemInsumo)
        {
            return new EditarItemInsumoViewModel()
            {
                Id = itemInsumo.Id,
                DescricaoItemInsumo = itemInsumo.DescricaoItemInsumo,
                Quantidade = itemInsumo.Quantidade,
                TipoDeUnidadeDeMedida = itemInsumo.TipoDeUnidadeDeMedida,
                CustoUnitario = itemInsumo.CustoUnitario,
                CustoTotal = itemInsumo.CustoTotal
            };
        }
    }
}
