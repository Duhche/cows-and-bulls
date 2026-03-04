using System.ComponentModel.DataAnnotations;

namespace cows_and_bulls.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public int Move { get; set; }

        [Required]
        public bool Win { get; set; }

      
        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
