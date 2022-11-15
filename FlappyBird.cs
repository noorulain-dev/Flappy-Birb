using System;
using SplashKitSDK;
using System.Collections.Generic;
 
namespace FlappyBird{
        public abstract class FlappyBird{
        private Bitmap bird;
        private double X;
        private double Y;
        private double speed;
        private double bounce;
        private bool space_down;
        private SplashKitSDK.Timer _timer1;
        private SplashKitSDK.Timer _timer;
        private Scores scores;
        private double bbounce;
        private double bspeed;

        /// <summary>
		/// The Flappy bird constructor
		/// </summary>
		/// <param name="bird_x">X position of the bird.</param>
		/// <param name="bird_y">Y position of the bird.</param>
		/// <param name="bird_speed">Speed of the bird.</param>
		/// <param name="bird_bounce">Bounce rate of the bird.</param>
		/// <param name="space">If the user has pressed Space key on the keyboard.</param>
        /// <param name="score">Scores class object</param>
		/// <param name="bboost">Bounce boost of the bird.</param>
		/// <param name="sboost">Speed boost of the bird.</param>
        public FlappyBird(double bird_x, double bird_y, double bird_speed, double bird_bounce, bool space, Scores scr, double bboost, double sboost){
            LoadResources();
            X = bird_x;
            Y = bird_y;
            speed = bird_speed;
            bounce = bird_bounce;
            _timer1 = new SplashKitSDK.Timer("timer");
            _timer = new SplashKitSDK.Timer("timer");
            _timer1.Start();
            space_down = space;
            scores = scr;
            bbounce = bboost;
            bspeed = sboost;
            }

        /// <summary>
		/// Animates the pink bird on the screen
		/// </summary>
        public virtual void Move(){
            if (Scores.Current_S % 2 == 0){
            if (_timer.Ticks <= 150){
                    bird = SplashKit.BitmapNamed("pink1");
                } 
            if(_timer.Ticks > 150 && _timer.Ticks < 300){
                    bird = SplashKit.BitmapNamed("pink2");
                } 
            if (_timer.Ticks > 300){
                    _timer.Start();
                } 
                bird.Draw(bird_X, bird_Y);
            }
        }

        /// <summary>
		/// Abstraction method of Bounce
		/// </summary>
        public abstract void Bounce();

        /// <summary>
		/// Abstraction method of Speed
		/// </summary>
        public abstract void Speed();

        /// <summary>
		/// Gets or sets the bird's bitmap
		/// </summary>
		/// <value>The bird's bitmap.</value>
        public Bitmap birdmap{
            get{ return bird; }
            set{ bird = value; }
        }

        /// <summary>
		/// Gets or sets the bird's X coordinate
		/// </summary>
		/// <value>The bird's X coordinate.</value>
        public double bird_X{
            get{ return X; }
            set{ X = value; }
        }

        /// <summary>
		/// Gets the bird's Speed
		/// </summary>
		/// <value>The bird's Speed.</value>
        public double BSpeed{
            get{ return bspeed; }
        }

        /// <summary>
		/// Gets or sets the bird's Y coordinate
		/// </summary>
		/// <value>The bird's Y coordinate.</value>
        public double bird_Y{
            get{ return Y; }
            set{ Y = value; }
        }

        /// <summary>
		/// Gets or sets the bird's bounce rate
		/// </summary>
		/// <value>The bird's bounce rate.</value>
        public double b_bounce{
            get{ return bounce; }
            set{ bounce = value; }
        }

        /// <summary>
		/// Gets or sets the bird's space pressed
		/// </summary>
		/// <value>The bird's space pressed.</value>
        public bool SpaceDown{
            get{ return space_down; }
            set{ space_down = value; }
        }

        /// <summary>
		/// Gets or sets the bird's speed
		/// </summary>
		/// <value>The bird's speed.</value>
        public double b_speed{
            get{ return speed; }
            set{ speed = value; }
        }

        /// <summary>
		/// Gets the bird's bounce boost
		/// </summary>
		/// <value>The bird's bounce boost.</value>
        public double BBounce{
            get{ return bbounce;}
        }

        /// <summary>
		/// Loads resources for the FlappyBird class
		/// </summary>
        public void LoadResources(){
            SplashKit.LoadBitmap("pink1" , "pink1.png");
            SplashKit.LoadBitmap("pink2" , "pink2.png");
            SplashKit.LoadBitmap("yellow1" , "yelloww1.png");
            SplashKit.LoadBitmap("yellow2" , "yelloww2.png");
            SplashKit.LoadMusic("tune", "resources/sounds/tune.mp3");
        }

        /// <summary>
		/// Gets the Score class object
		/// </summary>
		/// <value>The Score class.</value>
        public Scores Scores{
            get{ return scores; }
        }

    }
}