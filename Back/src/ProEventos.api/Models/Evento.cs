
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProEventos.api.Models
{
    public class Evento
    {
        public int EventoId { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Local { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public string DataEvento { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Tema { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int QtdPessoas { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Lote { get; set; }
    }
}