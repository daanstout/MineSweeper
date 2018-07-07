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
        private  int _numActiveBombs;
        /// <summary>
        /// The number of bombs that have been found
        /// </summary>
        private  int _numFlaggedBombs;

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

        public Field(int width, int height, int numBombs) {
            _width = width;
            _height = height;
            _numActiveBombs = numBombs;
            _numFlaggedBombs = 0;

            _field = new Tile[size];


        }

        public void InitTiles() {
            for(int i = 0; i < size; i++) {
                _field[i] = new Tile();
            }

            PlaceBombs();
        }

        public void PlaceBombs() {
            int placedBombs = 0;
            float bombPlaceChance = _numActiveBombs / (float)size;
            Random rand = new Random();

            while(placedBombs < _numActiveBombs) {
                for(int i = 0; i < size; i++) {
                    if (!field[i].isBomb) {
                        if (rand.NextDouble() >= bombPlaceChance) {
                            _field[i].SetAsBomb();
                            placedBombs++;
                            if (placedBombs >= _numActiveBombs)
                                break;
                        }
                    }
                }
            }
        }

        public bool Click(MouseModes mode, int x, int y) {
            int index = LocationToIndex(x, y);
            bool result = _field[index].Click(mode);

            if(mode == MouseModes.Flag) {
                if (_field[index].isFlagged) {
                    _numFlaggedBombs++;
                    _numActiveBombs--;
                } else {
                    _numFlaggedBombs--;
                    _numActiveBombs++;
                }
            }

            return result;
        }

        public void Draw(Graphics g) {
            int curX, curY;
            curX = curY = 0;
            for (int i = 0; i < size; i++) {
                _field[i].DrawTile(g, curX, curY);
                curX += Tile.TILE_WIDTH;
                if(i % width == 0 && i != 0) {
                    curX = 0;
                    curY += Tile.TILE_HEIGHT;
                }
            }
        }

        private int LocationToIndex(int x, int y) {
            return 0;
        }
    }
}
