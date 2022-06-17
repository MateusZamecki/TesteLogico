using System;
using System.Collections.Generic;
using System.Linq;

namespace TesteLogico
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            var network = new NetWork();
            var nodes = new List<Node>();

            Console.WriteLine("Enter a quantity of elements");
            int number = int.Parse(Console.ReadLine());
            for (int count = 1; count <= number; count++)
            {
                nodes.Add(new Node(count));
            }

            Console.WriteLine("______________Connect______________  ");

            var exit = 1;
            while (exit != 0)
            {
                Console.WriteLine("___________First element___________");
                var previus = int.Parse(Console.ReadLine());

                Console.WriteLine("___________Second element__________");
                var next = int.Parse(Console.ReadLine());

                if (previus > number || next > number)
                {
                    throw new Exception("Invalid Element");
                }

                network.Connect(nodes, previus, next);
                nodes = nodes.OrderBy(node => node.Value).ToList();


                Console.WriteLine("______________Exit______________: 0");
                exit = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("______________Query______________");
            var exitQuery = 1;

            while (exitQuery != 0)
            {
                Console.WriteLine("___________First element___________");
                var first = int.Parse(Console.ReadLine());

                Console.WriteLine("___________Second element__________");
                var goal = int.Parse(Console.ReadLine());

                if (first > number || goal > number)
                {
                    throw new Exception("Invalid Element");
                }

                var currentNode = nodes.Where(node => node.Value == first).FirstOrDefault();
                var response = network.Query(goal, nodes, new List<int>(), currentNode);


                Console.WriteLine("_________Response: ", response);
                Console.WriteLine("______________Exit______________: 0");

                exitQuery = int.Parse(Console.ReadLine());
            }
        }
    }
}
