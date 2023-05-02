using System.ComponentModel.DataAnnotations;


namespace Proyecto_P1_Raura_Cordero.Models
{
	public class Resena
	{
		[Key]
		public int IdResena { get; set; }
		public string? Titulo { get; set; }

        [DataType(DataType.Html)]
        public string? Texto { get; set; }

        public Pelicula? Pelicula { get; set; }
        public int IdPelicula { get; set; }
    }
}
