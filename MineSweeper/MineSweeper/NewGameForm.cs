using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper {
    /// <summary>
    /// Allows the player to customize their field
    /// </summary>
    public partial class NewGameForm : Form {
        #region Variables
        /// <summary>
        /// The width of the field
        /// </summary>
        public static int width = 20;
        /// <summary>
        /// The height of the field
        /// </summary>
        public static int height = 20;
        /// <summary>
        /// The number of bombs
        /// </summary>
        public static int bombs = 80;
        /// <summary>
        /// Whether we pressed new game of cancel
        /// </summary>
        public bool newGame;
        #endregion

        #region Constructors
        /// <summary>
        /// Simple constructor
        /// </summary>
        public NewGameForm() {
            InitializeComponent();

            widthNumeric.Value = width;
            heightNumeric.Value = height;
            bombsNumeric.Value = bombs;
        }
        #endregion

        #region Events
        private void widthNumeric_ValueChanged(object sender, EventArgs e) {
            bombsNumeric.Maximum = widthNumeric.Value * heightNumeric.Value * (Decimal)0.5;
            if (bombsNumeric.Value >= bombsNumeric.Maximum)
                bombsNumeric.Value = bombsNumeric.Value / 5;

            width = (int)widthNumeric.Value;
            bombs = (int)bombsNumeric.Value;
        }

        private void heightNumeric_ValueChanged(object sender, EventArgs e) {
            bombsNumeric.Maximum = widthNumeric.Value * heightNumeric.Value * (Decimal)0.5;
            if (bombsNumeric.Value >= bombsNumeric.Maximum)
                bombsNumeric.Value = bombsNumeric.Value / 5;

            height = (int)heightNumeric.Value;
            bombs = (int)bombsNumeric.Value;
        }

        private void bombsNumeric_ValueChanged(object sender, EventArgs e) {
            bombs = (int)bombsNumeric.Value;
        }

        private void newGameButton_Click(object sender, EventArgs e) {
            newGame = true;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            newGame = false;
            Close();
        }
        #endregion
    }
}
