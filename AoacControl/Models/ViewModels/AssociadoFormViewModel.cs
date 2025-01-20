namespace AoacControl.Models.ViewModels
{
    public class AssociadoFormViewModel
    {
        public Associado Associado { get; set; }
        public ICollection<Comunidade> Comunidades { get; set; }
        public ICollection<Instrumento> Instrumentos { get; set; }
    }
}
