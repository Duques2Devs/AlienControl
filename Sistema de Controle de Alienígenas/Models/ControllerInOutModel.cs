namespace Sistema_de_Controle_de_Alienígenas.Models
{
    public class ControllerInOutModel
    {
        public int Id { get; set; }
        public int AlienId { get; set; }
        public int PlanetaId { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime DataEntrada { get; set; }
    }
}
