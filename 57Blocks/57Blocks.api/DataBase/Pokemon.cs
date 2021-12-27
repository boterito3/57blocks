using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _57Blocks.api.DataBase
{
    [Table("Pokemons")]
    public class Pokemon
    {
        [Key]
        public Guid PokemonId { get; set; }
        public Guid CreatedBy { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }

    }
}
