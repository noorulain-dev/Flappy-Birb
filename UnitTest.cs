using System;
using SplashKitSDK;
using NUnit.Framework;

namespace FlappyBird{
    [TestFixture()]
    public class BounceBirdTest{

        [Test()]
        /// <summary>
		/// Testing the bounce function of the abstract class FlappyBird
		/// </summary>
        public void TestBounce(){
            Window myWindow = new Window("Flappy Bird by Noor Ul Ain", 1024, 520);
            Scores myScores = new Scores(myWindow, 0, 0);
            YellowBird myYellow = new YellowBird(400, 300, 0.05, 20, false, myScores, 15, 0.05);
            PinkBird myPink = new PinkBird(400, 300, 0.05, 20, false, myScores, 15, 0.05);
            myYellow.SpaceDown = true;

            myYellow.Bounce();

            Assert.AreEqual(myYellow.bird_Y, myPink.bird_Y);

            myPink.Bounce();

            Assert.AreEqual(myPink.bird_Y, myYellow.bird_Y);
        }

        [Test()]
        /// <summary>
		/// Testing the speed function of the abstract class FlappyBird
		/// </summary>
        public void TestSpeed(){
            Window myWindow = new Window("Flappy Bird by Noor Ul Ain", 1024, 520);
            Scores myScores = new Scores(myWindow, 0, 0);
            YellowBird myYellow = new YellowBird(400, 300, 0.05, 20, false, myScores, 15, 0.05);
            PinkBird myPink = new PinkBird(400, 300, 0.05, 20, false, myScores, 15, 0.05);
            myYellow.SpaceDown = true;

            myYellow.Speed();

            Assert.AreEqual(Convert.ToInt32(myYellow.bird_Y), Convert.ToInt32(myPink.bird_Y));

            myPink.Speed();

            Assert.AreEqual(Convert.ToInt32(myYellow.bird_Y), Convert.ToInt32(myPink.bird_Y));
        }
    }
}