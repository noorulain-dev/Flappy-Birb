using System;
using SplashKitSDK;

namespace FlappyBird{
    public class Program{
        public static void Main(){
            /// <summary>
            //introducing objects for different classes
            /// </summary>
            Window myWindow = new Window("Flappy Bird by Noor Ul Ain", 1024, 520);
            Scores myScores = new Scores(myWindow, 0, 0);
            YellowBird myYellow = new YellowBird(400, 300, 0.05, 20, false, myScores, 15, 0.05);
            PinkBird myPink = new PinkBird(400, 300, 0.05, 20, false, myScores, 15, 0.05);
            Floor myFloor = new Floor(1024, 425, 1024, 425, 0.2, myYellow, myPink);
            Pipe myPipe = new Pipe(1024, -450, 1536, -450, 0.2, myYellow, myPink);
            Screen myScreen = new Screen(1024, 1024, 0, 0, 0.05, 450, 123, 450, 123, myYellow, myPink);
            Pipes myPipes = new Pipes();
            GameScene myGame= new GameScene(myPipes, myScores, myScreen, false, myFloor);

            /// <summary>
            //setting initial state of the game
            /// </summary>
            bool game_on = false;
            bool gameover = false;

            /// <summary>
            //the following function will execute until the user does not close the game
            /// </summary>
            while(!myWindow.CloseRequested){
                SplashKit.ProcessEvents();
                myWindow.Clear(Color.RGBColor(193, 154, 107));

                /// <summary>
                // to be executed when the game has ended and the scores are displayed on the final screen
                /// </summary>
                if (game_on == false && gameover == true){
                    myScreen.Move();
                    myFloor.Move();
                    myScreen.SkyDraw();
                    myScreen.ExitDraw();
                    myFloor.Draw();
                    myScores.FinalScores();
                    myScores.ReplayInstructions();
                    if (SplashKit.KeyTyped(KeyCode.KeypadEnter)){
                        myPipe.PX1 = 1024;
                        myPipe.PX2 = 1536;
                        myYellow.bird_Y = 300;
                        myPink.bird_Y = 300;
                        gameover = false;
                    }
                }

                /// <summary>
                //to be executed as long as the game is not closed
                /// </summary>
                myGame.Song();
        
                /// <summary>
                //to be executed when the game is currently being played by the user
                /// </summary>
                if (game_on == true && gameover == false){
                    myScreen.Move();
                    myFloor.Move();
                    myScreen.SkyDraw();
                    myPipes.AddPipes(myPipe);
                    myPipes.Move();
                    myPipes.Draw();
                    myFloor.Draw();
                    myGame.PipePass();
                    myScores.Draw();

                    if (myGame.Collision() == true){
                        myPipes.HitSounds();
                        gameover = true;
                        game_on = false;
                    } else {  
                        myPink.Bounce();
                        myPink.Speed();
                        myYellow.Bounce();
                        myYellow.Speed();
                        myYellow.Move();
                        myPink.Move();
                    }
                }

                /// <summary>
                //to be executed when the game hasnt started yet so the user is on the introduction screen
                /// </summary>
                if (game_on == false && gameover == false){
                    myScreen.Move();
                    myFloor.Move();
                    myScreen.SkyDraw();
                    myScreen.IntroDraw();               
                    myFloor.Draw();
                    myPink.Move();
                    myScores.PlayInstructions();
                    myScores.Current_S = 0;
                    if (SplashKit.KeyTyped(KeyCode.SpaceKey)){
                        game_on = true;
                    }
                }
                myWindow.Refresh();
            }

            myWindow.Close();
            myWindow = null;
        }
    }
}