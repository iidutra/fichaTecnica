using System.ComponentModel.DataAnnotations;

namespace fichaTecnica.Historias.CabecalhoDaFicha.Editar
{
    public class EditarCabecalhoDaFichaViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string DescricaoDaFichaTecnica { get; set; }


        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Categoria { get; set; }

        [Display(Name = "Rendimento por porção")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public int RendimentoDaPorcao { get; set; }
    }
}
