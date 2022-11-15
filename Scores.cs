using System;
using SplashKitSDK;
using System.Collections.Generic;

namespace FlappyBird{
    public class Scores{

        private int current_Score;
        private int highest_score;
        private Window window;

        /// <summary>
		/// constructor for Scores
		/// </summary>
        /// <param name="w">Window w</param>
		/// <param name="Current_s">Current score.</param>
		/// <param name="Highest_s">Highest score</param>
        public Scores(Window w, int Current_s, int Highest_s){
            LoadResources();
            current_Score = Current_s;
            highest_score = Highest_s;
            window = w;
        }

        /// <summary>
		/// Updates the current score
		/// </summary>
		/// <param name="x">int x.</param>
        public void UpdateScores(){
            current_Score += 1;
        }

        /// <summary>
		/// checks if the current score is the highest score achieved by the user
        /// if not then that score becomes highest score
		/// </summary>
        public int HighestScores(){
            if (current_Score > highest_score){
                highest_score = current_Score;
            }
            return highest_score;
        }

        /// <summary>
        // displays final scores in custom font
		/// </summary>
        public void FinalScores(){
            window.DrawText($"Current Score: " + current_Score, Color.White, SplashKit.FontNamed("font"), 35, 400, 200);
            window.DrawText($"Highest Score: " + HighestScores(), Color.White, SplashKit.FontNamed("font"), 35, 405, 250);
        }

        /// <summary>
		//displays current scores in custom font
		/// </summary>
        public void CurrentScores(){
            window.DrawText($"Score: " + current_Score , Color.FloralWhite, SplashKit.FontNamed("font"), 20, 20, 20);
        }

        /// <summary>
		//displays instructions for starting the game
		/// </summary>
        public void PlayInstructions(){
            window.DrawText($"Press Space to Play", Color.Pink, SplashKit.FontNamed("font"), 30, 400, 400);
        }

        /// <summary>
		//displays instructions for restarting the game
		/// </summary>
        public void ReplayInstructions(){
            window.DrawText($"Press Enter to Restart", Color.Pink, SplashKit.FontNamed("font"), 30, 375, 300);
        }
        
        /// <summary>
		/// property for getting and setting current scores
		/// </summary>
        public int Current_S{
            get{ return current_Score;}
            set{ current_Score = value; }
        }

        /// <summary>
		/// Method for drawing the current scores
		/// </summary>
        public void Draw(){
            CurrentScores();
        }

        /// <summary>
		// Loads resources for the Scores class
		/// </summary>
        public void LoadResources(){
            SplashKit.LoadFont("font", "flappy.ttf");
        }
    }
}