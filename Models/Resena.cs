using System.ComponentModel.DataAnnotations;

namespace Proyecto_P1_Raura_Cordero.Models
{
	public class Resena
	{
		[Key]
		public int IdResena { get; set; }
		public string? Titulo { get; set; }
		public string? Texto { get; set; }

		public List<Pelicula>? Resenas { get; set; }

		public List<Usuario>? ResenaUsuario { get; set; }
	}
}
