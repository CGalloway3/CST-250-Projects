using System.Diagnostics;
using WhackAMoleClassLibrary.Models;
using WhackAMoleClassLibrary.Services.GameLogicLayer;

namespace WhackAMoleTests
{
    public class WhackAMoleTests
    {
        [Fact]
        public void HighScore_AddsToScoreList()
        {
            Console.WriteLine("Test High Score");
            // Arrange
            GameLogic gameLogic = new GameLogic();
            GameScoreModel scoreModel = new GameScoreModel();

            scoreModel.Difficulty = ( 1, 1 );
            scoreModel.Score = 15;

            gameLogic.ClearList(); // Ensure list is clear before test

            // Act
            bool result = gameLogic.AddScoreToList(scoreModel);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void LowScore_DoesNotAddToScoreList()
        {
            Console.WriteLine("Test Low Score");
            // Arrange
            GameLogic gameLogic = new GameLogic();
            GameScoreModel scoreModel1 = new GameScoreModel();
            GameScoreModel scoreModel2 = new GameScoreModel();
            GameScoreModel scoreModel3 = new GameScoreModel();
            GameScoreModel scoreModel4 = new GameScoreModel();


            
            // add score 1
            scoreModel1.Difficulty = (1, 1);
            scoreModel1.Score = 15;
            gameLogic.AddScoreToList(scoreModel1);
            // add score 2
            scoreModel2.Difficulty = (1, 1);
            scoreModel2.Score = 20;
            gameLogic.AddScoreToList(scoreModel2);
            // add score 3
            scoreModel3.Difficulty = (1, 1);
            scoreModel3.Score = 11;
            gameLogic.AddScoreToList(scoreModel3);

            // Act
            scoreModel4.Difficulty = (1, 1);
            scoreModel4.Score = 10;
            bool result = gameLogic.AddScoreToList(scoreModel4);

            // Assert
            Assert.False(result);
        }
    }
}
