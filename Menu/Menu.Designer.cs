﻿namespace OscorpGames {
	partial class Menu {
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gameThreeButton = new Button();
            titleLabel = new Label();
            gameOneButton = new Button();
            gameTwoButton = new Button();
            gameFourButton = new Button();
            exitButton = new Button();
            creatorLabel1 = new Label();
            teamMemberLabel5 = new Label();
            teamMemberLabel4 = new Label();
            teamMemberLabel3 = new Label();
            teamMemberLabel2 = new Label();
            teamMemberLabel1 = new Label();
            SuspendLayout();
            // 
            // gameThreeButton
            // 
            gameThreeButton.Location = new Point(148, 279);
            gameThreeButton.Margin = new Padding(2);
            gameThreeButton.Name = "gameThreeButton";
            gameThreeButton.Size = new Size(132, 51);
            gameThreeButton.TabIndex = 0;
            gameThreeButton.Text = "Pac-Man";
            gameThreeButton.UseVisualStyleBackColor = true;
            gameThreeButton.Click += gameThreeButton_Click;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 40F, FontStyle.Regular, GraphicsUnit.Point);
            titleLabel.Location = new Point(178, 29);
            titleLabel.Margin = new Padding(2, 0, 2, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(322, 72);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "MINIGAMES";
            // 
            // gameOneButton
            // 
            gameOneButton.Location = new Point(148, 149);
            gameOneButton.Margin = new Padding(2);
            gameOneButton.Name = "gameOneButton";
            gameOneButton.Size = new Size(132, 51);
            gameOneButton.TabIndex = 2;
            gameOneButton.Text = "Minesweeper";
            gameOneButton.UseVisualStyleBackColor = true;
            gameOneButton.Click += gameOneButton_Click;
            // 
            // gameTwoButton
            // 
            gameTwoButton.Location = new Point(422, 149);
            gameTwoButton.Margin = new Padding(2);
            gameTwoButton.Name = "gameTwoButton";
            gameTwoButton.Size = new Size(132, 51);
            gameTwoButton.TabIndex = 3;
            gameTwoButton.Text = "Snake";
            gameTwoButton.UseVisualStyleBackColor = true;
            gameTwoButton.Click += gameTwoButton_Click;
            // 
            // gameFourButton
            // 
            gameFourButton.Location = new Point(422, 279);
            gameFourButton.Margin = new Padding(2);
            gameFourButton.Name = "gameFourButton";
            gameFourButton.Size = new Size(132, 51);
            gameFourButton.TabIndex = 4;
            gameFourButton.Text = "Tetris";
            gameFourButton.UseVisualStyleBackColor = true;
            gameFourButton.Click += gameFourButton_Click;
            // 
            // exitButton
            // 
            exitButton.Location = new Point(618, 457);
            exitButton.Margin = new Padding(2);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(78, 20);
            exitButton.TabIndex = 5;
            exitButton.Text = "Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // creatorLabel1
            // 
            creatorLabel1.AutoSize = true;
            creatorLabel1.Location = new Point(8, 367);
            creatorLabel1.Margin = new Padding(2, 0, 2, 0);
            creatorLabel1.Name = "creatorLabel1";
            creatorLabel1.Size = new Size(75, 15);
            creatorLabel1.TabIndex = 6;
            creatorLabel1.Text = "CREATED BY:";
            // 
            // teamMemberLabel5
            // 
            teamMemberLabel5.AutoSize = true;
            teamMemberLabel5.Location = new Point(8, 442);
            teamMemberLabel5.Margin = new Padding(2, 0, 2, 0);
            teamMemberLabel5.Name = "teamMemberLabel5";
            teamMemberLabel5.Size = new Size(112, 15);
            teamMemberLabel5.TabIndex = 8;
            teamMemberLabel5.Text = "GERARDO BARAJAS";
            // 
            // teamMemberLabel4
            // 
            teamMemberLabel4.AutoSize = true;
            teamMemberLabel4.Location = new Point(8, 427);
            teamMemberLabel4.Margin = new Padding(2, 0, 2, 0);
            teamMemberLabel4.Name = "teamMemberLabel4";
            teamMemberLabel4.Size = new Size(76, 15);
            teamMemberLabel4.TabIndex = 9;
            teamMemberLabel4.Text = "CURTIS LANE";
            // 
            // teamMemberLabel3
            // 
            teamMemberLabel3.AutoSize = true;
            teamMemberLabel3.Location = new Point(8, 412);
            teamMemberLabel3.Margin = new Padding(2, 0, 2, 0);
            teamMemberLabel3.Name = "teamMemberLabel3";
            teamMemberLabel3.Size = new Size(98, 15);
            teamMemberLabel3.TabIndex = 10;
            teamMemberLabel3.Text = "WYATT CROCKER";
            // 
            // teamMemberLabel2
            // 
            teamMemberLabel2.AutoSize = true;
            teamMemberLabel2.Location = new Point(8, 397);
            teamMemberLabel2.Margin = new Padding(2, 0, 2, 0);
            teamMemberLabel2.Name = "teamMemberLabel2";
            teamMemberLabel2.Size = new Size(106, 15);
            teamMemberLabel2.TabIndex = 11;
            teamMemberLabel2.Text = "SURYA NANDEESH";
            // 
            // teamMemberLabel1
            // 
            teamMemberLabel1.AutoSize = true;
            teamMemberLabel1.Location = new Point(8, 382);
            teamMemberLabel1.Margin = new Padding(2, 0, 2, 0);
            teamMemberLabel1.Name = "teamMemberLabel1";
            teamMemberLabel1.Size = new Size(87, 15);
            teamMemberLabel1.TabIndex = 12;
            teamMemberLabel1.Text = "COLLIN GREISS";
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(705, 484);
            Controls.Add(teamMemberLabel1);
            Controls.Add(teamMemberLabel2);
            Controls.Add(teamMemberLabel3);
            Controls.Add(teamMemberLabel4);
            Controls.Add(teamMemberLabel5);
            Controls.Add(creatorLabel1);
            Controls.Add(exitButton);
            Controls.Add(gameFourButton);
            Controls.Add(gameTwoButton);
            Controls.Add(gameOneButton);
            Controls.Add(titleLabel);
            Controls.Add(gameThreeButton);
            Margin = new Padding(2);
            Name = "Menu";
            Text = "Minigames";
            Load += MainMenu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button gameThreeButton;
		private Label titleLabel;
		private Button gameOneButton;
		private Button gameTwoButton;
		private Button gameFourButton;
		private Button exitButton;
		private Label creatorLabel1;
		private Label teamMemberLabel5;
		private Label teamMemberLabel4;
		private Label teamMemberLabel3;
		private Label teamMemberLabel2;
		private Label teamMemberLabel1;
	}
}