﻿//#define _DEBUG
#define _RELEASE

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OscorpGames {
	public partial class Minesweeper : Form, INotifyPropertyChanged {
		public event PropertyChangedEventHandler? PropertyChanged;

		private Bitmap FLAG = new Bitmap("../../../Minesweeper/Images/Flag.png");
		private Bitmap BOMB = new Bitmap("../../../Minesweeper/Images/Bomb.png");
		private Bitmap UNKNOWN = new Bitmap("../../../Minesweeper/Images/Unknown.png");
		private Bitmap NO_BOMB = new Bitmap("../../../Minesweeper/Images/None.png");
		private Bitmap ONE_BOMB = new Bitmap("../../../Minesweeper/Images/One.png");
		private Bitmap TWO_BOMB = new Bitmap("../../../Minesweeper/Images/Two.png");
		private Bitmap THREE_BOMB = new Bitmap("../../../Minesweeper/Images/Three.png");
		private Bitmap FOUR_BOMB = new Bitmap("../../../Minesweeper/Images/Four.png");
		private Bitmap FIVE_BOMB = new Bitmap("../../../Minesweeper/Images/Five.png");
		private Bitmap SIX_BOMB = new Bitmap("../../../Minesweeper/Images/Six.png");
		private Bitmap SEVEN_BOMB = new Bitmap("../../../Minesweeper/Images/Seven.png");
		private Bitmap EIGHT_BOMB = new Bitmap("../../../Minesweeper/Images/Eight.png");

		private const int MAX_WIDTH = 20;
		private const int MAX_HEIGHT = 10;

		private int width = 200, height = 100;
		private int numBombs = 30;
		private bool[,] mineField;
		private PictureBox[,] tiles;

		private bool gameEnded = false;

		private int CurrentNumBombs;
		public int currentNumBombs {
			get {
				return CurrentNumBombs;
			}
			set {
				CurrentNumBombs = value;
				NotifyPropertyChanged();
			}
		}

		public Minesweeper() {
			InitializeComponent();

			widthAdjuster.Minimum = 3;
			widthAdjuster.Maximum = MAX_WIDTH;
			widthAdjuster.Value = 16;
			heightAdjuster.Minimum = 3;
			heightAdjuster.Maximum = MAX_HEIGHT;
			heightAdjuster.Value = 9;
			bombAdjuster.Minimum = 1;
			bombAdjuster.Maximum = decimal.MaxValue;
			bombAdjuster.Value = 30;
			bombsLeftLabel.DataBindings.Add("Text", this, "currentNumBombs", false, DataSourceUpdateMode.OnPropertyChanged);

			StartGame();
		}

		private void StartGame() {
			if(width > MAX_WIDTH) {
				width = MAX_WIDTH;
			}
			if(height > MAX_HEIGHT) {
				height = MAX_HEIGHT;
			}

			gameEnded = false;
			winLoseLabel.Text = "";
			bombField.Controls.Clear();
			mineField = new bool[width, height];
			tiles = new PictureBox[width, height];

			currentNumBombs = numBombs;
			if(currentNumBombs > ((width * height) * 0.9f)) {
				currentNumBombs = (int) ((width * height) * 0.9f);
			}

			bombsLeftLabel.Text = currentNumBombs.ToString();

			Random random = new Random();
			for(int i = 0; i < currentNumBombs; i++) {
				int bombX = random.Next(0, width);
				int bombY = random.Next(0, height);

				if(mineField[bombX, bombY] == true) {
					i -= 1;
					continue;
				}

				mineField[bombX, bombY] = true;
			}

			for(int i = 0; i < width; i++) {
				for(int j = 0; j < height; j++) {
					PictureBox pictureBox = new PictureBox();

					pictureBox.Image = UNKNOWN;
					pictureBox.Size = new Size(NO_BOMB.Width, NO_BOMB.Height);
					pictureBox.Location = new Point(i * NO_BOMB.Width, j * NO_BOMB.Height);

					pictureBox.Click += tile_Click;

					bombField.Controls.Add(pictureBox);
					tiles[i, j] = pictureBox;
				}
			}

#if _DEBUG
			for(int i = 0; i < width; i++) {
				for(int j = 0; j < height; j++) {
					PictureBox tile = tiles[i, j];
					if(mineField[i, j]) {
						tile.Image = BOMB;
					} else {
						tile.Image = ConvertIntToBitmap(CountSurroundingBombs(new Point(tile.Location.X / 32, tile.Location.Y / 32)));
					}
				}
			}
#elif _RELEASE
			for(int i = 0; i < width; i++) {
				for(int j = 0; j < height; j++) {
					if(CountSurroundingBombs(new Point(i, j)) == 0 && !mineField[i, j]) {
						RevealEmptyTiles(new Point(i, j));
						return;
					}
				}
			}
#endif
		}

		private int CountSurroundingBombs(Point location) {
			PictureBox?[] tiles = GetSurroundingTiles(location);
			int bombs = 0;

			foreach(PictureBox? tile in tiles) {
				if(tile != null) {
					if(mineField[tile.Location.X / 32, tile.Location.Y / 32]) {
						bombs += 1;
					}
				}
			}

			return bombs;
		}

		private PictureBox?[] GetSurroundingTiles(Point location) {
			PictureBox?[] tiles = new PictureBox[8];

			for(int i = 0; i < 8; i++) {
				tiles[i] = null;
			}

			if(IsValidPosition(location.X, location.Y - 1)) {
				tiles[0] = this.tiles[location.X, location.Y - 1];
			}
			if(IsValidPosition(location.X + 1, location.Y - 1)) {
				tiles[1] = this.tiles[location.X + 1, location.Y - 1];
			}
			if(IsValidPosition(location.X + 1, location.Y)) {
				tiles[2] = this.tiles[location.X + 1, location.Y];
			}
			if(IsValidPosition(location.X + 1, location.Y + 1)) {
				tiles[3] = this.tiles[location.X + 1, location.Y + 1];
			}
			if(IsValidPosition(location.X, location.Y + 1)) {
				tiles[4] = this.tiles[location.X, location.Y + 1];
			}
			if(IsValidPosition(location.X - 1, location.Y + 1)) {
				tiles[5] = this.tiles[location.X - 1, location.Y + 1];
			}
			if(IsValidPosition(location.X - 1, location.Y)) {
				tiles[6] = this.tiles[location.X - 1, location.Y];
			}
			if(IsValidPosition(location.X - 1, location.Y - 1)) {
				tiles[7] = this.tiles[location.X - 1, location.Y - 1];
			}

			return tiles;
		}

		private bool IsValidPosition(int x, int y) {
			if((x < 0 || x >= width) || (y < 0 || y >= height)) {
				return false;
			}
			return true;
		}

		private void tile_Click(object sender, EventArgs e) {
			if(gameEnded) {
				return;
			}

			PictureBox tile = (PictureBox) sender;

			switch(((MouseEventArgs) e).Button) {
				case MouseButtons.Left:
					if(tile.Image != FLAG) {
						Point location = tile.Location;
						location.X /= 32;
						location.Y /= 32;

						if(mineField[location.X, location.Y]) {
							tile.Image = BOMB;
							GameLost();
						} else {
							tile.Image = ConvertIntToBitmap(CountSurroundingBombs(new Point(location.X, location.Y)));
							RevealEmptyTiles(location);
						}
					}
					break;
				case MouseButtons.Right:
					if(tile.Image == UNKNOWN && currentNumBombs != 0) {
						tile.Image = FLAG;
						currentNumBombs -= 1;
					} else if(tile.Image == FLAG) {
						tile.Image = UNKNOWN;
						currentNumBombs += 1;
					}
					break;
			}

			if(currentNumBombs == 0) {
				GameWon();
			}
		}

		private void GameLost() {
			gameEnded = true;
			winLoseLabel.Text = "Unfortunately, you have clicked on a bomb and have lost the game.";
		}

		private void GameWon() {
			if(AreFlagsCorrect()) {
				gameEnded = true;
				winLoseLabel.Text = "You have marked every bomb and won the game! Congratulations!";
			}
		}

		private bool AreFlagsCorrect() {
			for(int i = 0; i < width; i++) {
				for(int j = 0; j < height; j++) {
					if((mineField[i, j] && !(tiles[i, j].Image == FLAG)) || (!mineField[i, j] && tiles[i, j].Image == FLAG)) {
						return false;
					}
				}
			}

			return true;
		}

		private void RevealEmptyTiles(Point startingLocation) {
			if(CountSurroundingBombs(startingLocation) == 0) {
				PictureBox?[] tiles = GetSurroundingTiles(startingLocation);

				foreach(PictureBox? currentTile in tiles) {
					if(currentTile != null) {
						Point currentTileLocation = currentTile.Location;
						currentTileLocation.X /= 32;
						currentTileLocation.Y /= 32;
						if(!mineField[currentTileLocation.X, currentTileLocation.Y]) {
							if(CountSurroundingBombs(currentTileLocation) == 0 && currentTile.Image != NO_BOMB) {
								currentTile.Image = NO_BOMB;
								RevealEmptyTiles(currentTileLocation);
							} else {
								currentTile.Image = ConvertIntToBitmap(CountSurroundingBombs(currentTileLocation));
							}
						}
					}
				}
			}
		}

		private Bitmap ConvertIntToBitmap(int numBombs) {
			switch(numBombs) {
				case 1:
					return ONE_BOMB;
				case 2:
					return TWO_BOMB;
				case 3:
					return THREE_BOMB;
				case 4:
					return FOUR_BOMB;
				case 5:
					return FIVE_BOMB;
				case 6:
					return SIX_BOMB;
				case 7:
					return SEVEN_BOMB;
				case 8:
					return EIGHT_BOMB;
				default:
					return NO_BOMB;
			}
		}

		private void restartButton_Click(object sender, EventArgs e) {
			StartGame();
		}

		private void widthAdjuster_Updated(object sender, EventArgs e) {
			width = (int) ((NumericUpDown) sender).Value;
		}

		private void heightAdjuster_Updated(object sender, EventArgs e) {
			height = (int) ((NumericUpDown) sender).Value;
		}

		private void bombAdjuster_Updated(object sender, EventArgs e) {
			numBombs = (int) ((NumericUpDown) sender).Value;
		}

		private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
			if(PropertyChanged != null) {
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
