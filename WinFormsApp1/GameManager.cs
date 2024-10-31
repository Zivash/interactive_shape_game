using System;
using System.Windows.Forms;
using SOUNDEFFECTS;
namespace GAMEMANAGER
{
    [Serializable]
    class GameManager
    {
        int scorePerFigure;
        int totalScore;
        int level;
        int scoreToLevelUp;
        int gameTime;
        int timeLeft;

        public GameManager() : this(1, 40)
        { }
        public GameManager(int level, int gameTime)
        {
            ResetGame(level, gameTime);
        }
        public int Level
        {
            get
            {
                return level;
            }
        }
        public int TotalScore
        {
            get
            {
                return totalScore;
            }
        }
        public int GameTime
        {
            get
            {
                return gameTime;
            }
        }
        public int TimeLeft
        {
            get
            {
                return timeLeft;
            }
            set
            {
                timeLeft = value;
            }
        }
        private void LevelUp()
        {
            level++;
            scorePerFigure = level * 10;
            scoreToLevelUp += level * 50;
            if (level <= 12)
                gameTime -= -2;
            else
                gameTime = 15;
            timeLeft = gameTime;
            SoundEffects sound = new SoundEffects();
            sound.Win();
        }
        private void UpdateScore()
        {
            totalScore += scorePerFigure;
        }
        public bool PopFigure()
        {
            SoundEffects sound = new SoundEffects();
            sound.Pop();
            UpdateScore();
            if (totalScore >= scoreToLevelUp)
            {
                LevelUp();
                return true;
            }
            return false;
        }
        public bool GameOver()
        {
            SoundEffects sound = new SoundEffects();
            sound.Lose();
            DialogResult result = System.Windows.Forms.MessageBox.Show("Do you want to try again?", "Game Over!", System.Windows.Forms.MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ResetGame();
                return true;
            }
            return false;
        }
        private void ResetGame(int level = 1, int gameTime = 40)
        {
            this.level = level;
            scorePerFigure = level * 10;
            scoreToLevelUp = level * 50;
            totalScore = 0;
            this.gameTime = timeLeft = gameTime;
        }
        public void WrongFigure()
        {
            SoundEffects sound = new SoundEffects();
            sound.Wrong();
            totalScore -= 5;
        }
        public int GetInterval()
        {
            if (Level > 0 && Level <= 3)
                return 3000;
            else if (Level > 3 && Level <= 7)
                return 2000;
            else if (Level > 7 && Level < 12)
                return 1500;
            else return 1000;
        }
    }
}