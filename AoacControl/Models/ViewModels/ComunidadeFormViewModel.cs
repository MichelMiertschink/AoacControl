namespace AoacControl.Models.ViewModels
{
    public class ComunidadeFormViewModel
    {
        public Comunidade Comunidade { get; set; }
        public ICollection<Paroquia> Paroquias { get; set; }
    }
}
