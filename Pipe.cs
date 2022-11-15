using System;
using SplashKitSDK;
using System.Collections.Generic;

namespace FlappyBird{
    public class Pipe{
        private Bitmap PipeUp;
        private Bitmap PipeDown;
        private double pipe_x1;
        private double pipe_y1;
        private double pipe_x2;
        private double pipe_y2;
        private double speed;
        Random rnd = new Random();
        private FlappyBird yellowb;
        private FlappyBird pinkb;
        
        /// <summary>
		/// The Pipe constructor
		/// </summary>
		/// <param name="pipeX1">X1 position.</param>
		/// <param name="pipeY1">Y1 position.</param>
		/// <param name="pipeX2">X2 position.</param>
		/// <param name="pipeY2">Y2 position.</param>
		/// <param name="p_speed">speed of the pipe.</param>
        /// <param name="ybird">YellowBird class object.</param>
		/// <param name="pbird">PinkBird class object.</param>
        public Pipe(double pipeX1, double pipeY1, double pipeX2, int pipeY2, double p_speed, FlappyBird ybird, FlappyBird pbird){
            LoadResources();
            PipeUp = SplashKit.BitmapNamed("pipe_up");
            PipeDown = SplashKit.BitmapNamed("pipe_bottom");
            pipe_x1 = pipeX1;
            pipe_y1 = pipeY1;
            pipe_x2 = pipeX2;
            pipe_y2 = pipeY2;
            speed = p_speed;
            yellowb = ybird;
            pinkb = pbird;
        }

        /// <summary>
		/// Method which moves the pipes
		/// </summary>
        public void Move()
        {
            PipeMove1();
            PipeMove2();
        }

        /// <summary>
		/// Method which moves the pipes towards the left
		/// </summary>
        public void PipeMove1()
        {
            if (pipe_x1 >= -100){
                pipe_x1 -= speed;
            } else {
                pipe_y1 = rnd.Next(-600, -400);
                pipe_x1 = 1024;
            }
        }

        /// <summary>
		/// Method which moves another set of pipes towards the left
		/// </summary>
        public void PipeMove2()
        {
            if (pipe_x2 >= -100){
                pipe_x2 -= speed;
            } else {
                pipe_y2 = rnd.Next(-600, -400);
                pipe_x2 = 1024;
            }
        }

        /// <summary>
		/// Method which draws the pipes
		/// </summary>
        public void Draw()
        {
            PipeUp.Draw(pipe_x1, pipe_y1);
            PipeDown.Draw(pipe_x1, pipe_y1 + 775);
            PipeUp.Draw(pipe_x2, pipe_y2);
            PipeDown.Draw(pipe_x2, pipe_y2 + 775);
        }

        /// <summary>
		/// Method which checks collision of the bird with the pipes
		/// </summary>
        public bool CollidedWith()
        {
            if (PipeUp.BitmapCollision(pipe_x1, pipe_y1, yellowb.birdmap, yellowb.bird_X, yellowb.bird_Y) || PipeDown.BitmapCollision(pipe_x1, pipe_y1 + 775, yellowb.birdmap, yellowb.bird_X, yellowb.bird_Y) || PipeUp.BitmapCollision(pipe_x2, pipe_y2, yellowb.birdmap, yellowb.bird_X, yellowb.bird_Y) || PipeDown.BitmapCollision(pipe_x2, pipe_y2 +775, yellowb.birdmap, yellowb.bird_X, yellowb.bird_Y) || PipeUp.BitmapCollision(pipe_x1, pipe_y1, pinkb.birdmap, pinkb.bird_X, pinkb.bird_Y) || PipeDown.BitmapCollision(pipe_x1, pipe_y1 + 775, pinkb.birdmap, pinkb.bird_X, pinkb.bird_Y) || PipeUp.BitmapCollision(pipe_x2, pipe_x2, pinkb.birdmap, pinkb.bird_X, pinkb.bird_Y) || PipeDown.BitmapCollision(pipe_x2, pipe_y2 +775, pinkb.birdmap, pinkb.bird_X, pinkb.bird_Y)){
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
		/// Method which checks if the bird has passed the pipe
		/// </summary>
        public bool PipePass()
        {
            if ((PX1 <= yellowb.bird_X+(speed/2) && PX1 >= yellowb.bird_X-(speed/2)) || (PX1 <= pinkb.bird_X+(speed/2) && PX1 >= pinkb.bird_X-(speed/2)) || (PX2 <= yellowb.bird_X+(speed/2) && PX2 >= yellowb.bird_X-(speed/2)) || (PX2 <= pinkb.bird_X+(speed/2) && PX2 >= pinkb.bird_X-(speed/2)) ){
                return true;
            } else {
            return false;
            }
        }

        /// <summary>
		/// Get and set the pipe1 X coordinate
		/// </summary>
		/// <value>The pipe1 X coordinate.</value>
        public double PX1
        {
            get { return pipe_x1; }
            set { pipe_x1 = value; }
        }

        /// <summary>
		/// Get and set the pipe2 X coordinate
		/// </summary>
		/// <value>The pipe2 X coordinate.</value>
        public double PX2
        {
            get { return pipe_x2; }
            set{ pipe_x2 = value; }
        }

        /// <summary>
		/// Loads resources for the pipe class
		/// </summary>
        public void LoadResources(){
            SplashKit.LoadBitmap("pipe_bottom" , "pipebottom.png");
            SplashKit.LoadBitmap("pipe_up" , "pipetop.png");
            SplashKit.LoadSoundEffect("hit","resources/sounds/hit.mp3");
            SplashKit.LoadSoundEffect("point", "resources/sounds/point.mp3");
            SplashKit.LoadSoundEffect("wing", "resources/sounds/wing.mp3");
        }

    }
}