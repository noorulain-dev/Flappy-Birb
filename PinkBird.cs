using System;
using SplashKitSDK;
using System.Collections.Generic;

namespace FlappyBird{
    public class PinkBird: FlappyBird{
        private Timer _timer;

        /// <summary>
		/// The PinkBird constructor
		/// </summary>
		/// <param name="sboost">Boosting speed of the bird</param>
        /// <param name="bboost">Boosting bounce of the bird</param>
        /// <param name="scores">Scores class object</param>
		/// <param name="bird_x">X position.</param>
		/// <param name="bird_y">Y position.</param>
		/// <param name="bird_speed">Speed of the bird.</param>
        /// <param name="bird_bounce">Bounce of the bird.</param>
		/// <param name="space">Space key pressed.</param>
        public PinkBird(double bird_x, double bird_y, double bird_speed, double bird_bounce, bool space, Scores scores, double sboost, double bboost):base(bird_x, bird_y, bird_speed, bird_bounce, space, scores, sboost, bboost){
            _timer = new SplashKitSDK.Timer("timer");
            _timer.Start();
        }

        /// <summary>
		/// Overriding the abstract method Move()
        /// Animates the pink bird
		/// </summary>
        public override void Move(){
            if (Scores.Current_S % 2 == 0){
            if (_timer.Ticks <= 150){
                    birdmap = SplashKit.BitmapNamed("pink1");
                } 
            if(_timer.Ticks > 150 && _timer.Ticks < 300){
                    birdmap = SplashKit.BitmapNamed("pink2");
                } 
            if (_timer.Ticks > 300){
                    _timer.Start();
                } 
                birdmap.Draw(bird_X, bird_Y);
            }
        }

        /// <summary>
		/// moves the bird upward which gives the bird a bouncing movement
		/// </summary>
        public override void Bounce(){
            if (SplashKit.KeyTyped(KeyCode.SpaceKey)){
                SpaceDown = true;
                if (Scores.Current_S % 2 == 0){
                    bird_Y = bird_Y - b_bounce - BBounce;
                } else {
                    bird_Y = bird_Y - b_bounce;
                } 
                SplashKit.PlaySoundEffect("wing");
            }
        }

        /// <summary>
		/// increases the y value of the bird constantly
		/// </summary>
        public override void Speed(){
            if (Scores.Current_S % 2 == 0){
                bird_Y = bird_Y + b_speed;
            } else {
                bird_Y = bird_Y + BSpeed;
            }
        }

    }
}