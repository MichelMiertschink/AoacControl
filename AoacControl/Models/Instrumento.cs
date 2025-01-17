using AoacControl.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace AoacControl.Models
{
    public class Instrumento : ModelBase
    {
        [Display (Name = "Patrimonio")]
        [Required (ErrorMessage = "O número de patrimonio é obrigatório")]
        public int Patrimonio { get; set; }

        [Display (Name = "Descrição")]
        [Required (ErrorMessage = "A descrição deve ser preenchida")]
        public string Descricao { get; set; }

        [Display (Name = "Tipo")]
        public TipoInstrumento TipoInstrumento { get; set; }

        [Display (Name = "Observações")]
        public string Observacoes { get; set; }

        [Display (Name = "Doador")]
        public FonteDoacao FonteDoacao { get; set; }

        [Display (Name = "Valor")]
        public decimal ValorInstrumento { get; set; } = 0.00M;

    }
}
