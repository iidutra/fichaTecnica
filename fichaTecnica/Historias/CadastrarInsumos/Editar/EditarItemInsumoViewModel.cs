using fichaTecnica.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace fichaTecnica.Historias.CadastrarInsumos.Editar
{
    public class EditarItemInsumoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string DescricaoItemInsumo { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public int Quantidade { get; set; }

        [Display(Name = "Tipo de unidade de medida")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public TipoDeUnidadeDeMedida TipoDeUnidadeDeMedida { get; set; }

        [Display(Name = "Custo unitário")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public double CustoUnitario { get; set; }

        [Display(Name = "Custo total")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public double CustoTotal { get; set; }
    }
}
