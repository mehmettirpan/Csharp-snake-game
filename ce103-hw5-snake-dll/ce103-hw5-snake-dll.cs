using System;
using System.Threading;

namespace ce103_hw5_snake_functions
{
    public class Ce103_Func
    {
        public const int SNAKE_ARRAY_SIZE = 310;
        public const ConsoleKey UP_ARROW = ConsoleKey.UpArrow;
        public const ConsoleKey LEFT_ARROW = ConsoleKey.LeftArrow;
        public const ConsoleKey RIGHT_ARROW = ConsoleKey.RightArrow;
        public const ConsoleKey DOWN_ARROW = ConsoleKey.DownArrow;
        public const ConsoleKey ENTER_KEY = ConsoleKey.Enter;
        public const ConsoleKey EXIT_BUTTON = ConsoleKey.Escape; // ESC
        public const ConsoleKey PAUSE_BUTTON = ConsoleKey.P; //p
        const char SNAKE_HEAD = (char)125;
        const char SNAKE_BODY = (char)62;
        const char WALL = (char)219;
        const char FOOD = (char)64;
        const char BLANK = ' ';


        public ConsoleKey waitForAnyKey()
        {
            ConsoleKey pressed;

            while (!Console.KeyAvailable) ;

            pressed = Console.ReadKey(false).Key;
            //pressed = tolower(pressed);
            return pressed;
        }
        public int getGameSpeed()
        {
            int sp33d = 10;
            Console.Clear();
            Console.Write("Select The game speed between 1 and 9 and pr3ss enter");
            int selection = Convert.ToUInt16(Console.ReadLine());
            switch (selection)
            {
                case 1:
                    sp33d = 40;
                    break;
                case 2:
                    sp33d = 35;
                    break;
                case 3:
                    sp33d = 30;
                    break;
                case 4:
                    sp33d = 25;
                    break;
                case 5:
                    sp33d = 20;
                    break;
                case 6:
                    sp33d = 15;
                    break;
                case 7:
                    sp33d = 15;
                    break;
                case 8:
                    sp33d = 10;
                    break;
                case 9:
                    sp33d = 5;
                    break;

            }
            return sp33d;
        }

        public void pauseMenu()
        {

            Console.SetCursorPosition(28, 23);
            Console.Write("***Paused***");

            waitForAnyKey();
            Console.SetCursorPosition(28, 23);
            Console.Write("            ");
            return;
        }

        //This function checks if a key has pr3ss, then checks if its any of the arrow keys/ p/esc key. It changes d1rection acording to the key pr3ss.
        public ConsoleKey checkKeyspress(ConsoleKey d1rection)
        {
            ConsoleKey pr3ss;

            if (Console.KeyAvailable == true) //If a key has been pr3ss
            {
                pr3ss = Console.ReadKey(false).Key;
                if (d1rection != pr3ss)
                {
                    if (pr3ss == DOWN_ARROW && d1rection != UP_ARROW)
                    {
                        d1rection = pr3ss;
                    }
                    else if (pr3ss == UP_ARROW && d1rection != DOWN_ARROW)
                    {
                        d1rection = pr3ss;
                    }
                    else if (pr3ss == LEFT_ARROW && d1rection != RIGHT_ARROW)
                    {
                        d1rection = pr3ss;
                    }
                    else if (pr3ss == RIGHT_ARROW && d1rection != LEFT_ARROW)
                    {
                        d1rection = pr3ss;
                    }
                    else if (pr3ss == EXIT_BUTTON || pr3ss == PAUSE_BUTTON)
                    {
                        pauseMenu();
                    }
                }
            }
            return (d1rection);
        }
        //Cycles around checking if the x y coordinates ='s the snake coordinates as one of this parts
        //One thing to note, a snake of length 4 cannot collide with itself, therefore there is no need to call this function when the snakes length is <= 4
        public bool collisionSnake(int xa, int ya, int[,] snak3XY, int snakeL3ngth, int d3tect)
        {
            int b;
            for (b = d3tect; b < snakeL3ngth; b++) //Checks if the snake collided with itself
            {
                if (xa == snak3XY[0, b] && ya == snak3XY[1, b])
                    return true;
            }
            return false;
        }
        //Generates food & Makes sure the food doesn't appear on top of the snake <- This sometimes causes a lag issue!!! Not too much of a problem tho
        public void generateFood(int[] f00dXY, int w1dth, int he1ght, int[,] snak3XY, int snakeL3ngth)
        {
            Random RandomNumb3rs = new Random();
            do
            {
                //RandomNumb3rs.Seed(time(null));
                f00dXY[0] = RandomNumb3rs.Next() % (w1dth - 2) + 2;
                //RandomNumb3rs.Seed(time(null));
                f00dXY[1] = RandomNumb3rs.Next() % (he1ght - 6) + 2;
            } while (collisionSnake(f00dXY[0], f00dXY[1], snak3XY, snakeL3ngth, 0)); //This should prevent the "Food" from being created on top of the snake. - However the food has a chance to be created ontop of the snake, in which case the snake should eat it...

            Console.SetCursorPosition(f00dXY[0], f00dXY[1]);
            Console.Write(FOOD);
        }

        /*
        Moves the snake array forward, i.e. 
        This:
         x 1 2 3 4 5 6
         y 1 1 1 1 1 1
        Becomes This:
         x 1 1 2 3 4 5
         y 1 1 1 1 1 1

         Then depending on the d1rection (in this case west - left) it becomes:

         x 0 1 2 3 4 5
         y 1 1 1 1 1 1

         snak3XY[0][0]--; <- if d1rection left, take 1 away from the x coordinate
        */
        public void moveSnakeArray(int[,] snak3XY, int snakeL3ngth, ConsoleKey d1rection)
        {
            int i;
            for (i = snakeL3ngth - 1; i >= 1; i--)
            {
                snak3XY[0, i] = snak3XY[0, i - 1];
                snak3XY[1, i] = snak3XY[1, i - 1];
            }

            /*
            because we dont actually know the new snakes head x y, 
            we have to check the d1rection and add or take from it depending on the d1rection.
            */
            switch (d1rection)
            {
                case DOWN_ARROW:
                    snak3XY[1, 0]++;
                    break;
                case RIGHT_ARROW:
                    snak3XY[0, 0]++;
                    break;
                case UP_ARROW:
                    snak3XY[1, 0]--;
                    break;
                case LEFT_ARROW:
                    snak3XY[0, 0]--;
                    break;
            }

            return;
        }

        /**
        *
        *	  @name   Move Snake Body (move)
        *
        *	  @brief Move snake body
        *
        *	  Moving snake body
        *
        *	  @param  [in] snak3XY [\b int[,]]  snake coordinates
        *	  
        *	  @param  [in] snakeL3ngth [\b int]  index of fibonacci number in the serie
        *	  
        *	  @param  [in] d1rection [\b ConsoleKey]  index of fibonacci number in the serie
        **/
        public void move(int[,] snak3XY, int snakeL3ngth, ConsoleKey d1rection)
        {
            int x;
            int y;

            //Remove the tail ( HAS TO BE DONE BEFORE THE ARRAY IS MOVED!!!!! )
            x = snak3XY[0, snakeL3ngth - 1];
            y = snak3XY[1, snakeL3ngth - 1];

            Console.SetCursorPosition(x, y);
            Console.Write(BLANK);

            //Changes the head of the snake to a body part
            Console.SetCursorPosition(snak3XY[0, 0], snak3XY[1, 0]);
            Console.Write(SNAKE_BODY);

            moveSnakeArray(snak3XY, snakeL3ngth, d1rection);

            Console.SetCursorPosition(snak3XY[0, 0], snak3XY[1, 0]);
            Console.Write(SNAKE_HEAD);

            Console.SetCursorPosition(1, 1); //Gets rid of the darn flashing underscore.

            return;
        }


        /**
        *
        *	  @name   eatfood (eat)
        *
        *	  @brief Snake eat food
        *
        *	  Eating @
        *
        *	  @param  [in] snak3XY [\b int[,]]  snake coordinates
        *	  
        *	  @param  [in] f00dXY [\b int]  index of fibonacci number in the serie
        *	  
        *	  
        **/
        //This function checks if the snakes head his on top of the food, if it is then it'll generate some more food...
        public bool eatFood(int[,] snak3XY, int[] f00dXY)
        {
            if (snak3XY[0, 0] == f00dXY[0] && snak3XY[1, 0] == f00dXY[1])
            {
                f00dXY[0] = 0;
                f00dXY[1] = 0; //This should prevent a nasty bug (loops) need to check if the bug still exists...

                return true;
            }

            return false;
        }


        /**
        *
        *	  @name   Collision Detection (console)
        *
        *	  @brief Detection of collision
        *
        *	  Collision Detection
        *
        *	  @param  [in] snak3XY [\b int[,]]  snake coordinates
        *	  
        *	  @param  [in] consoleW1dth [\b int]  console witdh
        *	  
        *	  @param  [in] snakeL3ngth [\b int]  snake length
        **/

        public bool collisionDetection(int[,] snak3XY, int consoleW1dth, int consoleHe1ght, int snakeL3ngth) //Need to Clean this up a bit
        {
            bool colision = false;
            if ((snak3XY[0, 0] == 1) || (snak3XY[1, 0] == 1) || (snak3XY[0, 0] == consoleW1dth) || (snak3XY[1, 0] == consoleHe1ght - 4)) //Checks if the snake collided wit the wall or it's self
                colision = true;
            else
                if (collisionSnake(snak3XY[0, 0], snak3XY[1, 0], snak3XY, snakeL3ngth, 1)) //If the snake collided with the wall, theres no point in checking if it collided with itself.
                colision = true;

            return (colision);
        }


        /**
        *
        *	  @name   Refresh Bar (refresh)
        *
        *	  @brief Refresh menu
        *
        *	  Refresh bar
        *
        *	  @param  [in] sc0re [\b int]  snake coordinates
        *	  
        *	  @param  [in] sp33d [\b int]  index of fibonacci number in the serie
        *	  
        *	  
        **/
        public void refreshInfoBar(int score, int sp33d)
        {
            Console.SetCursorPosition(5, 23);
            Console.Write("Score: " + score);

            Console.SetCursorPosition(5, 24);
            Console.Write("Speed: " + sp33d);

            Console.SetCursorPosition(52, 23);
            Console.Write("Coder: Mehmet TIRPAN");

            Console.SetCursorPosition(52, 24);
            Console.Write("Version: 1.0");

            return;
        }


        /**
        *
        *	  @name   youWinScreen (win)
        *
        *	  @brief Win screen
        *
        *	  Win Screen
        *
        *	  
        **/

        public void youWinScreen()
        {
            int x = 6, y = 7;
            Console.SetCursorPosition(x, y++);
            Console.Write("'##:::'##::'#######::'##::::'##::::'##:::::'##:'####:'##::: ##:'####:");
            Console.SetCursorPosition(x, y++);
            Console.Write(". ##:'##::'##.... ##: ##:::: ##:::: ##:'##: ##:. ##:: ###:: ##: ####:");
            Console.SetCursorPosition(x, y++);
            Console.Write(":. ####::: ##:::: ##: ##:::: ##:::: ##: ##: ##:: ##:: ####: ##: ####:");
            Console.SetCursorPosition(x, y++);
            Console.Write("::. ##:::: ##:::: ##: ##:::: ##:::: ##: ##: ##:: ##:: ## ## ##:: ##::");
            Console.SetCursorPosition(x, y++);
            Console.Write("::: ##:::: ##:::: ##: ##:::: ##:::: ##: ##: ##:: ##:: ##. ####::..:::");
            Console.SetCursorPosition(x, y++);
            Console.Write("::: ##:::: ##:::: ##: ##:::: ##:::: ##: ##: ##:: ##:: ##:. ###:'####:");
            Console.SetCursorPosition(x, y++);
            Console.Write("::: ##::::. #######::. #######:::::. ###. ###::'####: ##::. ##: ####:");
            Console.SetCursorPosition(x, y++);
            Console.Write(":::..::::::.......::::.......:::::::...::...:::....::..::::..::....::");
            Console.SetCursorPosition(x, y++);

            waitForAnyKey();
            Console.Clear(); //clear the console
            return;
        }


        /**
        *
        *	  @name   Game Over Screen 
        *
        *	  @brief Game Over Screen
        *
        *	  Game Over Screen
        *
        *	 
        **/
        public void gam3OverScreen()
        {
            int x = 17, y = 3;

            //http://www.network-science.de/ascii/ <- Ascii Art Gen

            Console.SetCursorPosition(x, y++);
            Console.Write(":'######::::::'###::::'##::::'##:'########:\n");
            Console.SetCursorPosition(x, y++);
            Console.Write("'##... ##::::'## ##::: ###::'###: ##.....::\n");
            Console.SetCursorPosition(x, y++);
            Console.Write(" ##:::..::::'##:. ##:: ####'####: ##:::::::\n");
            Console.SetCursorPosition(x, y++);
            Console.Write(" ##::'####:'##:::. ##: ## ### ##: ######:::\n");
            Console.SetCursorPosition(x, y++);
            Console.Write(" ##::: ##:: #########: ##. #: ##: ##...::::\n");
            Console.SetCursorPosition(x, y++);
            Console.Write(" ##::: ##:: ##.... ##: ##:.:: ##: ##:::::::\n");
            Console.SetCursorPosition(x, y++);
            Console.Write(". ######::: ##:::: ##: ##:::: ##: ########:\n");
            Console.SetCursorPosition(x, y++);
            Console.Write(":......::::..:::::..::..:::::..::........::\n");
            Console.SetCursorPosition(x, y++);
            Console.Write(":'#######::'##::::'##:'########:'########::'####:\n");
            Console.SetCursorPosition(x, y++);
            Console.Write("'##.... ##: ##:::: ##: ##.....:: ##.... ##: ####:\n");
            Console.SetCursorPosition(x, y++);
            Console.Write(" ##:::: ##: ##:::: ##: ##::::::: ##:::: ##: ####:\n");
            Console.SetCursorPosition(x, y++);
            Console.Write(" ##:::: ##: ##:::: ##: ######::: ########::: ##::\n");
            Console.SetCursorPosition(x, y++);
            Console.Write(" ##:::: ##:. ##:: ##:: ##...:::: ##.. ##::::..:::\n");
            Console.SetCursorPosition(x, y++);
            Console.Write(" ##:::: ##::. ## ##::: ##::::::: ##::. ##::'####:\n");
            Console.SetCursorPosition(x, y++);
            Console.Write(". #######::::. ###:::: ########: ##:::. ##: ####:\n");
            Console.SetCursorPosition(x, y++);
            Console.Write(":.......::::::...:::::........::..:::::..::....::\n");

            waitForAnyKey();
            Console.Clear(); //clear the console
            return;
        }

        /**
        *
        *	  @name   Start Game (start)
        *
        *	  @brief Start Game 
        *
        *	  Collision Detection
        *
        *	  @param  [in] snak3XY [\b int[,]]  snake coordinates
        *	  
        *	  @param  [in] consoleW1dth [\b int]  console witdh
        *	  
        *	  @param  [in] consoleHe1ght [\b int]  console Height
        *	  
        *	   @param  [in] snakeL3ngth [\b int]  snake length
        *	   
        *	   @param  [in] d1rection [\b Console Key]  d1rection
        *	   
        *
        *	   
        *	   @param  [in] sc0re [\b int]  sc0re
        *	   
        *	   @param  [in] sp33d [\b int]  sp33d
        **/



        //Messy, need to clean this function up
        public void startGame(int[,] snak3XY, int[] f00dXY, int consoleW1dth, int consoleHe1ght, int snakeL3ngth, ConsoleKey d1rection, int sc0re, int sp33d)
        {
            bool gam3Over = false;
            ConsoleKey oldDirection = ConsoleKey.NoName;
            bool canChangeDirection = true;
            int gam3Over2 = 1;
            do
            {
                if (canChangeDirection)
                {
                    oldDirection = d1rection;
                    d1rection = checkKeyspress(d1rection);
                }

                if (oldDirection != d1rection)//Temp fix to prevent the snake from colliding with itself
                    canChangeDirection = false;

                if (true) //haha, it moves according to how fast the computer running it is...
                {
                    //Console.SetCursorPosition(1,1);
                    //Console.Write("%d - %d",clock() , endWait);
                    move(snak3XY, snakeL3ngth, d1rection);
                    canChangeDirection = true;


                    if (eatFood(snak3XY, f00dXY))
                    {
                        generateFood(f00dXY, consoleW1dth, consoleHe1ght, snak3XY, snakeL3ngth); //Generate More Food
                        snakeL3ngth++;
                        switch (sp33d)
                        {
                            case 90:
                                sc0re += 5;
                                break;
                            case 80:
                                sc0re += 7;
                                break;
                            case 70:
                                sc0re += 9;
                                break;
                            case 60:
                                sc0re += 12;
                                break;
                            case 50:
                                sc0re += 15;
                                break;
                            case 40:
                                sc0re += 20;
                                break;
                            case 30:
                                sc0re += 23;
                                break;
                            case 20:
                                sc0re += 25;
                                break;
                            case 10:
                                sc0re += 30;
                                break;
                        }

                        refreshInfoBar(sc0re, sp33d);
                    }
                    Thread.Sleep(sp33d);
                }

                gam3Over = collisionDetection(snak3XY, consoleW1dth, consoleHe1ght, snakeL3ngth);

                if (snakeL3ngth >= SNAKE_ARRAY_SIZE - 5) //Just to make sure it doesn't get longer then the array size & crash
                {
                    gam3Over2 = 2;//You Win! <- doesn't seem to work - NEED TO FIX/TEST THIS
                    sc0re += 1500; //When you win you get an extra 1500 points!!!
                }

            } while (!gam3Over);

            switch (gam3Over2)
            {
                case 1:
                    gam3OverScreen();

                    break;
                case 2:
                    youWinScreen();
                    break;
            }



            return;
        }

        /**
        *
        *	  @name   Load Environment (environment)
        *
        *	  @brief Load environment
        *
        *	  Load Environment
        *
        *	  @param  [in] consoleWitdh [\b int]  consoleWitdh
        *	  
        *	  @param  [in] consoleHe1ght [\b int]  consoleHe1ght
        *	  
        *	  
        **/
        public void loadEnviroment(int consoleW1dth, int consoleHe1ght)//This can be done in a better way... FIX ME!!!! Also i think it doesn't work properly in ubuntu <- Fixed
        {

            int x = 1, y = 1;
            int rectangleHeight = consoleHe1ght - 4;
            Console.Clear(); //clear the console

            Console.SetCursorPosition(x, y); //Top left corner

            for (; y < rectangleHeight; y++)
            {
                Console.SetCursorPosition(x, y); //Left Wall 
                Console.Write("#", WALL);

                Console.SetCursorPosition(consoleW1dth, y); //Right Wall
                Console.Write("#", WALL);
            }

            y = 1;
            for (; x < consoleW1dth + 1; x++)
            {
                Console.SetCursorPosition(x, y); //Left Wall 
                Console.Write("#", WALL);

                Console.SetCursorPosition(x, rectangleHeight); //Right Wall
                Console.Write("#", WALL);
            }


            return;
        }

        /**
        *
        *	  @name   Load Snake (Snake)
        *
        *	  @brief Load Snake
        *
        *	  Load Environment
        *
        *	  @param  [in] snak3XY [\b int]  snak3XY
        *	  
        *	  @param  [in] snakeL3ngth [\b int]  snakeL3ngth
        *	  
        *	  
        **/
        public void loadSnake(int[,] snak3XY, int snakeL3ngth)
        {
            int i;
            /*
            First off, The snake doesn't actually have enough XY coordinates (only 1 - the starting location), thus we use
            these XY coordinates to "create" the other coordinates. For this we can actually use the function used to move the snake.
            This helps create a "whole" snake instead of one "dot", when someone starts a game.
            */
            //moveSnakeArray(snak3XY, snakeL3ngth); //One thing to note ATM, the snake starts of one coordinate to whatever d1rection it's pointing...

            //This should print out a snake :P
            for (i = 0; i < snakeL3ngth; i++)
            {
                Console.SetCursorPosition(snak3XY[0, i], snak3XY[1, i]);
                Console.Write("%c", SNAKE_BODY); //Meh, at some point I should make it so the snake starts off with a head...
            }

            return;
        }

        /* NOTE, This function will only work if the snakes starting d1rection is left!!!! 
        Well it will work, but the results wont be the ones expected.. I need to fix this at some point.. */

        /**
        *
        *	  @name   prepairSnakeArray (prepair snake)
        *
        *	  @brief Prepair Snake Array
        *
        *	  Prepair Snake Array
        *
        *	  @param  [in] snak3XY [\b int]  snak3XY
        *	  
        *	  @param  [in] snakeL3ngth [\b int]  snakeL3ngth
        *	  
        *	  
        **/
        public void prepairSnakeArray(int[,] snak3XY, int snakeL3ngth)
        {
            int i;
            int snakeX = snak3XY[0, 0];
            int snakeY = snak3XY[1, 0];

            // this is used in the function move.. should maybe create a function for it...



            for (i = 1; i <= snakeL3ngth; i++)
            {
                snak3XY[0, i] = snakeX + i;
                snak3XY[1, i] = snakeY;
            }

            return;
        }

        /**
        *
        *	  @name   Load Game (Load Game)
        *
        *	  @brief Load Game
        *
        *	  Load Game
        *
        *	  
        **/
        //This function loads the enviroment, snake, etc
        public void loadGame()
        {
            int[,] snak3XY = new int[2, SNAKE_ARRAY_SIZE]; //Two Dimentional Array, the first array is for the X coordinates and the second array for the Y coordinates

            int snakeL3ngth = 4; //Starting Length

            ConsoleKey d1rection = ConsoleKey.LeftArrow; //DO NOT CHANGE THIS TO RIGHT ARROW, THE GAME WILL INSTANTLY BE OVER IF YOU DO!!! <- Unless the prepairSnakeArray function is changed to take into account the d1rection....

            int[] f00dXY = { 5, 5 };// Stores the location of the food

            int sc0re = 0;
            //int level = 1;

            //Window Width * Height - at some point find a way to get the actual dimensions of the console... <- Also somethings that display dont take this dimentions into account.. need to fix this...
            int consoleW1dth = 80;
            int consoleHe1ght = 25;

            int sp33d = getGameSpeed();

            //The starting location of the snake
            snak3XY[0, 0] = 40;
            snak3XY[1, 0] = 10;

            loadEnviroment(consoleW1dth, consoleHe1ght); //borders
            prepairSnakeArray(snak3XY, snakeL3ngth);
            loadSnake(snak3XY, snakeL3ngth);
            generateFood(f00dXY, consoleW1dth, consoleHe1ght, snak3XY, snakeL3ngth);
            refreshInfoBar(sc0re, sp33d); //Bottom info bar. Score, Level etc
            startGame(snak3XY, f00dXY, consoleW1dth, consoleHe1ght, snakeL3ngth, d1rection, sc0re, sp33d);

            return;
        }

        //**************MENU STUFF**************//

        /**
        *
        *	  @name   menuSelector (menuSelector)
        *
        *	  @brief menu Selector
        *
        *	  Menu Selector
        *
        *	  @param  [in] x [\b int]  x
        *	  
        *	  @param  [in] y [\b int]  y
        *	  
        *	  @param  [in] yStart [\b int]  yStart
        *	  
        *	  
        **/
        public int menuSelector(int x, int y, int yStart)
        {
            char key;
            int i = 0;
            x = x - 2;
            Console.SetCursorPosition(x, yStart);

            Console.Write(">");

            Console.SetCursorPosition(1, 1);


            do
            {
                key = (char)waitForAnyKey();
                //Console.Write("%c %d", key, (int)key);
                if (key == (char)UP_ARROW)
                {
                    Console.SetCursorPosition(x, yStart + i);
                    Console.Write(" ");

                    if (yStart >= yStart + i)
                        i = y - yStart - 2;
                    else
                        i--;
                    Console.SetCursorPosition(x, yStart + i);
                    Console.Write(">");
                }
                else
                    if (key == (char)DOWN_ARROW)
                {
                    Console.SetCursorPosition(x, yStart + i);
                    Console.Write(" ");

                    if (i + 2 >= y - yStart)
                        i = 0;
                    else
                        i++;
                    Console.SetCursorPosition(x, yStart + i);
                    Console.Write(">");
                }
                //Console.SetCursorPosition(1,1);
                //Console.Write("%d", key);
            } while (key != (char)ENTER_KEY); //While doesn't equal enter... (13 ASCII code for enter) - note ubuntu is 10
            return (i);
        }

        /**
        *
        *	  @name   Welcome Art (Welcome Art)
        *
        *	  @brief Welcome Art
        *
        *	  Welcome Art
        *
        *	  
        **/
        public void welcomeArt()
        {
            Console.Clear(); //clear the console
                             //Ascii art reference: http://www.chris.com/ascii/index.php?art=animals/reptiles/snakes
            Console.Write("\n");
            Console.Write("\t\t    _________         _________ 			\n");
            Console.Write("\t\t   /         \\       /         \\ 			\n");
            Console.Write("\t\t  /  /~~~~~\\  \\     /  /~~~~~\\  \\ 			\n");
            Console.Write("\t\t  |  |     |  |     |  |     |  | 			\n");
            Console.Write("\t\t  |  |     |  |     |  |     |  | 			\n");
            Console.Write("\t\t  |  |     |  |     |  |     |  |         /	\n");
            Console.Write("\t\t  |  |     |  |     |  |     |  |       //	\n");
            Console.Write("\t\t (o  o)    \\  \\_____/  /     \\  \\_____/ / 	\n");
            Console.Write("\t\t  \\__/      \\         /       \\        / 	\n");
            Console.Write("\t\t    |        ~~~~~~~~~         ~~~~~~~~ 		\n");
            Console.Write("\t\t    ^											\n");
            Console.Write("\t		Welcome To The Snake Game!			\n");
            Console.Write("\t			    Press Any Key To Continue...	\n");
            Console.Write("\n");

            waitForAnyKey();
            return;
        }

        /**
        *
        *	  @name   Controls (Controls)
        *
        *	  @brief Controls of game
        *
        *	  Game Control
        *
        *	  
        **/
        public void controls()
        {
            int x = 10, y = 5;
            Console.Clear(); //clear the console
            Console.SetCursorPosition(x, y++);
            Console.Write("Controls\n");
            Console.SetCursorPosition(x++, y++);
            Console.Write("Use the following arrow keys to direct the snake to the food: ");
            Console.SetCursorPosition(x, y++);
            Console.Write("Right Arrow");
            Console.SetCursorPosition(x, y++);
            Console.Write("Left Arrow");
            Console.SetCursorPosition(x, y++);
            Console.Write("Top Arrow");
            Console.SetCursorPosition(x, y++);
            Console.Write("Bottom Arrow");
            Console.SetCursorPosition(x, y++);
            Console.SetCursorPosition(x, y++);
            Console.Write("P & Esc pauses the game.");
            Console.SetCursorPosition(x, y++);
            Console.SetCursorPosition(x, y++);
            Console.Write("Press any key to continue...");
            waitForAnyKey();
            return;
        }

        /**
        *
        *	  @name   exitXY (exit)
        *
        *	  @brief Exit from game
        *
        *	  Exit Game
        *
        *	  
        **/
        public void exitYN()
        {
            char pr3ss;
            Console.SetCursorPosition(9, 8);
            Console.Write("Are you sure you want to exit(Y/N)\n");

            do
            {
                pr3ss = (char)waitForAnyKey();
                pr3ss = char.ToLower(pr3ss);
            } while (!(pr3ss == 'y' || pr3ss == 'n'));

            if (pr3ss == 'y')
            {
                Console.Clear(); //clear the console
                Environment.Exit(1);
            }
            return;
        }

        /**
        *
        *	  @name  Main Menu (Main Menu)
        *
        *	  @brief Main Menu
        *
        *	  Main Menu
        *
        *	  
        **/
        public int mainMenu()
        {
            int a = 10, b = 5;
            int ab = b;

            int selection;

            Console.Clear(); //clear the console
                             //Might be better with arrays of strings???
            Console.SetCursorPosition(a, b++);
            Console.Write("New Game\n");
            Console.SetCursorPosition(a, b++);
            Console.Write("High Scores\n");
            Console.SetCursorPosition(a, b++);
            Console.Write("Controls\n");
            Console.SetCursorPosition(a, b++);
            Console.Write("Exit\n");
            Console.SetCursorPosition(a, b++);

            selection = menuSelector(a, b, ab);

            return (selection);
        }

        //**************END MENU STUFF**************//





    }
}
