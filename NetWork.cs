using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteLogico
{
    public class NetWork
    {
        public void Connect(List<Node> nodes, int previus, int next)
        {
            var node = nodes.Where(node => node.Value == previus).FirstOrDefault();
            var nextNode = nodes.Where(node => node.Value == next).FirstOrDefault();

            if (node.Next == null)
            {
                var newNode = new Node(nextNode.Value);
                node.Next = newNode;
            }
            else
            {
                var newNode = new Node(node.Value);
                newNode.Next = new Node(nextNode.Value);
                nodes.Add(newNode);
            }

            if (nextNode.Next == null)
            {
                var newNode = new Node(node.Value);
                nextNode.Next = newNode;
            }
            else
            {
                var newNode = new Node(nextNode.Value);
                newNode.Next = new Node(node.Value);
                nodes.Add(newNode);
            }
        }

        public bool Query(int goal, List<Node> nodes, List<int> traveledNodes, Node currentNode)
        {

            if (currentNode.Next == null)
            {
                return false;
            }
            if (currentNode.Next.Value == goal)
            {
                return true;
            }
            var filtredNodes = nodes.Where(node => node.Value == currentNode.Next.Value && !traveledNodes.Contains(node.Value)).ToList();

            foreach (var node in filtredNodes)
            {
                if (node.Next != null)
                {
                    traveledNodes.Add(node.Value);
                    var res = Query(goal, nodes, traveledNodes, node);
                    if (res)
                    {
                        return res;
                    }
                }
            }
            return false;
        }
    }
}
