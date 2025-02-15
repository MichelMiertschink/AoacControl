﻿using AoacControl.Models.Enums;
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
        
        public Instrumento Instrumento { get; set; }
        public int InstrumentoID { get; set; }

        public Comunidade Comunidade { get; set; }
        public int ComunidadeID { get; set; }
        public Voz Voz { get; set; }
    }
}
