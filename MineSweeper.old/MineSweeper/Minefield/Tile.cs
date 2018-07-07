using MineSweeper.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MineSweeper.MineSweeperForm;

namespace MineSweeper.Minefield {
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
        #endregion

        #region Variables
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
        /// Draws the tile
        /// </summary>
        /// <param name="g">The graphics used to draw</param>
        /// <param name="x">The X location</param>
        /// <param name="y">The Y location</param>
        public void DrawTile(Graphics g, int x, int y) {
            if (_isRevealed) {
                g.FillRectangle(Brushes.White, new Rectangle(x, y, TILE_WIDTH, TILE_HEIGHT));
                if (_surroundingBombs > 0)
                    g.DrawString(_surroundingBombs.ToString(), new Font("Arial", 12), Brushes.Black, new PointF(TILE_WIDTH, TILE_HEIGHT));
            } else {
                if (_isFlagged)
                    g.DrawImage(Resources.minesweeper_flag, new Point(x, y));
                else
                    g.FillRectangle(Brushes.Gray, new Rectangle(x, y, TILE_WIDTH, TILE_HEIGHT));
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
                    if (_isFlagged)
                        return true;
                    if (_isBomb)
                        return false;
                    _isRevealed = true;
                    _surroundingBombs = CalculateNeighbouringMines();
                    if (_surroundingBombs == 0)
                        RevealNeighbours();
                    break;
                case MouseModes.Flag:
                    _isFlagged = !_isFlagged;
                    return true;
            }
            return true;
        }

        /// <summary>
        /// Calculates how many bombs are around the tile
        /// </summary>
        /// <returns>The number of tiles with a bomb in it</returns>
        private int CalculateNeighbouringMines() {
            return 0;
        }

        /// <summary>
        /// Reveals the neighbouring tiles
        /// </summary>
        private void RevealNeighbours() {
            // foreach neighbour.Click()
        }
        #endregion
    }
}
