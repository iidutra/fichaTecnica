namespace fichaTecnica.Models
{
    public class FichaTecnica
    {
        public FichaTecnica(int id, string descricaoDaFichaTecnica, string categoria, int rendimentoDaPorcao)
        {
            Id = id;
            DescricaoDaFichaTecnica = descricaoDaFichaTecnica;
            Categoria = categoria;
            RendimentoDaPorcao = rendimentoDaPorcao;
        }

        public int Id { get; private set; }
        public string DescricaoDaFichaTecnica { get; private set; }
        public string Categoria { get; private set; }
        public int RendimentoDaPorcao { get; private set; }

    }
}
