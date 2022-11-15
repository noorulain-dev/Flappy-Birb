using System;
using SplashKitSDK;

namespace FlappyBird{

    public class Screen{        
        private Bitmap _sky;
        private double skyX1;
        private double skyX2;
        private double skyY1;
        private double skyY2;
        private double skySpeed;
        private Bitmap _exit;
        private double exitX;
        private double exitY;
        private Bitmap _intro;
        private double introX;
        private double introY;
        private FlappyBird yellowb;
        private FlappyBird pinkb;

        /// <summary>
		/// The Sky constructor
		/// </summary>
		/// <param name="sX1">X1 position.</param>
		/// <param name="sX2">X2 position.</param>
		/// <param name="sY1">Y1 position.</param>
		/// <param name="sY2">Y2 position.</param>
        /// <param name="s_speed">speed of the pipe.</param>
        /// <param name="eX">X position of exit.</param>
		/// <param name="eY">Y position of exit.</param>
		/// <param name="iX">X position of introduction.</param>
		/// <param name="iY">Y position of introduction.</param>
        /// <param name="yBird">YellowBird class object.</param>
        /// <param name="pBird">PinkBird class object.</param>
        public Screen(double sX1, double sX2, double sY1, double sY2, double s_Speed, double eX, double eY, double iX, double iY, FlappyBird ybird, FlappyBird pbird){
            LoadResources();
            _sky = SplashKit.BitmapNamed("sky");
            skyY1 = sY1;
            skyX1 = sX1;
            skyX2 = sX2;
            skyY2 = sY2;
            skySpeed = s_Speed;
            _intro = SplashKit.BitmapNamed("introduction");
            _exit = SplashKit.BitmapNamed("gameover");
            exitX = eX;
            exitY = eY;
            introX = iX;
            introY = iY;
            yellowb = ybird;
            pinkb = pbird;
        }

        /// <summary>
		/// Implementing the Move method
		/// </summary>
        public void Move(){
            SkyMove();
        }
        
        /// <summary>
		/// Checking collision of the bird with the screen i.e if the bird went out of the bound of the screen
		/// </summary>
        public bool CollidedWith()
        {
            if (_sky.BitmapCollision(skyX1-skyX1, skyY2-520, yellowb.birdmap, yellowb.bird_X, yellowb.bird_Y) || _sky.BitmapCollision(skyX2-skyX2, skyY2-520, yellowb.birdmap, yellowb.bird_X, yellowb.bird_Y) || _sky.BitmapCollision(skyX1-skyX1, skyY2-520, pinkb.birdmap, pinkb.bird_X, pinkb.bird_Y) || _sky.BitmapCollision(skyX2-skyX2, skyY2-520, pinkb.birdmap, pinkb.bird_X, pinkb.bird_Y)){
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
		/// Drawing the sky
		/// </summary>
        public void SkyDraw(){
            _sky.Draw(skyX1, skyY1);
            _sky.Draw(skyX2, skyY2);
        }

        /// <summary>
		/// Playing the tune
		/// </summary>
        public void TuneSound()
        {
            SplashKit.PlayMusic("tune");
        }

        /// <summary>
		/// Drawing the introduction
		/// </summary>
        public void IntroDraw(){
            _intro.Draw(introX, introY);
        }

        /// <summary>
		/// Drawing the exit screen
		/// </summary>
        public void ExitDraw(){
            _exit.Draw(exitX, exitY);
        }

        /// <summary>
		/// moving the sky towards the left repetitively gives an output of a running screen
		/// </summary>
        public void SkyMove(){
            skyX1 -= skySpeed;
            if (skyX1 <= 0){
                    skyX1 = 1024;
            } else {
                skyX2 = skyX1-1024;
            }
        }

        /// <summary>
		/// Loading resources for the Screen object
		/// </summary>
        public void LoadResources(){
            SplashKit.LoadBitmap("sky" , "sky.png");
            SplashKit.LoadBitmap("gameover" , "gameover.png");
            SplashKit.LoadBitmap("introduction" , "introduction.png");
        }
    }
}
