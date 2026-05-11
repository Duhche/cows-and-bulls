using System.ComponentModel.DataAnnotations;

namespace cows_and_bulls.Models
{
    public class Player
    {
        
            public int Id { get; set; }

            [Required]
            [StringLength(50)]
            public string Nickname { get; set; }

            [Required]
            [StringLength(255)]
            public string Password { get; set; }

        public ICollection<Game> Games { get; set; }
            = new List<Game>();

        

    }
}
