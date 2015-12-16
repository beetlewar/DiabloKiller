using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace TheGame
{
    class Program
    {
        static Game _game;

        static void Main(string[] args)
        {
            try
            {
                StartNewGame();
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Состояние:");
                        Console.WriteLine();
                        Console.WriteLine(_game.Heroe);

                        Console.WriteLine();
                        Console.WriteLine("Сделайте ход");

                        var key = Console.ReadKey();
                        _game.ProcessKey(key.Key);

                        Console.WriteLine();
                    }
                    catch (EngineException ex)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Возникла ошибка на уровне движка: {0}", ex);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Возника непредвиденная ошибка: {0}", ex);
                    }
                }
            }
            finally
            {
                StopGame();
            }
        }

        private static void StartNewGame()
        {
            StopGame();

            _game = new Game();
            _game.Heroe.Died += Heroe_Died;
        }

        private static void StopGame()
        {
            if (_game != null)
            {
                _game.Heroe.Died -= Heroe_Died;
                _game = null;
            }
        }

        private static void Heroe_Died(object sender, EventArgs e)
        {
            StartNewGame();
        }
    }
}
