using System;
using SplashKitSDK;
using System.Collections.Generic;

namespace FlappyBird{
    public class YellowBird: FlappyBird{
        private Timer _timer;
        private double _boost;

        /// <summary>
		/// Yellow bird constructor
		/// </summary>
		/// <param name="sboost">Boosting speed of the bird</param>
        /// <param name="bboost">Boosting bounce of the bird</param>
        /// <param name="scores">Scores class object</param>
		/// <param name="bird_x">X position.</param>
		/// <param name="bird_y">Y position.</param>
		/// <param name="bird_speed">Speed of the bird.</param>
        /// <param name="bird_bounce">Bounce of the bird.</param>
		/// <param name="space">Space key pressed.</param>
        public YellowBird(double bird_x, double bird_y, double bird_speed, double bird_bounce, bool space, Scores scores, double sboost, double bboost):base(bird_x, bird_y, bird_speed, bird_bounce, space, scores, sboost, bboost){
            _timer = new SplashKitSDK.Timer("timer");
            _timer.Start();
        }

        /// <summary>
		/// Overriding method
        /// Animates the bird
		/// </summary>
		/// <param name="s">Scores s</param>
        public override void Move()
        {
            if (Scores.Current_S % 2 != 0){
                if (_timer.Ticks <= 150){
                    birdmap = SplashKit.BitmapNamed("yellow1");
                } 
                if(_timer.Ticks > 150 && _timer.Ticks < 300){
                    birdmap = SplashKit.BitmapNamed("yellow2");
                } 
                if (_timer.Ticks > 300) {
                    _timer.Start();
                } 
                birdmap.Draw(bird_X, bird_Y);
            }
        }

        /// <summary>
		/// increases the y value of the bird constantly
        /// adds in a boost which increases the speed of yellow bird
		/// </summary>
        public override void Speed(){
            if (Scores.Current_S % 2 != 0){
                bird_Y = bird_Y + BSpeed;
            } else {
                bird_Y = bird_Y + b_speed;
            }
        }

        /// <summary>
		/// moves the bird upward which gives the bird a bouncing movement
		/// </summary>
        public override void Bounce(){
            if (SplashKit.KeyTyped(KeyCode.SpaceKey)){
                SpaceDown = true;
                if (Scores.Current_S % 2 != 0){
                    bird_Y = bird_Y - b_bounce;
                } else {
                    bird_Y = bird_Y - b_bounce - BBounce;
                } SplashKit.PlaySoundEffect("wing");
            }
        }

        /// <summary>
		/// Get and set the bird speed boost
		/// </summary>
		/// <value>The bird's boost.</value>
        public double s_boost{
            get{ return _boost; }
            set{ _boost = value; }
        }

    }
}
