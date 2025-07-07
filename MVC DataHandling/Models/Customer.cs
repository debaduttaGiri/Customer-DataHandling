using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_DataHandling.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustId { get; set; }

        [MaxLength(50)]
        [Column(TypeName ="Varchar")]
        public string? Name { get; set; }

        [Column(TypeName ="Money")]
        public Decimal? Balance { get; set; }

        [MaxLength(50)]
        [Column(TypeName ="Varchar")]
        public string? City { get; set; }

        public bool Status { get; set; }
    }
}
