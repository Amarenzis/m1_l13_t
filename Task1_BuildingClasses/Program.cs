using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_BuildingClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region Исходные
                //Легкий тест в комментариях ниже
                /*
                string addressBuilding = "СПб, ул., д.";
                double lengthBuilding = 13.1;
                double widthBuilding = 5.4;
                double heightBuilding = 6.3;
                int levelBuilding = 2;
                */

                //Внесение данных с консоли
                Console.WriteLine("Внесите адрес здания:");
                string addressBuilding = Console.ReadLine();
                Console.WriteLine("Внесите длину здания:");
                double lengthBuilding = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Внесите ширину здания:");
                double widthBuilding = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Внесите высоту здания:");
                double heightBuilding = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Внесите этажность здания:");
                int levelBuilding = Convert.ToInt32(Console.ReadLine());

                #endregion

                //Выдача результатов.
                
                MultiBuilding building = new MultiBuilding(addressBuilding, lengthBuilding, widthBuilding, heightBuilding, levelBuilding);                
                building.Print();

                //Тесты работы родительского Print
                //Building building1 = new Building(addressBuilding, lengthBuilding, widthBuilding, heightBuilding);
                //building1.Print();
            }
            //Отлавливаем исключения
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Придётся закрыть программу.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Придётся закрыть программу.");
            }

            Console.ReadKey();

        }
    }
    class Building
    {
        //основные поля
        public string address { get; set; }
        private protected double length;
        private protected double width;
        private protected double height;

        //Свойства
        public double Length
        {
            set
            {
                if (value > 0)
                {
                    length = value;
                }
                else
                {
                    Console.WriteLine("Значение длины не может быть отрицательным или равным 0.");
                    throw new ArgumentOutOfRangeException();
                }
            }
            get
            {
                return length;
            }
        }
        public double Width
        {
            set
            {
                if (value > 0)
                {
                    width = value;
                }
                else
                {
                    Console.WriteLine("Значение ширины не может быть отрицательным или равным 0.");
                    throw new ArgumentOutOfRangeException();
                }
            }
            get
            {
                return width;
            }
        }
        public double Height
        {
            set
            {
                if (value > 0)
                {
                    height = value;
                }
                else
                {
                    Console.WriteLine("Значение высоты не может быть отрицательным или равным 0.");
                    throw new ArgumentOutOfRangeException();
                }
            }
            get
            {
                return height;
            }
        }

        //Конструктор
        public Building(string ad, double l, double w, double h)
        {
            this.address = ad;
            Length = l;
            Width = w;
            Height = h;
        }
        //Метод вывода информации
        public void Print()
        {
            Console.WriteLine("\nАдрес здания: {0}.\nДлина здания - {1:f2} м.\nШирина здания - {2:f2} м.\nВысота здания - {3:f2} м.", address, length, width, height);
        }
    }
    sealed class MultiBuilding:Building
    {
        //Поле этажности
        private int level;

        //Свойство
        public int Level
        {
            set
            {
                if (value > 0)
                {
                    level = value;
                }
                else
                {
                    Console.WriteLine("Количество этажей не может быть отрицательным или равным 0.");
                    throw new ArgumentOutOfRangeException();
                }
            }
            get
            {
                return level;
            }
        }
        public MultiBuilding( string ad, double l, double w, double h, int lev)
            :base(ad,l,w,h)
        {
            Level = lev;
        }

        new public void Print()
        {
            base.Print();
            Console.WriteLine("Этажность здания - {0} эт.", level);
        }
    }
}
