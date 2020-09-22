using fichaTecnica.Data;
using fichaTecnica.Historias.CabecalhoDaFicha.Cadastrar;
using fichaTecnica.Historias.CabecalhoDaFicha.Editar;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace fichaTecnica.Controllers
{
    public class FichaTecnicaController : BaseController
    {
        private readonly DataContext context;

        public FichaTecnicaController(DataContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(context.FichaTecnicas.ToList());
        }
        public IActionResult Cadastrar() => View();

        [HttpPost]
        public async Task<IActionResult> Cadastrar(
            [FromServices] CriarFichaTecnica criarFichaTecnica,
            CriarFichaTecnicaViewModel criarFichaTecnicaVm)
        {
            if (!ModelState.IsValid)
            {
                return View(criarFichaTecnicaVm);
            }
            await criarFichaTecnica.Executar(criarFichaTecnicaVm);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Editar([FromServices] BuscarCabecalhoDaFichaTecnica buscarCabecalhoDaFichaTecnica, int id)
        {
            var fichaTecnicaVm = await buscarCabecalhoDaFichaTecnica.Executar(id);
            return View(fichaTecnicaVm);
        }
        
        [HttpPost]
        public async Task<IActionResult> Editar([FromServices] EditarCabecalhoDaFicha editarCabecalhoDaFicha,
            EditarCabecalhoDaFichaViewModel editarCabecalhoDaFichaVm)
        {
            var resultado = await editarCabecalhoDaFicha.Executar(editarCabecalhoDaFichaVm);
            if(resultado.Sucedido)
            {
                NotificarSucesso();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                NotificarErros(resultado.erros);
                return View(editarCabecalhoDaFichaVm);
            }
        }
    }
}
