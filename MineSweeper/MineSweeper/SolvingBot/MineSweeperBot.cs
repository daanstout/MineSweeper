using MineSweeper.Minefield;
using MineSweeper.Datastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.SolvingBot {
    public class MineSweeperBot {
        #region Variables
        /// <summary>
        /// Indicates if the bot should do the next step
        /// </summary>
        private bool _doStep;
        /// <summary>
        /// Indicates if the bot should do the next step
        /// </summary>
        public bool doStep { get => _doStep; set => _doStep = value; }
        /// <summary>
        /// Simple way so I don't have to type getting the instance all the time
        /// </summary>
        private MineSweeperForm form { get => MineSweeperForm.instance; }
        #endregion

        public MineSweeperBot() {
            Solve();
        }

        private void Solve() {
            Datastructures.Queue<Tile> q = new Datastructures.Queue<Tile>();

            {
                Tile tile = FindRevealedTile();

                if (tile == null) {
                    tile = FindFlaggedTile();

                    if (tile == null) {
                        Console.WriteLine("No more leads");
                        return;
                    }
                }

                q.Enqueue(tile);
            }

            while (!q.isEmpty) {
                Tile tile = q.Dequeue();

                if (tile == null)
                    continue;

                List<Tile> neighbours = form.field.GetNeighbours(tile);

                if (neighbours == null)
                    continue;

                if (tile.isRevealed && tile.surroundingBombs > 0) {
                    // We have been clicked on and have a surrounding number of bombs
                } else if (!tile.isRevealed && tile.isFlagged) {
                    // We have been flagged
                }
            }
        }

        private Tile FindRevealedTile() {
            foreach (Tile t in form.field.field)
                if (t.isRevealed)
                    if (FlagBombs(t))
                        return t;

            return null;
        }

        private Tile FindFlaggedTile() {
            //foreach (Tile t in form.field.field) 
            //    if (t.isFlagged) 
            //        if (ClearTiles(t))
            //            return t;

            return null;
        }

        private bool FlagBombs(Tile tile) {
            if (tile.surroundingBombs == 0)
                return false;

            List<Tile> neighbours = form.field.GetNeighbours(tile);

            if (neighbours == null)
                return false;

            int hid = 0;

            foreach (Tile u in neighbours)
                if (!u.isRevealed)
                    hid++;

            Console.WriteLine(hid);

            if (hid == tile.surroundingBombs) {
                foreach (Tile u in neighbours)
                    if (!u.isRevealed && !u.isFlagged)
                        form.field.ProcessBotClick(u);

                form.Redraw();
                return true;
            }

            return false;
        }

        //private bool ClearTiles(Tile tile) {
        //    if (!tile.isFlagged)
        //        return false;

        //    List<Tile> neighbours = form.field.GetNeighbours(tile);

        //    if(neighbours == null)
        //        return false;


        //}
    }
}
