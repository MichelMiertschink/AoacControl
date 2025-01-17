using System.ComponentModel.DataAnnotations;

namespace AoacControl.Models
{
    public class Marca : ModelBase
    {
        [Display(Name = "Marca")]
        [Required(ErrorMessage = "Informe a marca")]
        public string Nome { get; set; }
    }
}
