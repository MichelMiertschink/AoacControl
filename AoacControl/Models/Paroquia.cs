using System.ComponentModel.DataAnnotations;

namespace AoacControl.Models
{
    public class Paroquia : ModelBase
    {
        public Paroquia()
        {
        }

        public Paroquia(int id, DateTime createdAt, DateTime updatedAt) : base(id, createdAt, updatedAt)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public Paroquia(string nome, UniaoParoquial uniaoParoquial, ICollection<Comunidade> comunidade)
        {
            Nome = nome;
            UniaoParoquial = uniaoParoquial;
            Comunidade = comunidade;
        }

        [Display (Name = "Paróquia")]
        public string Nome { get; set; }

        [Display(Name = "UP")]
        public UniaoParoquial UniaoParoquial { get; set; }
        [Display(Name = "UP")]
        public int UniaoParoquialId { get; set; }

        public ICollection<Comunidade> Comunidade { get; set; } = new List<Comunidade> ();
     

    }
}
