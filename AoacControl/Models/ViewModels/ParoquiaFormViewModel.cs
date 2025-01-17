namespace AoacControl.Models.ViewModels
{
    public class ParoquiaFormViewModel
    {
        public Paroquia Paroquia { get; set; }
        public ICollection<UniaoParoquial> UnioesParoquiais { get; set; }
    }
}
