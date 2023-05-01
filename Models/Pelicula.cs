using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Proyecto_P1_Raura_Cordero.Models
{
	public class Pelicula
	{
		[Key]
		public int IdPelicula { get; set; }
		public string? Nombre { get; set; }
		public string? Descripcion { get; set; }
		public string? Genero { get; set; }
		public int anio { get; set; }
		public string Poster { get; set; }


		public int IdResena { get; set; }
		public Resena? Resena { get; set; }
	}
}
