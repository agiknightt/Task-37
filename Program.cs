using System;
using System.Collections.Generic;

namespace Task_37
{
    class Program
    {
        static void Main(string[] args)
        {
            ZooPark zooPark = new ZooPark();

            bool isExit = true;

            zooPark.AddAviary(new Aviary(new Boar()));
            zooPark.AddAviary(new Aviary(new Tiger()));
            zooPark.AddAviary(new Aviary(new Donkey()));
            zooPark.AddAviary(new Aviary(new Duck()));

            while (isExit)
            {
                Console.WriteLine("выберите действие\n\n");

                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine($"{i + 1} - подойти к  вольеру № {i + 1}\n\n");
                }

                Console.WriteLine("5 - выйти\n\n");

                int userInput = Convert.ToInt32(Console.ReadLine());
                if(userInput != 5)
                {
                    zooPark.ShowAviary(userInput - 1);
                }
                else
                {
                    isExit = false;
                }
                Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
    class ZooPark
    {
        private List<Aviary> _aviaries = new List<Aviary>();
        public void AddAviary(Aviary aviary)
        {
            _aviaries.Add(aviary);            
        }
        public void ShowAviary(int numberAviary)
        {
            _aviaries[numberAviary].ShowInfo();
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
    abstract class Animal 
    {
        protected string Name;
        private string _gender;
        protected string Noise;
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
