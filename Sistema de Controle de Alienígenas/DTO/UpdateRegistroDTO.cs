namespace Sistema_de_Controle_de_Alienígenas.DTO
{
    public class UpdateRegistroDTO
    {
        public int Id { get; set; }
        public int AlienId { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }
    }
}
