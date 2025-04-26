using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EP_Borda.Models
{
    [Table("t_team")]
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? Nombre { get; set; }

        public ICollection<Assignment>? Assignments { get; set; }
    }
}
