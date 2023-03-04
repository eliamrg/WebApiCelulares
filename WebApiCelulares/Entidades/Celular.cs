namespace WebApiCelulares.Entidades
{
    public class Celular
    {
        public int ID { get; set; }
        public string Modelo { get; set;}
        public DateTime FechaLanzamiento { get; set; }
        public int MarcaID { get; set; }
        public Marca marca { get; set; }
    }
}
