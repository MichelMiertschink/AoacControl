using AoacControl.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace AoacControl.Models
{
    [Index(nameof(Patrimonio), IsUnique = true)]
    public class Instrumento : ModelBase
    {
        [Display (Name = "Patrimonio")]
        [Required (ErrorMessage = "O número de patrimonio é obrigatório")]
        public int Patrimonio { get; set; }

        [Display (Name = "Descrição")]
        [Required (ErrorMessage = "A descrição deve ser preenchida")]
        public string Descricao { get; set; }

        [Display (Name = "Tipo")]
        [Required(ErrorMessage = "Tipo é obrigatório")]
        public TipoInstrumento TipoInstrumento { get; set; }
                
        [Display (Name = "Doador")]
        [Required(ErrorMessage = "Fonte de doação é obrigatório")]
        public FonteDoacao FonteDoacao { get; set; }

        [Display (Name = "Valor")]
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        [Required(ErrorMessage = "Valor é obrigatório")]
        public decimal ValorInstrumento { get; set; }

        [Display (Name = "Marca")]
        public Marca Marca { get; set; }
        [Display(Name = "Marca")]
        public int MarcaId { get; set; }

        [Display(Name = "Observações")]
        public string? Observacoes { get; set; }
                
        [Display(Name = "Associado")]
        public int? AssociadoId { get; set; }
        public Associado? Associado { get; set; }
    }
}
