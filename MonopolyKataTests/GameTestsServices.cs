using MonopolyKata;

namespace MonopolyKataTests
{
    public static class GameTestsServices
    {
        public static Game CreateHorseCarGame()
        {
            return GameServices.Create(new[] { PlayerName.Horse, PlayerName.Car });
        }
    }
}
