using MineSweeper.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MineSweeper.MineSweeperForm;

namespace MineSweeper.Minefield {
    /// <summary>
    /// The tiles on the field
    /// </summary>
    public class Tile {
        #region Static Variables
        /// <summary>
        /// The width of a tile
        /// </summary>
        public static readonly int TILE_WIDTH = 15;
        /// <summary>
        /// The height of a tile
        /// </summary>
        public static readonly int TILE_HEIGHT = 15;

        /// <summary>
        /// The next valid ID
        /// </summary>
        private static int VALID_ID = 0;
        /// <summary>
        /// The next valid ID
        /// </summary>
        private static int NEXT_VALID_ID { get => ++VALID_ID; }
        #endregion

        #region Variables
        /// <summary>
        /// The tile ID
        /// </summary>
        private readonly int _tile_ID;
        /// <summary>
        /// If the tile has a bomb
        /// </summary>
        private bool _isBomb;
        /// <summary>
        /// If the tile has been flagged
        /// </summary>
        private bool _isFlagged;
        /// <summary>
        /// If the tile has been revealed
        /// </summary>
        private bool _isRevealed;
        /// <summary>
        /// How many bombs surround this tile
        /// </summary>
        private int _surroundingBombs;

        /// <summary>
        /// The tile ID
        /// </summary>
        public int tile_ID { get => _tile_ID; }
        /// <summary>
        /// If the tile has a bomb
        /// </summary>
        public bool isBomb { get => _isBomb; }
        /// <summary>
        /// If the tile has been flagged
        /// </summary>
        public bool isFlagged { get => _isFlagged; }
        /// <summary>
        /// If the tile has been revealed
        /// </summary>
        public bool isRevealed { get => _isRevealed; }
        /// <summary>
        /// How many bombs surround this tile
        /// </summary>
        public int surroundingBombs { get => _surroundingBombs; }
        #endregion

        #region Constructors
        /// <summary>
        /// Simple constructor
        /// </summary>
        public Tile() : this(false) { }

        /// <summary>
        /// Simple constructor
        /// </summary>
        /// <param name="isBomb">Set to true if the tile is a bomb</param>
        public Tile(bool isBomb) {
            _isBomb = isBomb;
            _tile_ID = NEXT_VALID_ID;
        }
        #endregion

        #region Functions
        /// <summary>
        /// Sets the tile as a bomb
        /// </summary>
        public void SetAsBomb() {
            _isBomb = true;
        }

        /// <summary>
        /// Unsets the tile as a bomb
        /// </summary>
        public void UnsetAsBomb() {
            _isBomb = false;
        }

        /// <summary>
        /// Draws the tile
        /// </summary>
        /// <param name="g">The graphics used to draw</param>
        /// <param name="x">The X location</param>
        /// <param name="y">The Y location</param>
        public void DrawTile(Graphics g, int x, int y) {
            if (_isRevealed) {
                g.FillRectangle(Brushes.White, new Rectangle(x, y, TILE_WIDTH, TILE_HEIGHT)); // If we are revealed, draw us white
                if (_surroundingBombs > 0)
                    g.DrawString(_surroundingBombs.ToString(), new Font("Arial", 10), Brushes.Black, new PointF(x + 2, y)); // And if there are bombs around us, draw how many
            } else {
                g.FillRectangle(Brushes.LightGray, new Rectangle(x, y, TILE_WIDTH, TILE_HEIGHT)); // If we aren't revealed yet, draw us light gray
                if (MineSweeperForm.gameOver && _isBomb)
                    g.DrawImage(Resources.minesweeper_bomb, new Point(x, y)); // If the game has ended, draw a bomb if we are a bomb
                if (_isFlagged)
                    g.DrawImage(Resources.minesweeper_flag, new Point(x, y)); // If we are flagged, draw the flag

            }
        }

        /// <summary>
        /// Handles the event when the player clicks on the tile
        /// </summary>
        /// <param name="mode">What mode was the mouse in when the player clicked, Normal click or Flagging</param>
        /// <returns>True if all goes well, False if the player pressed an unflagged bomb</returns>
        public bool Click(MouseModes mode) {
            switch (mode) {
                case MouseModes.Click:
                    if (_isFlagged) // If we are flagged, we do nothing
                        return true;
                    if (_isBomb) // If we are a bomb, we return false because we are game over
                        return false;
                    _isRevealed = true;
                    _surroundingBombs = CalculateNeighbouringMines(); // See how many bombs are around us
                    if (_surroundingBombs == 0) // If there are none, cascade the reveal
                        RevealNeighbours();
                    break;
                case MouseModes.Flag:
                    if (!_isRevealed)
                        _isFlagged = !_isFlagged; // Only flip if we aren't revealed yet
                    return true;
            }
            return true;
        }

        /// <summary>
        /// Calculates how many bombs are around the tile
        /// </summary>
        /// <returns>The number of tiles with a bomb in it</returns>
        private int CalculateNeighbouringMines() {
            int mines = 0;
            foreach (Tile t in MineSweeperForm.field.GetNeighbours(this))
                if (t._isBomb)
                    mines++;
            return mines;
        }

        /// <summary>
        /// Reveals the neighbouring tiles
        /// </summary>
        private void RevealNeighbours() {
            foreach (Tile t in MineSweeperForm.field.GetNeighbours(this))
                if (!t._isRevealed)
                    t.Click(MouseModes.Click);
        }

        /// <summary>
        /// Checks for equality
        /// </summary>
        /// <param name="obj">The other object</param>
        /// <returns>True if equal, false if not</returns>
        public override bool Equals(object obj) {
            if (obj == null)
                return false;
            Tile t = (Tile)obj;
            return _tile_ID == t._tile_ID;
        }

        /// <summary>
        /// returns an unique hashcode based on the tiles ID
        /// </summary>
        /// <returns>The hashcode</returns>
        public override int GetHashCode() {
            return -1799513870 + _tile_ID.GetHashCode();
        }
        #endregion
    }
}
