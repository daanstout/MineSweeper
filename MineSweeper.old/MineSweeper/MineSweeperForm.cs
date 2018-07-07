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

namespace MineSweeper {
    public partial class MineSweeperForm : Form {
        public enum MouseModes {
            Click,
            Flag
        };

        private Field _field;

        public MineSweeperForm() {
            InitializeComponent();

            _field = new Field(20, 20, 10);

            minefieldPictureBox.Invalidate();
        }

        private void minefieldPictureBox_Paint(object sender, PaintEventArgs e) {
            base.OnPaint(e);
            {
                _field.Draw(e.Graphics);
            }
        }
    }
}
