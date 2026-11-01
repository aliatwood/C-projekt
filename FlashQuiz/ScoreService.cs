using System.Collections.Generic;
using System.Linq;

namespace FlashQuiz
{
    // Hanterar och lagrar spelarnas resultat.
    public class ScoreService
    {
        // Innehåller information om en spelares quizresultat.
        public class ScoreModel
        {
            public string PlayerName { get; set; } = "";
            public string Difficulty { get; set; } = "";
            public int Score { get; set; }
            public int TotalQuestions { get; set; }
        }

        // Lista som lagrar alla sparade resultat.
        private readonly List<ScoreModel> _highscores = new();

        // Hämtar resultaten sorterade efter högst poäng och därefter spelarnamn.
        public List<ScoreModel> GetHighscores()
        {
            return _highscores
                .OrderByDescending(s => s.Score)
                .ThenBy(s => s.PlayerName)
                .ToList();
        }

        // Lägger till ett nytt resultat i topplistan.
        public void AddScore(string name, string difficulty, int score, int total)
        {
            _highscores.Add(new ScoreModel
            {
                PlayerName = name,
                Difficulty = difficulty,
                Score = score,
                TotalQuestions = total
            });
        }
    }
}