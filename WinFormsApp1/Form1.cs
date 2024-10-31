namespace my1st
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using GAMEMANAGER;
    using FIGURES;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        GameManager myManager = new GameManager();
        FigureList figureList = new FigureList();
        int curIndex = -1;
        int figureType = 0;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < figureList.NextIndex; i++)
            {
                if (figureList[i].isInside(e.X, e.Y))
                {
                    curIndex = i;
                    string s = e.Button.ToString();
                    if (s == "Left") //if Left button pressed - Remove
                    {
                        if (IsFigureMatching(i)) //if clicked in correct figure
                        {
                            figureList.Remove(curIndex);//remove the figure
                            curIndex = -1;
                            if (myManager.PopFigure()) // if level up
                            {
                                figureList.RemoveAll();//clear screen
                                pictureBox1.Invalidate();
                                PauseGame();
                                spawnFigure.Interval = myManager.GetInterval();//change timeleft
                                scoreLabel.Text = (myManager.TotalScore).ToString();
                                PopLevelUpMessage();
                            }
                            else // same level
                            {
                                pictureBox1.Invalidate();
                                scoreLabel.Text = (myManager.TotalScore).ToString();
                            }
                        }
                        else // in wrong figure
                        {
                            figureList.Remove(curIndex);
                            pictureBox1.Invalidate();
                            myManager.WrongFigure();
                            scoreLabel.Text = (myManager.TotalScore).ToString();
                        }
                    }
                    break;
                }
            }
        }

        private void PopLevelUpMessage()
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("Good Job!\nDo you want to continue?", "Level Up!", System.Windows.Forms.MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                StartGame();
            else // No
            {
                SaveGame();
                Environment.Exit(0);
            }
        }

        private bool IsFigureMatching(int index)
        {
            return (figureList[index] is myCircle && figureType == 0) ||
                   (figureList[index] is myRectangle && figureType == 1) ||
                   (figureList[index] is myParallelogram && figureType == 2) ||
                   (figureList[index] is mySquare && !(figureList[index] is myParallelogram) && !(figureList[index] is myRectangle) && figureType == 3);
        }

        private void StartGame()
        {
            figureList.RemoveAll();//clear screen
            pictureBox1.Invalidate();
            level.Visible = true;
            numLevel.Text = (myManager.Level).ToString();
            spawnFigure.Start();
            spawnFigure.Interval = myManager.GetInterval();
            gameTimer.Start();
        }

        private void PauseGame()
        {
            level.Visible = false;
            spawnFigure.Stop();
            gameTimer.Stop();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            figureList.DrawAll(g);
        }

        private void circle_CheckedChanged(object sender, EventArgs e)
        {
            figureType = 0;
        }

        private void rectangle_CheckedChanged(object sender, EventArgs e)
        {
            figureType = 1;
        }

        private void parallelogram_CheckedChanged(object sender, EventArgs e)
        {
            figureType = 2;
        }

        private void square_CheckedChanged(object sender, EventArgs e)
        {
            figureType = 3;
        }

        private void SaveGame()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog1.Filter = "model files (*.game)|*.game|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;//to check!!!!!!!!!!!!!!!!!!!
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, myManager);
                }
            }
        }

        private void LoadGame()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog1.Filter = "model files (*.game)|*.game|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Stream stream = File.Open(openFileDialog1.FileName, FileMode.Open);
                var binaryFormatter = new BinaryFormatter();
                myManager = (GameManager)binaryFormatter.Deserialize(stream);
                scoreLabel.Text = (myManager.TotalScore).ToString();
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Visible = false;
            startButton.Enabled = false;
            DialogResult result = System.Windows.Forms.MessageBox.Show("Do you want to continue the previous game?\n", "There is a open a game", System.Windows.Forms.MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                LoadGame();
            StartGame();
            scoreLabel.Text = (myManager.TotalScore).ToString();
        }

        private Figure GetFigure()
        {
            Random rnd = new Random();
            PointF spawnPoint;
            Figure figureToSpawn;
            float size = (float)rnd.NextDouble() * 60 + 35;
            int index = rnd.Next(0, 4);
            switch (index)
            {
                case (int)FIG.Circle:
                    figureToSpawn = new myCircle(0, 0, size);
                    spawnPoint = GetSpawnPoint(size, size);
                    break;
                case (int)FIG.Parallelogram:
                    figureToSpawn = new myParallelogram(0, 0, size / 2 + 4, size, 4);
                    spawnPoint = GetSpawnPoint(size / 2 + 4, size);
                    break;
                case (int)FIG.Rectangle:
                    figureToSpawn = new myRectangle(0, 0, size * 2, size);
                    spawnPoint = GetSpawnPoint(size * 2, size);
                    break;
                default: // case FIG.Square
                    figureToSpawn = new mySquare(0, 0, size);
                    spawnPoint = GetSpawnPoint(size, size);
                    break;
            }
            figureToSpawn.X = spawnPoint.X;
            figureToSpawn.Y = spawnPoint.Y;
            return figureToSpawn;
        }

        private PointF GetSpawnPoint(float sizeX, float sizeY)
        {
            Random rnd = new Random();
            PointF myPoint = new PointF(pictureBox1.Location.X + sizeX + (float)rnd.NextDouble() * (pictureBox1.Width - (2 * sizeX)), pictureBox1.Location.Y + sizeY + (float)rnd.NextDouble() * (pictureBox1.Height - (2 * sizeY)));
            return myPoint;
        }

        private void spawnFigure_Tick(object sender, EventArgs e)
        {
            if (myManager.Level >= 2)
            {
                figureList.RemoveAll();
                pictureBox1.Invalidate();
            }
            Figure figure = GetFigure();
            figureList[figureList.NextIndex] = figure;
            pictureBox1.Invalidate();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            myManager.TimeLeft -= (gameTimer.Interval) / 1000;
            if (myManager.TimeLeft <= 0)
            {
                PauseGame();
                if (myManager.GameOver())
                    StartGame();
                else
                    Environment.Exit(0);
                spawnFigure.Interval = myManager.GetInterval();
            }
            gameTimeLabel.Text = (myManager.TimeLeft).ToString();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < figureList.NextIndex; i++)
            {
                if (figureList[i].isInside(e.X, e.Y) && !(figureList[i].IsHighlighted) && IsFigureMatching(i))
                {
                    figureList[i].SwitchHighlight();
                    pictureBox1.Invalidate();
                    break;
                }
                else if (!(figureList[i].isInside(e.X, e.Y)) && (figureList[i].IsHighlighted))
                {
                    figureList[i].SwitchHighlight();
                    pictureBox1.Invalidate();
                    break;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Q:
                    circle.Checked = true;
                    circle_CheckedChanged(sender, e);
                    break;
                case Keys.W:
                    rectangle.Checked = true;
                    rectangle_CheckedChanged(sender, e);
                    break;
                case Keys.E:
                    parallelogram.Checked = true;
                    parallelogram_CheckedChanged(sender, e);
                    break;
                case Keys.R:
                    square.Checked = true;
                    square_CheckedChanged(sender, e);
                    break;
            }
        }
    }
}