using System;
using System.Threading;

namespace Snake
{
    class Snake
    {
        int height = 30;
        int width = 30;
        ConsoleKeyInfo info = new ConsoleKeyInfo();
        char key = 'W';
        
        int objectPosX;
        int objectPosY;
        int parts = 3;

        Random rand = new Random();
        int[] X = new int[50];
        int[] Y = new int[50];
        Snake()
        {
            X[0] = 5;
            Y[0] = 5;
            Console.CursorVisible = false;
            objectPosX = rand.Next(1, (width - 2));
            objectPosY = rand.Next(1, (height - 2));
        }
        static void Main(string[] args)
        {
            Snake snake = new Snake();
            while (true)
            {
                snake.SetBoard();
                snake.SetInput();
                snake.Logic();
            }
        }

        void SetBoard()
        {
            Console.Clear();
            for(int i = 1; i <= (width+2); i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.Write("-");
            }
            for (int i = 1; i <= (width + 2); i++)
            {
                Console.SetCursorPosition(i, (height+2));
                Console.Write("-");
            }
            for (int i = 1; i <= (height + 1); i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("|");
            }
            for (int i = 1; i <= (height + 1); i++)
            {
                Console.SetCursorPosition((width+2), i);
                Console.Write("|");
            }
        }

        void SetPlayer(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("@");
        }

        void SetObject(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("$");
        }

        void Logic()
        {
            if(X[0] == objectPosX)
            {
                if(Y[0] == objectPosY)
                {
                    parts++;
                    objectPosX = rand.Next(1, (width-2));
                    objectPosY = rand.Next(1, (height - 2));

                }
            }
            for(int i = parts; i > 1; i--)
            {
                X[i - 1] = X[i - 2];
                Y[i - 1] = Y[i - 2];
            }
            switch(key)
            {
                case 'w':
                    Y[0]--;
                    break;
                case 'a':
                    X[0]--;
                    break;
                case 's':
                    Y[0]++;
                    break;
                case 'd':
                    X[0]++;
                    break;
            }
            for(int i = 0; i <= (parts-1); i++)
            {
                SetPlayer(X[i], Y[i]);
                SetObject(objectPosX, objectPosY);
            }
            Thread.Sleep(100);
        }

        void SetInput()
        {
            if(Console.KeyAvailable)
            {
                info = Console.ReadKey(true);
                key = info.KeyChar;
            }
        }
    }
}
