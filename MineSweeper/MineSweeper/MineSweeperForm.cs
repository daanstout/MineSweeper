using MineSweeper.Minefield;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MineSweeper.SolvingBot;

namespace MineSweeper {
    /// <summary>
    /// The Mine Sweeper form
    /// </summary>
    public partial class MineSweeperForm : Form {
        #region Enums
        /// <summary>
        /// The ways you can press with the mouse, normal clicking and flagging
        /// </summary>
        public enum MouseModes {
            Click,
            Flag
        };
        #endregion

        #region Static Variables
        /// <summary>
        /// The instance of the form
        /// </summary>
        private static MineSweeperForm _instance;
        /// <summary>
        /// Indicates if the game is over
        /// </summary>
        private static bool _gameOver;

        /// <summary>
        /// The instance of the form
        /// </summary>
        public static MineSweeperForm instance { get => _instance; }
        /// <summary>
        /// Indicates if the game is over
        /// </summary>
        public static bool gameOver { get => _gameOver; }
        #endregion

        #region Variables
        /// <summary>
        /// Indicates if shift is pressed
        /// </summary>
        private bool _shiftPressed = false;
        /// <summary>
        /// Time spent playing this round
        /// </summary>
        private float timeSpent = 0.0f;
        /// <summary>
        /// The minefield
        /// </summary>
        private Field _field;

        private MineSweeperBot bot;

        /// <summary>
        /// The minefield
        /// </summary>
        public Field field { get => _field; }
        #endregion

        #region Constructors
        /// <summary>
        /// Simple Constructor
        /// </summary>
        public MineSweeperForm() {
            _instance = this;
            InitializeComponent();
            timeSpentLabel.Text = timeSpent.ToString();
            bombsLeftLabel.Text = "0";
            int bombsLeftLabelOffset = TextRenderer.MeasureText("0", bombsLeftLabel.Font).Width + 20;
            bombsLeftLabel.Location = new Point(Size.Width - bombsLeftLabelOffset, bombsLeftLabel.Location.Y);
            newGameButton.Location = new Point((Size.Width - newGameButton.Size.Width) / 2, newGameButton.Location.Y);
        }
        #endregion

        #region Events
        private void minefieldPictureBox_Paint(object sender, PaintEventArgs e) {
            base.OnPaint(e);
            {
                if (_field != null)
                    _field.Draw(e.Graphics);
            }
        }

        private void minefieldPictureBox_MouseUp(object sender, MouseEventArgs e) {
            if (_field != null) {
                if (!_field.Click(_shiftPressed ? MouseModes.Flag : e.Button == MouseButtons.Right ? MouseModes.Flag : MouseModes.Click, e.Location.X, e.Location.Y)) { // See if we can succesfully click. The mode is Flag is shift is pressed or the right mouse button was pressed, else we just click
                    _gameOver = true;
                    minefieldPictureBox.Invalidate();
                    secondTimer.Stop();
                    DialogResult result = MessageBox.Show("You bombed this one\nNew Game?", "Game Over", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes) // If the player wants to start a new game, do so
                        NewGame();
                }

                if (_field.IsFinished) { // If the player finished, ask him if he wants to start a new game
                    minefieldPictureBox.Invalidate();
                    secondTimer.Stop();
                    DialogResult result = MessageBox.Show("You finished, Congrats!\nNew Game?", "You Win", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                        NewGame();
                }

                bombsLeftLabel.Text = _field.numActiveBombs.ToString();
                minefieldPictureBox.Invalidate();
            }
        }

        private void minefieldPictureBox_MouseDown(object sender, MouseEventArgs e) {
            if (_field != null)
                _field.MouseDown(e.Location.X, e.Location.Y);
        }

        private void secondTimer_Tick(object sender, EventArgs e) {
            timeSpent += (float)secondTimer.Interval / 1000;
            timeSpentLabel.Text = ((int)timeSpent).ToString();
        }

        private void newGameButton_Click(object sender, EventArgs e) {
            NewGame();
        }

        private void MineSweeperForm_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyValue) {
                case 16:
                    _shiftPressed = true;
                    break;
            }
        }

        private void MineSweeperForm_KeyUp(object sender, KeyEventArgs e) {
            //Console.WriteLine(e.KeyValue);
            switch (e.KeyValue) {
                case 16:
                    _shiftPressed = false;
                    break;
                //case 32:
                //    bot = new MineSweeperBot();
                //    botIntervalTimer.Start();
                //    break;
                case 66:
                    bot = new MineSweeperBot();
                    botIntervalTimer.Start();
                    break;
            }
        }

        private void botIntervalTimer_Tick(object sender, EventArgs e) {
            bot.doStep = true;
        }
        #endregion

        #region Functions
        /// <summary>
        /// Starts a new game
        /// </summary>
        private void NewGame() {
            secondTimer.Stop();
            NewGameForm form = new NewGameForm();
            form.ShowDialog();

            if (form.newGame) {
                _field = new Field(NewGameForm.width, NewGameForm.height, NewGameForm.bombs);
                bombsLeftLabel.Text = _field.numActiveBombs.ToString();
                minefieldPictureBox.Invalidate();
                secondTimer.Start();
                timeSpent = 0.0f;
                ResizeForm();
                _gameOver = false;
            } else if (_field != null)
                secondTimer.Start();
        }

        /// <summary>
        /// Resizes different controls
        /// </summary>
        private void ResizeForm() {
            if (_field == null)
                return;

            int paddingLRD = 20, paddingU = 70;
            int minWidth = 215, minHeight = 215;

            int width = _field.width * Tile.TILE_WIDTH, height = _field.height * Tile.TILE_HEIGHT;

            width = Math.Max(minWidth, width);
            height = Math.Max(minHeight, height);

            int formWidth = width + (paddingLRD * 2);
            int formHeight = height + paddingLRD + paddingU;

            int bombsLeftLabelOffset = TextRenderer.MeasureText(_field.numActiveBombs.ToString(), bombsLeftLabel.Font).Width + paddingLRD;

            Size = new Size(formWidth, formHeight);
            minefieldPictureBox.Size = new Size(width + 1, height + 1);
            bombsLeftLabel.Location = new Point(formWidth - bombsLeftLabelOffset, bombsLeftLabel.Location.Y);
            newGameButton.Location = new Point((formWidth - newGameButton.Size.Width) / 2, newGameButton.Location.Y);
        }

        /// <summary>
        /// Redraws the mine field
        /// </summary>
        public void Redraw() {
            minefieldPictureBox.Invalidate();
        }
        #endregion
    }
}
