namespace cows_and_bulls.ViewModels
{
    public class MainMenu
    {
        public string Title { get; set; }

        public List<string> Options { get; set; }

        public MainMenu()
        {
            Title = "Bletchley Code Breakers";

            Options = new List<string>
            {
                "Player vs Player (No repeats)",
                "Player vs Player (Repeats)",
                "Player vs Computer (No repeats)",
                "Player vs Computer (Repeats)",
                "Exit"
            };
        }
    }
}
