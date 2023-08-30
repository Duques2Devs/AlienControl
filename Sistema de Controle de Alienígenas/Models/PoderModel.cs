namespace Sistema_de_Controle_de_Alienígenas.Models
{
    public class PoderModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<AlienModel> Aliens { get; set; }
    }
}
