using System.ComponentModel.DataAnnotations;

namespace testeapi.Models
{
    public class Usuario
    {
        [Key]
        public int idusuario { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
    }
}