using System;

namespace Tehtava
{
    abstract class DrawObject
    {
        public abstract void Draw();
    }

    class Box : DrawObject
    {
        public override void Draw()
        {
            Console.WriteLine("*********\n*       *\n*       *\n*       *\n*********\n");
        }
    }

    class Triangle : DrawObject
    {
        public override void Draw()
        {
            Console.WriteLine("    *\n   * *\n  * * *\n * * * *\n* * * * *\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Box box = new();
            Triangle triangle = new();

            box.Draw();
            triangle.Draw();
        }
    }
}