using System;
using System.Collections.Generic;
using System.Configuration;
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
                _staticValues = (StaticValuesSection)System.Configuration.ConfigurationManager.GetSection("staticValues");

                Console.WriteLine("Ctrl+C - выход из приложения");
                Console.WriteLine();

                Console.WriteLine("W - атаковать монстра");
                Console.WriteLine("A - купить у торговца оружие");
                Console.WriteLine("D - купить у торговца одежду");
                Console.WriteLine("S - подлечиться у лекаря");
                Console.WriteLine("E - совершить автоматический ход");
                Console.WriteLine();

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
                    }
                    catch (EngineException ex)
                    {
                        Console.WriteLine();
                        Console.WriteLine(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Возникла непредвиденная ошибка: {0}", ex);
                    }
                }
            }
            catch(ConfigurationErrorsException ex)
            {
                Console.WriteLine("Ошибка конфигурирования: {0}", ex.Message);
                Console.WriteLine();
                Console.WriteLine("Нажмите Enter для завершения работы");
                Console.Read();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Возникла непредвиденная ошибка: {0}", ex);
                Console.WriteLine();
                Console.WriteLine("Нажмите Enter для завершения работы");
                Console.Read();
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
                _game.Hero.Died += Hero_Died;
            }
        }

        private static void StopGame()
        {
            if (_game != null)
            {
                _game.Hero.Died -= Hero_Died;
                _game = null;
            }
        }

        private static void Hero_Died(object sender, EventArgs e)
        {
            Console.WriteLine("Игрок умер:(");
            StopGame();
        }
    }
}
