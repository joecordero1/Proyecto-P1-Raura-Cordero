using System.ComponentModel.DataAnnotations;

namespace Proyecto_P1_Raura_Cordero.Models
{
	public class Usuario
	{
		[Key]
		public int Cedula { get; set; }
		public string? Name { get; set; }
		public string? Email { get; set; }
		public string? Phone { get; set; }


		public int IdResena { get; set; }
		public Resena? Resena { get; set; }

	}
}
