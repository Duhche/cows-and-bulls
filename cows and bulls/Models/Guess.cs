

namespace cows_and_bulls.Models
{
    public class Guess
    {
        public int Id { get; set; }

        public string UserGuess { get; set; }

        public DateTime CreatedOn { get; set; }
            = DateTime.Now;

        public int Bulls { get; set; }

        public int Cows { get; set; }

        public int GameId { get; set; }

        public Game Game { get; set; }
    }
}
