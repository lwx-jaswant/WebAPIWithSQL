using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPIWithSQL.Models
{
    public class tblUsers
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
