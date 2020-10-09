using System;
using System.Collections.Generic;

namespace Task_37
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isExit = true;
            Aviary aviaryOne = new Aviary(new Boar());
            Aviary aviaryTwo = new Aviary(new Tiger());
            Aviary aviaryThree = new Aviary(new Donkey());
            Aviary aviaryFour = new Aviary(new Duck());

            while (isExit)
            {
                Console.WriteLine("выберите действие\n\n1 - подойти к первому вольеру\n\n2 - подойти ко второму вольеру\n\n3 - подойти к третьему вольеру\n\n4 - подойти к четвертому вольеру\n\n5 - выйти\n\n");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        aviaryOne.ShowInfo();
                        break;
                    case 2:
                        aviaryTwo.ShowInfo();
                        break;
                    case 3:
                        aviaryThree.ShowInfo();
                        break;
                    case 4:
                        aviaryFour.ShowInfo();
                        break;
                    case 5:
                        isExit = false;
                        break;
                }
                Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
    class Aviary
    {
        private int _countAnimals;
        private List<Animal> _animals = new List<Animal>();
        public Aviary(Animal animal)
        {
            Random rand = new Random();
            _countAnimals = rand.Next(1, 5);

            for (int i = 0; i < _countAnimals; i++)
            {
                _animals.Add(animal);
            }                   
        }
        public void ShowInfo()
        {
            int man = 0;
            int woman = 0;
            for (int i = 0; i < _animals.Count; i++)
            {
                if(_animals[i].Gender == "Мужской")
                {
                    man += 1;
                }
                else
                {
                    woman += 1;
                }                
            }
            _animals[0].ShowInfo();

            Console.WriteLine($"\nВ этом вольере таких животных {_animals.Count}, {man} мужского пола, {woman} женского пола\n");            
        }
    }
    class Animal 
    {
        protected string Name;
        private string _gender;
        protected string Noise;
        public string Gender
        {
            get
            {
                return _gender;
            }
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Это животное называется {Name}, оно издает звук {Noise}");
        }
        public Animal()
        {
            Random rand = new Random();
            int gender = rand.Next(1, 3);

            switch (gender)
            {
                case 1:
                    _gender = "Мужской";
                    break;
                case 2:
                    _gender = "Женский";
                    break;
            }
        }
    }
    class Boar : Animal
    {
        public Boar() 
        {
            Name = "Кабан";
            Noise = "Хрю-Хрю";
        }
    }
    class Tiger : Animal
    {
        public Tiger() 
        {
            Name = "Тигр";
            Noise = "Рррр";
        }
    }
    class Donkey : Animal
    {
        public Donkey()
        {
            Name = "Ослик";
            Noise = "Иа-Иа";
        }
    }
    class Duck : Animal
    {
        public Duck()
        {
            Name = "Утка";
            Noise = "Кря-Кря";
        }
    }
}
