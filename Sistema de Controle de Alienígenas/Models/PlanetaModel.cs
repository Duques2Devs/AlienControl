namespace Sistema_de_Controle_de_Alienígenas.Models
{
    public class PlanetaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public List<AlienModel> Habitantes { get; set; }
        public int Populacao { get; set; }


    }
}
