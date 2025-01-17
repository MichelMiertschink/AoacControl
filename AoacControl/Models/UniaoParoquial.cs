using System.ComponentModel.DataAnnotations;

namespace AoacControl.Models
{
    public class UniaoParoquial : ModelBase
    {
        [Display(Name = "União Paroquial")]
        public string Nome { get; set; }

        public ICollection<Paroquia> Paroquias { get; set; } = new List<Paroquia>();

    }
}
