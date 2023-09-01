namespace Sistema_de_Controle_de_Alienígenas.Models
{
    public class RegistroModel
    {
        public int Id { get; set; }
        public int AlienId { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }

        public AlienModel Alien { get; set; }
    }
}
