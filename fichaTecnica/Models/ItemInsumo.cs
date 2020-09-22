using fichaTecnica.Data.Enums;

namespace fichaTecnica.Models
{
    public class ItemInsumo
    {
        public int Id { get; private set; }
        public string DescricaoItemInsumo { get; private set; }
        public double CustoUnitario { get; private set; }
        public double CustoTotal { get; private set; }
        public TipoDeUnidadeDeMedida TipoDeUnidadeDeMedida { get; private set; }
    }
}
