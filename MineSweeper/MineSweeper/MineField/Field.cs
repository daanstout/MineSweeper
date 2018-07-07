using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MineSweeper.MineSweeperForm;

namespace MineSweeper.Minefield {
    public class Field {
        #region Variables
        /// <summary>
        /// The mine field
        /// </summary>
        private readonly Tile[] _field;
        /// <summary>
        /// The number of tiles in a row
        /// </summary>
        private readonly int _width;
        /// <summary>
        /// The number of tiles in a column
        /// </summary>
        private readonly int _height;
        /// <summary>
        /// The number of bombs that still need to be found
        /// </summary>
        private int _numActiveBombs;
        /// <summary>
        /// The number of bombs that have been found
        /// </summary>
        private int _numFlaggedBombs;
        /// <summary>
        /// The tile the user hovererd over on mousedown
        /// </summary>
        private int _mouseDownIndex;
        /// <summary>
        /// Whether its the first click of the game
        /// </summary>
        private bool firstClick = true;

        /// <summary>
        /// The mine field
        /// </summary>
        public Tile[] field { get => _field; }
        /// <summary>
        /// The number of tiles in a row
        /// </summary>
        public int width { get => _width; }
        /// <summary>
        /// The number of tiles in a column
        /// </summary>
        public int height { get => _height; }
        /// <summary>
        /// The number of tiles in the field
        /// </summary>
        public int size { get => _width * _height; }
        /// <summary>
        /// The number of bombs that still need to be found
        /// </summary>
        public int numActiveBombs { get => _numActiveBombs; }
        /// <summary>
        /// The number of bombs that have been found
        /// </summary>
        public int numFlaggedBombs { get => _numFlaggedBombs; }
        /// <summary>
        /// The total number of bombs in the field
        /// </summary>
        public int numTotalBombs { get => _numActiveBombs + _numFlaggedBombs; }
        /// <summary>
        /// True if there are no more active bombs
        /// </summary>
        public bool IsFinished { get => _numActiveBombs == 0; }
        #endregion

        #region Constructors
        /// <summary>
        /// Simple Constructor
        /// </summary>
        /// <param name="width">The number of tiles in a row</param>
        /// <param name="height">The number of tiles in a column</param>
        /// <param name="numBombs">The number of bombds on the field</param>
        public Field(int width, int height, int numBombs) {
            _width = width;
            _height = height;
            _numActiveBombs = numBombs;
            _numFlaggedBombs = 0;

            _field = new Tile[size];

            InitTiles();
        }
        #endregion

        #region Functions
        /// <summary>
        /// Initiates all the tiles
        /// </summary>
        public void InitTiles() {
            for (int i = 0; i < size; i++) {
                _field[i] = new Tile();
            }

            PlaceBombs();
        }

        /// <summary>
        /// Places bombs on the field
        /// </summary>
        public void PlaceBombs() {
            int placedBombs = 0;
            float bombPlaceChance = _numActiveBombs / (float)size * 0.5f; // The chance for a tile to be abomb is : (number of bombs / number of tiles) / 2. We divide by 2 to spread the placement a bit more to the end
            Random rand = new Random();

            do {
                for (int i = 0; i < size; i++) {
                    if (!field[i].isBomb) { // Only go for fields that aren't bombs yet
                        if (rand.NextDouble() <= bombPlaceChance) { // See if we can place a bomb
                            _field[i].SetAsBomb();
                            placedBombs++;
                            if (placedBombs >= _numActiveBombs) // Check if we've reached our quota yet
                                break;
                        }
                    }
                }
            } while (placedBombs < _numActiveBombs); // Keep doing this until we've got our quota
        }

        /// <summary>
        /// Starts the click procedure by remembering on what tile we pressed
        /// </summary>
        /// <param name="x">The X location</param>
        /// <param name="y">The Y location</param>
        public void MouseDown(int x, int y) {
            _mouseDownIndex = LocationToIndex(x, y); // We only press if the user both pressed and released the mouse on the same tile
        }

        /// <summary>
        /// Finish the click process if we pressed the same tile again
        /// </summary>
        /// <param name="mode">The mouse mode used to click</param>
        /// <param name="x">The X location</param>
        /// <param name="y">The Y location</param>
        /// <returns>True if all went well, false if we ded</returns>
        public bool Click(MouseModes mode, int x, int y) {
            int index = LocationToIndex(x, y);
            if (index != _mouseDownIndex) // If we aren't equal, stop, but we return true as we are still alive
                return true;

            if (firstClick) { // If it is the very first click of the game, we are forgiving and move a bomb if the user clicked on a bomb
                firstClick = false;
                if (_field[index].isBomb) {
                    _field[index].UnsetAsBomb();
                    bool look = true;
                    Random rand = new Random();
                    do { // While we are still looking for a new tile to put the bomb, choose a random tile. If it isn't a bomb, make it a bomb
                        int hit = rand.Next(0, size);
                        if (!_field[hit].isBomb) {
                            _field[hit].SetAsBomb();
                            look = false;
                        }
                    } while (look);
                }
            }

            bool result = _field[index].Click(mode); // Click on the tile and let it do it's thing

            if (mode == MouseModes.Flag) { // If we were in flagging mode, we need to update the number of bombs remaining, but only if the clicked tile was not yet revealed
                if (!_field[index].isRevealed) {
                    if (_field[index].isFlagged) {
                        _numFlaggedBombs++;
                        _numActiveBombs--;
                    } else {
                        _numFlaggedBombs--;
                        _numActiveBombs++;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Draws all the tiles
        /// </summary>
        /// <param name="g">The graphics instance to draw to</param>
        public void Draw(Graphics g) {
            int curX, curY;
            curX = curY = 0; // Keep our location in check
            for (int i = 0; i < size; i++) {
                _field[i].DrawTile(g, curX, curY);
                curX += Tile.TILE_WIDTH; // Every loop, increase the X by the tile width

                if ((i + 1) % width == 0 && i != 0) { // If we've reached the end of a row, go down 1 row. Remember to not do this at i = 0
                    curX = 0;
                    curY += Tile.TILE_HEIGHT;
                }
            }
            
            // Draw the lines between the tiles for clarity
            for (int i = 0; i < width + 1; i++)
                g.DrawLine(Pens.Gray, new Point(i * Tile.TILE_WIDTH, 0), new Point(i * Tile.TILE_WIDTH, height * Tile.TILE_HEIGHT));

            for (int i = 0; i < height + 1; i++)
                g.DrawLine(Pens.Gray, new Point(0, i * Tile.TILE_HEIGHT), new Point(width * Tile.TILE_WIDTH, i * Tile.TILE_HEIGHT));
        }

        /// <summary>
        /// Translates a location to a tile index
        /// </summary>
        /// <param name="x">The x location</param>
        /// <param name="y">The y location</param>
        /// <returns>returns -1 if the location was outside the zone, else it returns the index</returns>
        private int LocationToIndex(int x, int y) {
            if (x > (width + 1) * Tile.TILE_WIDTH || y > (height + 1) * Tile.TILE_HEIGHT)
                return -1;

            return (width * (y / Tile.TILE_HEIGHT)) + (x / Tile.TILE_WIDTH);
        }

        /// <summary>
        /// Returns all neighbours of a tile
        /// </summary>
        /// <param name="index">The index of the tile in the array</param>
        /// <returns>A list of all its neighbours</returns>
        public List<Tile> GetNeighbours(int index) {
            if (index < 0 || index >= size)
                return null;

            List<Tile> neighbours = new List<Tile>();

            bool up, down, left, right;
            up = down = left = right = false; // Some bools to indicate if there are tiles around it in the given directions

            if (index >= width)
                up = true;
            if (index < size - width)
                down = true;
            if (index / width == (index + 1) / width && index < size)
                right = true;
            if (index / width == (index - 1) / width && index > 0)
                left = true;
            
            // Now add those neighbours
            if (up) {
                neighbours.Add(_field[index - width]);
                if (left)
                    neighbours.Add(_field[index - width - 1]);
                if (right)
                    neighbours.Add(_field[index - width + 1]);
            }
            if (down) {
                neighbours.Add(_field[index + width]);
                if (left)
                    neighbours.Add(_field[index + width - 1]);
                if (right)
                    neighbours.Add(_field[index + width + 1]);
            }
            if (left)
                neighbours.Add(_field[index - 1]);
            if (right)
                neighbours.Add(_field[index + 1]);

            return neighbours;
        }

        /// <summary>
        /// Returns all neighbours of a tile
        /// </summary>
        /// <param name="tile">The tile</param>
        /// <returns>A list of all its neighbours</returns>
        public List<Tile> GetNeighbours(Tile tile) {
            if (tile == null)
                return null;
            return GetNeighbours(_field.ToList().IndexOf(tile));
        }
        #endregion
    }
}
