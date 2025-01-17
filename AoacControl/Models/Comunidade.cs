using System.ComponentModel.DataAnnotations;

namespace AoacControl.Models
{
    public class Comunidade : ModelBase
    {
        [Display (Name = "Comunidade")]
        public string Nome { get; set; }

        [Display (Name = "Paroquia")]
        public Paroquia Paroquia { get; set; }
        [Display(Name = "Paroquia")]
        public int ParoquiaId { get; set; }
    }
}
