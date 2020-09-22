namespace fichaTecnica.Models
{
    public class FichaTecnicaInsumo
    {
        public int Id { get; private set; }
        public int FichaTecnicaId { get; private set; }
        public FichaTecnica FichaTecnica { get; private set; }
        public int ItemInsumoId { get; private set; }
        public ItemInsumo ItemInsumo { get; private set; }
    }
}
