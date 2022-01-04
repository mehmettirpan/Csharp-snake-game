using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ce103_hw5_snake_functions;

namespace ce103_hw5_snake_test
{
    [TestClass]
    public class Snake_Test
    {


        [TestMethod]
        public void collisionDetection_test_1()
        {
            Ce103_Func eat = new Ce103_Func();
            int consoleWidth = 50;
            int consoleHeight = 50;
            int[,] snakeXY = new int[2, 310];
            snakeXY[0, 0] = 10;
            snakeXY[1, 0] = 20;
            int snakeLength = 10;
            bool situation = eat.collisionDetection(snakeXY, consoleWidth, consoleHeight, snakeLength);
            Assert.AreEqual(false, situation);
        }

        [TestMethod]
        public void collisionDetection_test_2()
        {
            Ce103_Func eat = new Ce103_Func();
            int consoleWidth = 50;
            int consoleHeight = 50;
            int[,] snakeXY = new int[2, 310];
            snakeXY[0, 0] = 10;
            snakeXY[1, 0] = 20;
            int snakeLength = 10;
            bool situation = eat.collisionDetection(snakeXY, consoleWidth, consoleHeight, snakeLength);
            Assert.AreEqual(false, situation);
        }

        [TestMethod]
        public void collisionDetection_test_3()
        {
            Ce103_Func eat = new Ce103_Func();
            int consoleWidth = 50;
            int consoleHeight = 50;
            int[,] snakeXY = new int[2, 310];
            snakeXY[0, 0] = 10;
            snakeXY[1, 0] = 20;
            int snakeLength = 10;
            bool situation = eat.collisionDetection(snakeXY, consoleWidth, consoleHeight, snakeLength);
            Assert.AreEqual(false, situation);
        }

        [TestMethod]
        public void eatfood_test_1()
        {
            Ce103_Func eat = new Ce103_Func();
            int[,] snakeXY = new int[2, 310];
            snakeXY[0, 0] = 20;
            snakeXY[1, 0] = 10;
            int[] foodXY = { 5, 5 };
            Assert.AreEqual(false, eat.eatFood(snakeXY, foodXY));
        }

        [TestMethod]
        public void eatfood_test_2()
        {
            Ce103_Func eat = new Ce103_Func();
            int[,] snakeXY = new int[2, 310];
            snakeXY[0, 0] = 20;
            snakeXY[1, 0] = 10;
            int[] foodXY = { 5, 5 };
            Assert.AreEqual(false, eat.eatFood(snakeXY, foodXY));
        }

        [TestMethod]
        public void eatfood_test_3()
        {
            Ce103_Func eat = new Ce103_Func();
            int[,] snakeXY = new int[2, 310];
            snakeXY[0, 0] = 20;
            snakeXY[1, 0] = 10;
            int[] foodXY = { 5, 5 };
            Assert.AreEqual(false, eat.eatFood(snakeXY, foodXY));
        }

        [TestMethod]
        public void collision_snake_test1()
        {
            Ce103_Func collision = new Ce103_Func();
            int[,] snakeXY = new int[2, 310];
            snakeXY[0, 0] = 50;
            snakeXY[1, 0] = 20;
            Assert.AreEqual(false, collision.collisionSnake(29, 3, snakeXY, 9, 1));
        }

        [TestMethod]
        public void collision_snake_test2()
        {
            Ce103_Func collision = new Ce103_Func();
            int[,] snakeXY = new int[2, 310];
            snakeXY[0, 0] = 50;
            snakeXY[1, 0] = 20;
            Assert.AreEqual(false, collision.collisionSnake(29, 3, snakeXY, 9, 1));
        }

        [TestMethod]
        public void collision_snake_test3()
        {
            Ce103_Func collision = new Ce103_Func();
            int[,] snakeXY = new int[2, 310];
            snakeXY[0, 0] = 50;
            snakeXY[1, 0] = 20;
            Assert.AreEqual(false, collision.collisionSnake(29, 3, snakeXY, 9, 1));
        }
    }
}
