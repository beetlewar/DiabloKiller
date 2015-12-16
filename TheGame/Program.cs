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
        static IStaticValues _staticValues;

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("W - атаковать монстра");
                Console.WriteLine("A - купить у торговца оружие");
                Console.WriteLine("D - купить у торговца одужду");
                Console.WriteLine("S - подлучиться у лекаря");
                Console.WriteLine("E - совершить автоматический ход");
                Console.WriteLine();

                _staticValues = (StaticValues)System.Configuration.ConfigurationManager.GetSection("staticValues");

                Console.WriteLine("Стоимость оружия = {0}", _staticValues.WeaponPrice);
                Console.WriteLine("Стоимость одежды = {0}", _staticValues.ArmorPrice);
                Console.WriteLine();

                while (true)
                {
                    try
                    {
                        StartNewGameIfRequired();

                        Console.WriteLine();
                        Console.WriteLine("Состояние:");
                        Console.WriteLine();
                        Console.WriteLine(_game.Hero);

                        Console.WriteLine();
                        Console.WriteLine("Сделайте ход");

                        var key = Console.ReadKey();
                        Console.WriteLine();
                        _game.ProcessKey(key.Key);

                        Console.WriteLine();
                    }
                    catch (EngineException ex)
                    {
                        Console.WriteLine();
                        Console.WriteLine(ex.Message);
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

        private static void StartNewGameIfRequired()
        {
            if (_game == null)
            {
                Console.WriteLine("Начинается новая игра");

                _game = new Game(_staticValues);
                _game.Hero.Died += Heroe_Died;
            }
        }

        private static void StopGame()
        {
            if (_game != null)
            {
                _game.Hero.Died -= Heroe_Died;
                _game = null;
            }
        }

        private static void Heroe_Died(object sender, EventArgs e)
        {
            Console.WriteLine("Игрок умер:(");
            StopGame();
        }
    }
}
