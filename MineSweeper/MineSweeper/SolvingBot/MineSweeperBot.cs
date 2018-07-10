using MineSweeper.Minefield;
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
            Tile currentTile = null;



            //while (!form.field.IsFinished || !MineSweeperForm.gameOver) {
            foreach (Tile t in form.field.field) {
                if (t.isRevealed) {
                    //currentTile = t;
                    //break;

                    List<Tile> neighbours = form.field.GetNeighbours(t);

                    if (neighbours == null)
                        //continue
                        continue;

                    if (t.surroundingBombs == 0)
                        //continue;
                        continue;

                    int hid = 0;

                    foreach (Tile u in neighbours)
                        if (!u.isRevealed)
                            hid++;

                    //Console.WriteLine(hid);

                    if (hid == t.surroundingBombs) {
                        foreach (Tile u in neighbours) {
                            if (!u.isRevealed && !u.isFlagged) {
                                //u.Click(MineSweeperForm.MouseModes.Flag);
                                form.field.MouseDown(u);
                                form.field.Click(MineSweeperForm.MouseModes.Flag, u);
                            }
                        }
                        form.Redraw();
                    }
                }
            }

            

            //}
        }
    }
}
