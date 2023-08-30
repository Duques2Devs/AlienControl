namespace Sistema_de_Controle_de_Alienígenas.Models
{
    public class PlanetaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Populacao { get; set; }
        public List<AlienModel> Habitantes { get; set; }

    }
}
