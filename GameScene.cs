using System;
using SplashKitSDK;
using System.Collections.Generic;

namespace FlappyBird{
    public class GameScene{
        private Pipes _pipes;
        private Scores scores;
        private bool songplaying;
        private Screen screen;
        private Floor floor;

        /// <summary>
		/// The Game Scene constructor
		/// </summary>
		/// <param name="pipe">Pipes class object.</param>
		/// <param name="scr">Scores class object.</param>
		/// <param name="scn">Scene class object.</param>
		/// <param name="song">Song playing or not boolean value.</param>
		/// <param name="f">Floor class object.</param>
        public GameScene(Pipes pipe, Scores scr, Screen scn, bool song, Floor f){
            _pipes = pipe;
            scores = scr;
            songplaying = false;
            screen = scn;
            floor = f;
        }

        /// <summary>
		/// Checks if the FlappyBird has passed through the pipe
		/// </summary>
        public void PipePass(){
            if (_pipes.PipePass() == true){    
                _pipes.PointsSound();
                scores.UpdateScores();
            }
        }

        /// <summary>
		/// Plays background song on repeat
		/// </summary>
        public void Song(){
            if (songplaying == false){
                screen.TuneSound();
                songplaying = true;
            } else {
                songplaying = false;
            }
        }

        /// <summary>
		/// Checks collision of FlappyBird with the Pipe, Floor, and Screen.
		/// </summary>
        public bool Collision(){
            if(_pipes.CollidedWith() == true || floor.CollidedWith() == true || screen.CollidedWith() == true){
                return true;
            } else {
                return false;
            }
        }

    }
}