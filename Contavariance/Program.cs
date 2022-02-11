using System;
using System.Collections.Generic;

namespace Contavariance
{
    public class Animal
    {
        public void Eat() => Console.WriteLine("Eat");
    }

    public class Bird : Animal
    {
        public void Fly() => Console.WriteLine("Fly");
    }

    public class Human : Animal
    {

    }

    //variance
    delegate Animal ReturnAnimalDelegate();
    delegate Bird ReturnBirdDelegate();

    //contra variance
    delegate void TakeAnimalDelegate(Animal a);
    delegate void TakeBirdDelegate(Bird b);

    public interface IProcess<out T>
    {
        T Process();
    }

    public class AnimalProcessor<T> : IProcess<T>
    {
        public T Process()
        {
            throw new NotImplementedException();
        }
    }
    interface IZoo<in T>
    {
        void Add(T t);
    }

    public class Zoo<T> : IZoo<T>
    {
        public void Add(T t)
        {

        }
    }
    class Program
    {

        // in deleagte return type is coviant and the parameter are contravariant


        public static Animal GetAnimal() => new Animal();
        public static Bird GetBird() => new Bird();

        public static void Eat(Animal a) => a.Eat();
        public static void Fly(Bird b) => b.Fly();
        static void Main(string[] args)
        {
            // delegate

            #region delegate covairnce
            Animal a = new Bird();
            ReturnAnimalDelegate d = GetBird;
            ReturnAnimalDelegate d1 = GetAnimal;
            a = d();

            ReturnBirdDelegate bd = GetBird;

            // ReturnBirdDelegate bd = GetAnimal;  //error
            #endregion

            #region delegate Contravariance
            TakeAnimalDelegate d3 = Eat;

            TakeBirdDelegate d4 = Fly;
            TakeBirdDelegate d5 = Eat;  //contravarianr
            #endregion

            //arrays covarince
            Animal[] arr = new Bird[5];
            arr[0] = new Human();

            //generics covarance

            IProcess<Animal> process1 = new AnimalProcessor<Animal>();
            IProcess<Bird> process2 = new AnimalProcessor<Bird>();

            Animal bird = process2.Process();

            process1 = process2;

            IEnumerable<Animal> animals = new List<Bird>();


            //generic contravariance
            Animal an = new Bird();

            IZoo<Animal> animalZoo = new Zoo<Animal>();
            animalZoo.Add(new Animal());
            IZoo<Bird> birdZoo = new Zoo<Bird>();
            animalZoo.Add(new Bird());

            birdZoo = animalZoo;
            birdZoo.Add(new Bird());


        }

        public void Add(int a)
        {

        }
        public void Add(ref int a)
        {

        }
        //public static void Add(out int a)
        //{
        //    a = 5;
        //}
    }
}
