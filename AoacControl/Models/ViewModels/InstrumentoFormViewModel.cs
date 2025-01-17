using AoacControl.Models.Enums;

namespace AoacControl.Models.ViewModels
{
    public class InstrumentoFormViewModel
    {
        public Instrumento Instrumento { get; set; }
        public ICollection<Associado> Associados { get; set; }

        public TipoInstrumento TipoInstrumento { get; set; }
        public FonteDoacao FonteDoacao { get; set; }
    }
}
