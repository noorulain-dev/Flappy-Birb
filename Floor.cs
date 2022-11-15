using System;
using SplashKitSDK;

namespace FlappyBird{
    public class Floor{
        private Bitmap _floor;
        private double floorX1;
        private double floorX2;
        private double floorY1;
        private double floorY2;
        private double floorSpeed;
        private FlappyBird yellowb;
        private FlappyBird pinkb;

        /// <summary>
		/// The Floor constructor
		/// </summary>
		/// <param name="fX1"> floor's X1 position.</param>
		/// <param name="fY1">floor's Y1 position.</param>
		/// <param name="fX2">floor's X2 position.</param>
		/// <param name="fY2">floor's Y2 position.</param>
        /// <param name="f_speed">floor's speed.</param>
        /// <param name="pbird">Pinkbird class object.</param>
        /// <param name="ybird">YellowBird class object.</param>
        public Floor(double fX1, double fY1, double fX2, double fY2, double f_speed, FlappyBird ybird, FlappyBird pbird){
            LoadResources();
            _floor = SplashKit.BitmapNamed("floor");
            floorY1 = fY1;
            floorX1 = fX1;
            floorX2 = fX2;
            floorY2 = fY2;
            floorSpeed = f_speed;
            yellowb = ybird;
            pinkb = pbird;
        }

        /// <summary>
		/// Implementing Move method
		/// </summary>
        public void Move(){
            FloorMove();
        }

        /// <summary>
		/// Drawing two sets of floor
		/// </summary>
        public void Draw(){
            _floor.Draw(floorX1, floorY1);
            _floor.Draw(floorX2, floorY2);
        }

        /// <summary>
		/// Checking collision of the FlappyBird with the Floor
		/// </summary>
        public bool CollidedWith()
        {
            if (_floor.BitmapCollision(floorX1, floorY1, yellowb.birdmap, yellowb.bird_X, yellowb.bird_Y) || _floor.BitmapCollision(floorX2, floorY2, yellowb.birdmap, yellowb.bird_X, yellowb.bird_Y) || _floor.BitmapCollision(floorX1, floorY1, pinkb.birdmap, pinkb.bird_X, pinkb.bird_Y) || _floor.BitmapCollision(floorX2, floorY2, pinkb.birdmap, pinkb.bird_X, pinkb.bird_Y)){
                return true;
            } else
                return false;
        }

        /// <summary>
        ///method for moving the floor in two sets so it gives the outcome of a running screen
        /// </summary>
        public void FloorMove(){
            floorX1 -= floorSpeed;
            if (floorX1 <= 0){
                    floorX1 = 1024;
            } else {
                floorX2 = floorX1-1024;
            }
        }

        /// <summary>
		/// Loads the resources for the Floor class
		/// </summary>
        public void LoadResources(){
            SplashKit.LoadBitmap("floor" , "ground.png");
        }

    }
}