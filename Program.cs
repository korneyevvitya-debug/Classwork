using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Oak oak = new Oak(5, 10, 0);
            Tree tree = new Tree(10, 5);
            Tree hiddenOak = new Oak(5, 10, 0, 2);
            //hiddenOak.Info();
            //hiddenOak.Grow();
            //hiddenOak.Info();
            Tree[] trees = new Tree[3] { oak, hiddenOak, tree };
            for (int i = 0; i < trees.Length; i++)
            {
                if (trees[i] is Oak)
                {
                    Oak t = trees[i] as Oak;
                    Console.WriteLine(t.Apples);
                }
            }
            //for (int i = 0; i<= trees.Length; i++)
            //{
            //    Oak s = trees[i] as Oak;
            //    if(s != null)
            //    {
            //        Console.WriteLine(s.Apples);
            //    }
            //}

        }
    }
    public class Tree
    {
        protected double _height;
        protected int _branches;
        protected int _age;
        public int Age => _age;

        public Tree (double height, int branches)
        {
            _age = 0;
            _height = height;
            _branches = branches;
        }
        public virtual void Grow()
        {
            _age++;
            if (_height <= 100)
            {
                _height *= 1.2;
                _branches += 2;
            }
        }
        public virtual void Info()
        {
            Console.Write($"Age: {_age} \t Height: {_height}m \t Amount of branches: {_branches}");
        }
    }
    public class Oak : Tree
    {
        private int _apples; //Yes, apples grow on oaks
        public int Apples => _apples;
        public Oak(double height, int branches, int apples = 0) : base(height, branches)
        {
            _apples = Math.Min(apples, branches);
        }
        public Oak(double height, int branches, int age, int apples = 0) : this(height, branches, apples)
        {
            _age = age;
        }
        public override void Grow()
        {
            base.Grow();
            _apples += Math.Min(10, _branches-_apples);
        }
        public int Harvest(int apples = Int32.MaxValue)
        {
            int applesInBasket = Math.Min(apples, _apples);
            _apples -= applesInBasket;
            return applesInBasket;
        }
        public override void Info()
        {
            base.Info();
            Console.WriteLine($", Apples: {_apples}");
        }
    }
}
