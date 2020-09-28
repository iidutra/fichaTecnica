using fichaTecnica.Data.Enums;

namespace fichaTecnica.Models
{
    public class ItemInsumo
    {
        public ItemInsumo(int id, string descricaoItemInsumo, int quantidade, TipoDeUnidadeDeMedida tipoDeUnidadeDeMedida, double custoUnitario, double custoTotal)
        {
            Id = id;
            DescricaoItemInsumo = descricaoItemInsumo;
            Quantidade = quantidade;
            TipoDeUnidadeDeMedida = tipoDeUnidadeDeMedida;
            CustoUnitario = custoUnitario;
            CustoTotal = custoTotal;
        }

        public int Id { get; private set; }
        public string DescricaoItemInsumo { get; private set; }
        public int Quantidade { get; private set; }
        public TipoDeUnidadeDeMedida TipoDeUnidadeDeMedida { get; private set; }
        public double CustoUnitario { get; private set; }
        public double CustoTotal { get; private set; }
    }
}
