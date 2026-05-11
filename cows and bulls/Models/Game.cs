using System.ComponentModel.DataAnnotations;

namespace cows_and_bulls.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateTime { get; set; }


        [Required]
        [StringLength(4)]
        public string SecretNumber { get; set; }

        public int Attemps { get; set; } = 0;

        public bool IsFinished { get; set; } = false;
        
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        public int Move { get; set; }

        [Required] public int Moves { get; set; }[Required] public int Removed { get; set; }
        public bool Win { get; set; }

      
        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public ICollection<Guess> Guesses { get; set; } = new List<Guess>();    
    }
}
