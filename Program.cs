using System;
using System.Threading;

namespace Waz
{
    class Waz
    {
        int wysokoscPlanszy = 30;
        int szerokoscPlanszy = 30;
        ConsoleKeyInfo info = new ConsoleKeyInfo();
        char klawisz = 'W';

        int owocX;
        int owocY;
        int czesciWeza = 3;

        int wynik;

        bool przegrana = false;

        int predkosc;

        Random losowyWynik = new Random();
        int[] X = new int[50];
        int[] Y = new int[50];
        Waz()
        {
            X[0] = 5;
            Y[0] = 5;
            Console.CursorVisible = false;
            owocX = losowyWynik.Next(1, (szerokoscPlanszy - 2));
            owocY = losowyWynik.Next(1, (wysokoscPlanszy - 2));
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Prosty waz w C#");
            Console.WriteLine("Wybierz poziom trudnosci gry");
            Console.WriteLine("1 - Latwy");
            Console.WriteLine("2 - Sredni");
            Console.WriteLine("3 - Trudny");

            int option = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (option)
            {
                case 1:
                    Waz waz1 = new Waz();
                    waz1.predkosc = 100;
                    while (!waz1.przegrana)
                    {
                        waz1.UstawPlansze();
                        waz1.UstawPrzyciski();
                        waz1.Logika();
                    }
                    break;
                case 2:
                    Waz waz2 = new Waz();
                    waz2.predkosc = 50;
                    while (!waz2.przegrana)
                    {
                        waz2.UstawPlansze();
                        waz2.UstawPrzyciski();
                        waz2.Logika();
                    }
                    break;
                case 3:
                    Waz waz3 = new Waz();
                    waz3.predkosc = 30;
                    while(!waz3.przegrana)
                    {
                        waz3.UstawPlansze();
                        waz3.UstawPrzyciski();
                        waz3.Logika();
                    }
                    break;
            }

         /*  Waz waz = new Waz();
            while (!waz.przegrana)
            {
                waz.UstawPlansze();
                waz.UstawPrzyciski();
                waz.Logika();
            }*/
        }

        void UstawPlansze()
        {
            Console.Clear();
            for (int i = 1; i <= (szerokoscPlanszy + 2); i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.Write("-");
            }
            for (int i = 1; i <= (szerokoscPlanszy + 2); i++)
            {
                Console.SetCursorPosition(i, (wysokoscPlanszy + 2));
                Console.Write("-");
            }
            for (int i = 1; i <= (wysokoscPlanszy + 1); i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("|");
            }
            for (int i = 1; i <= (wysokoscPlanszy + 1); i++)
            {
                Console.SetCursorPosition((szerokoscPlanszy + 2), i);
                Console.Write("|");
            }
        }

        void SetPlayer(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("O");
        }

        void SetObject(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("$");
        }

        void Logika()
        {
            if (X[0] == owocX)
            {
                if (Y[0] == owocY)
                {
                    czesciWeza++;
                    owocX = losowyWynik.Next(1, (szerokoscPlanszy - 2));
                    owocY = losowyWynik.Next(1, (wysokoscPlanszy - 2));
                    wynik++;
                }
            }
            for (int i = czesciWeza; i > 1; i--)
            {
                X[i - 1] = X[i - 2];
                Y[i - 1] = Y[i - 2];
            }

            if (X[0] > szerokoscPlanszy)
            {
                Przegrana();
            }

            if (Y[0] > wysokoscPlanszy)
            {
                Przegrana();
            }

            if(Y[0] == 2)
            {
                Przegrana();
            }

            if(X[0] == 2)
            {
                Przegrana();
            }

            switch (klawisz)
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
            for (int i = 0; i <= (czesciWeza - 1); i++)
            {
                SetPlayer(X[i], Y[i]);
                SetObject(owocX, owocY);
            }
            Thread.Sleep(predkosc);
        }

        void UstawPrzyciski()
        {
            if (Console.KeyAvailable)
            {
                info = Console.ReadKey(true);
                klawisz = info.KeyChar;
            }
        }

        void Przegrana()
        {
            przegrana = true;
            Console.Clear();
            Console.WriteLine("Twoj wynik: " + wynik);
        }
    }
}
