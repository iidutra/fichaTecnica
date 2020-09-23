using fichaTecnica.Data;
using fichaTecnica.Historias.CabecalhoDaFicha.Cadastrar;
using fichaTecnica.Historias.CabecalhoDaFicha.Detalhes;
using fichaTecnica.Historias.CabecalhoDaFicha.Editar;
using fichaTecnica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Editar(int id)
        {
            var fichaTecnica = context.FichaTecnicas.Find(id);
            var montarFicha = EditarCabecalho(fichaTecnica);
            return View(montarFicha);
        }

        [HttpPost]
        public IActionResult Editar(EditarCabecalhoDaFichaViewModel editarCabecalhoDaFichaVm)
        {
            if (!ModelState.IsValid)
                return View();

            var fichaTecnica = context.FichaTecnicas.FirstOrDefault(x => x.Id == editarCabecalhoDaFichaVm.Id);
            fichaTecnica.AlterarDados(
                editarCabecalhoDaFichaVm.DescricaoDaFichaTecnica,
                editarCabecalhoDaFichaVm.Categoria,
                editarCabecalhoDaFichaVm.RendimentoDaPorcao
                );
            context.Update(fichaTecnica);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fichaTecnica = context.FichaTecnicas.FirstOrDefault(x => x.Id == id);

            if (fichaTecnica == null)
            {
                return NotFound();
            }
            return View(fichaTecnica);
        }
        public EditarCabecalhoDaFichaViewModel EditarCabecalho(FichaTecnica fichaTecnica)
        {
            return new EditarCabecalhoDaFichaViewModel()
            {
                Id = fichaTecnica.Id,
                DescricaoDaFichaTecnica = fichaTecnica.DescricaoDaFichaTecnica,
                Categoria = fichaTecnica.Categoria,
                RendimentoDaPorcao = fichaTecnica.RendimentoDaPorcao,
            };
        }

    }
}
