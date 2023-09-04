namespace Sistema_de_Controle_de_Alienígenas.Models
{
    public class AlienModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Altura { get; set; }
        public int Idade { get; set; }
        public string Corpo { get; set; }
        public bool EstaNaTerra { get; set; }
        public int PlanetaID { get; set; }
        public PlanetaModel Planeta { get; set; }
        public ICollection<AlienPoderModel> AlienPoderes { get; set; }
        public ICollection<RegistroModel> Registro { get; set; }
    }
}
