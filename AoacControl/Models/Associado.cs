using AoacControl.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace AoacControl.Models
{
    public class Associado : ModelBase
    {
        [Display (Name = "Nome do Associado")]
        public string NomeCompleto { get; set; }

        [Display (Name = "Celular")]
        [DataType(DataType.PhoneNumber)]
        [Required (ErrorMessage = "Informe um número de celular")]
        public string Celular { get; set; }

        [Display (Name ="E-mail")]
        [DataType (DataType.EmailAddress)]
        [Required (ErrorMessage = "Informe um e-mail válido")]
        public string email { get; set; }
<<<<<<< HEAD

        [Display(Name = "Instrumento")]
        public Instrumento? InstrumentoID { get; set; }

=======

        [Display(Name = "Instrumento")]
        public Instrumento Instrumento { get; set; }
        public int InstrumentoID { get; set; }

>>>>>>> 93c318e2768e4f0a82d1432633fc656dba373200
        [Display (Name = "Comunidade")]
        public Comunidade Comunidade { get; set; }
        [Display(Name = "Comunidade")]
        public int ComunidadeID { get; set; }
        
        [Display(Name = "Voz")]
        public Voz Voz { get; set; }
    }
}
