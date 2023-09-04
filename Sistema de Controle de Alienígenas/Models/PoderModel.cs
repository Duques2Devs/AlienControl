namespace Sistema_de_Controle_de_Alienígenas.Models
{
    public class PoderModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public ICollection<AlienPoderModel>? AlienPoderes { get; set; }
    }
}
