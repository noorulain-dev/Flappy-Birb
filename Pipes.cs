using System;
using SplashKitSDK;
using System.Collections.Generic;

namespace FlappyBird{
    public class Pipes{
        private List<Pipe> _pipes;
        private bool collision;
        private bool pass;

        /// <summary>
		/// The Pipes constructor
		/// </summary>
        public Pipes(){
            _pipes = new List<Pipe>();
            collision = false;
            pass = false;
        }

        /// <summary>
		/// Adds Pipe to the pipes array
		/// </summary>
        public void AddPipes(Pipe p){
            if ((p.PX2 > 1535.9 && p.PX2 < 1536.1) && collision == false){
            _pipes.Add(p);
            }
        }

        /// <summary>
		/// Moves the pipes in the array
		/// </summary>
        public void Move(){
            foreach(Pipe p in _pipes){
                p.Move();
            }
        }

        /// <summary>
		/// Draws the pipes in the array
		/// </summary>
        public void Draw(){
            foreach(Pipe p in _pipes){
                p.Draw();
            }
        }

        /// <summary>
		/// Checks collision for every pipe in the array
		/// </summary>
        public bool CollidedWith(){
            foreach(Pipe p in _pipes){
                if (p.CollidedWith() == true){
                    collision = true;
                } else{
                    collision = false;
                }
            } return collision;
        }

        /// <summary>
		/// Checks if bird has passed the pipe for every pipe in the array
		/// </summary>
        public bool PipePass(){
            foreach(Pipe p in _pipes){
                if (p.PipePass() == true){
                    pass = true;
                } else {
                    pass = false;
                }
            } return pass;
        }

        /// <summary>
		/// Play a hit sound
		/// </summary>
        public void HitSounds()
        {
            SplashKit.PlaySoundEffect("hit");
        }

        /// <summary>
		/// Plays a points sound
		/// </summary>
        public void PointsSound()
        {
            SplashKit.PlaySoundEffect("point");
        }
    }
}