namespace WebApiCelulares.Entidades
{
    public class Marca
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }

        public List<Celular> celulares { get; set; }= new List<Celular>();  
    }
}
