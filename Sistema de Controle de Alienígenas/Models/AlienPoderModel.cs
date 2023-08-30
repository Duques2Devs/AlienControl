namespace Sistema_de_Controle_de_Alienígenas.Models
{
    public class AlienPoderModel
    {
        public int AlienId { get; set; }
        public int PoderId { get; set; }
        public AlienModel Alien { get; set; }
        public PoderModel Poder { get; set; }
    }
}
