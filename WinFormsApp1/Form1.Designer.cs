namespace my1st
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.circle = new System.Windows.Forms.RadioButton();
            this.rectangle = new System.Windows.Forms.RadioButton();
            this.parallelogram = new System.Windows.Forms.RadioButton();
            this.square = new System.Windows.Forms.RadioButton();
            this.startButton = new System.Windows.Forms.Button();
            this.spawnFigure = new System.Windows.Forms.Timer(this.components);
            this.scoreText = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.gameTimeLabel = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.level = new System.Windows.Forms.Label();
            this.numLevel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightBlue;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(20, 23);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1549, 1050);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // circle
            // 
            this.circle.AutoSize = true;
            this.circle.Checked = true;
            this.circle.Location = new System.Drawing.Point(1666, 379);
            this.circle.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.circle.Name = "circle";
            this.circle.Size = new System.Drawing.Size(79, 29);
            this.circle.TabIndex = 1;
            this.circle.TabStop = true;
            this.circle.Text = "Circle";
            this.circle.UseVisualStyleBackColor = true;
            this.circle.CheckedChanged += new System.EventHandler(this.circle_CheckedChanged);
            // 
            // rectangle
            // 
            this.rectangle.AutoSize = true;
            this.rectangle.Location = new System.Drawing.Point(1666, 443);
            this.rectangle.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.rectangle.Name = "rectangle";
            this.rectangle.Size = new System.Drawing.Size(113, 29);
            this.rectangle.TabIndex = 2;
            this.rectangle.Text = "Rectangle";
            this.rectangle.UseVisualStyleBackColor = true;
            this.rectangle.CheckedChanged += new System.EventHandler(this.rectangle_CheckedChanged);
            // 
            // parallelogram
            // 
            this.parallelogram.AutoSize = true;
            this.parallelogram.Location = new System.Drawing.Point(1666, 506);
            this.parallelogram.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.parallelogram.Name = "parallelogram";
            this.parallelogram.Size = new System.Drawing.Size(144, 29);
            this.parallelogram.TabIndex = 5;
            this.parallelogram.TabStop = true;
            this.parallelogram.Text = "Parallelogram";
            this.parallelogram.UseVisualStyleBackColor = true;
            this.parallelogram.CheckedChanged += new System.EventHandler(this.parallelogram_CheckedChanged);
            // 
            // square
            // 
            this.square.AutoSize = true;
            this.square.Location = new System.Drawing.Point(1666, 570);
            this.square.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.square.Name = "square";
            this.square.Size = new System.Drawing.Size(92, 29);
            this.square.TabIndex = 6;
            this.square.TabStop = true;
            this.square.Text = "Square";
            this.square.UseVisualStyleBackColor = true;
            this.square.CheckedChanged += new System.EventHandler(this.square_CheckedChanged);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Gray;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.startButton.Font = new System.Drawing.Font("Segoe Print", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.startButton.Location = new System.Drawing.Point(650, 500);
            this.startButton.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(308, 152);
            this.startButton.TabIndex = 7;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // spawnFigure
            // 
            this.spawnFigure.Interval = 3000;
            this.spawnFigure.Tick += new System.EventHandler(this.spawnFigure_Tick);
            // 
            // scoreText
            // 
            this.scoreText.Location = new System.Drawing.Point(0, 0);
            this.scoreText.Name = "scoreText";
            this.scoreText.Size = new System.Drawing.Size(100, 23);
            this.scoreText.TabIndex = 0;
            // 
            // scoreLabel
            // 
            this.scoreLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Bauhaus 93", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.scoreLabel.Location = new System.Drawing.Point(1591, 964);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(237, 91);
            this.scoreLabel.TabIndex = 9;
            this.scoreLabel.Text = "Score";
            this.scoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameTimeLabel
            // 
            this.gameTimeLabel.AutoSize = true;
            this.gameTimeLabel.Font = new System.Drawing.Font("Cooper Black", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gameTimeLabel.Location = new System.Drawing.Point(1609, 152);
            this.gameTimeLabel.MinimumSize = new System.Drawing.Size(200, 40);
            this.gameTimeLabel.Name = "gameTimeLabel";
            this.gameTimeLabel.Size = new System.Drawing.Size(200, 50);
            this.gameTimeLabel.TabIndex = 11;
            this.gameTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 1000;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // level
            // 
            this.level.AutoSize = true;
            this.level.Enabled = false;
            this.level.Font = new System.Drawing.Font("Snap ITC", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.level.Location = new System.Drawing.Point(1577, 42);
            this.level.MinimumSize = new System.Drawing.Size(100, 40);
            this.level.Name = "level";
            this.level.Size = new System.Drawing.Size(162, 57);
            this.level.TabIndex = 12;
            this.level.Text = "Level";
            this.level.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.level.Visible = false;
            // 
            // numLevel
            // 
            this.numLevel.AutoSize = true;
            this.numLevel.Enabled = false;
            this.numLevel.Font = new System.Drawing.Font("Snap ITC", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numLevel.Location = new System.Drawing.Point(1754, 45);
            this.numLevel.MinimumSize = new System.Drawing.Size(100, 50);
            this.numLevel.Name = "numLevel";
            this.numLevel.Size = new System.Drawing.Size(100, 51);
            this.numLevel.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1873, 1050);
            this.Controls.Add(this.numLevel);
            this.Controls.Add(this.level);
            this.Controls.Add(this.gameTimeLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.square);
            this.Controls.Add(this.parallelogram);
            this.Controls.Add(this.rectangle);
            this.Controls.Add(this.circle);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Form1";
            this.Text = "Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton circle;
        private System.Windows.Forms.RadioButton rectangle;
        private System.Windows.Forms.RadioButton parallelogram;
        private System.Windows.Forms.RadioButton square;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Timer spawnFigure;
        private System.Windows.Forms.Label scoreText;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label gameTimeLabel;
        private System.Windows.Forms.Label level;
        private System.Windows.Forms.Label numLevel;
    }
}