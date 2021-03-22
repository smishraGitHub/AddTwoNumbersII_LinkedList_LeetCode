using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddTwoNumbersII_LinkedList_LeetCode
{

    public class Node
    {
        public int val;
        public Node next;

        public Node(int data)
        {
            val = data;
            next = null;
        }
    }
    public class LinkedList
    {
        Node root;

        public LinkedList()
        {
            root = null;
        }

        public void insertNode(int data)
        {
            Node newNode = new Node(data);
            if(root !=null)
            {
                newNode.next = root;
            }
            root = newNode;
        }

        public Node ReturnNode()
        {
            return root;
        }

        public void showList(Node root)
        {
            Node temp = root;
            while(temp !=null)
            {
                Console.Write(temp.val + " ");
                temp = temp.next;
            }
        }

        public Node ReverseNode(Node root)
        {
            if (root == null || root.next == null)
                return root;
            Node newNode = ReverseNode(root.next);
            root.next.next = root;
            root.next = null;

            return newNode;

        }

        public Node AddTwoNumbers(Node node1,Node node2)
        {
            if (node1 == null)
            {
                return node2;
            }
            else if(node2 == null)
            {
                return node1;
            }
            else
            {
                int carry = 0;
                int a2 = 0;
                Node result = null;

                while (node1 !=null && node2 !=null)
                {
                    int sum = node1.val + node2.val;

                    sum = sum + carry;
                    carry = 0;
                    if (sum >9)
                    {
                        int tsum = sum % 10 ;
                        carry = sum / 10;
                        sum = tsum;
                    }

                    Node newNode = new Node(sum);

                    if (result != null)
                    {
                        newNode.next = result;
                    }
                    result = newNode;

                    node1 = node1.next;
                    node2 = node2.next;
                }


                if (node1 !=null)
                {
                   while(node1 !=null)
                    {
                        int sum = node1.val + carry;

                        carry = 0;
                        if (sum > 9)
                        {
                            int tsum = sum % 10;
                            carry = sum / 10;
                            sum = tsum;
                        }

                        Node newNode = new Node(sum);

                        if (result != null)
                        {
                            newNode.next = result;
                        }
                        result = newNode;

                        node1 = node1.next;
                    }
                }

                if (node2 != null)
                {
                    while (node2 != null)
                    {
                        int sum = node2.val + carry;

                        carry = 0;
                        if (sum > 9)
                        {
                            int tsum = sum % 10;
                            carry = sum / 10;
                            sum = tsum;
                        }

                        Node newNode = new Node(sum);

                        if (result != null)
                        {
                            newNode.next = result;
                        }
                        result = newNode;

                        node2 = node2.next;
                    }
                }

                return result;
            }
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            LinkedList ls = new LinkedList();
            ls.insertNode(7);
            ls.insertNode(2);
            ls.insertNode(4);
            ls.insertNode(3);

            Node node1=ls.ReturnNode();

            ls.showList(node1);
            Console.WriteLine();

            LinkedList ls2 = new LinkedList();
            ls2.insertNode(5);
            ls2.insertNode(6);
            ls2.insertNode(4);
           

            Node node2 = ls2.ReturnNode();
            ls2.showList(node2);
            Console.WriteLine();

            Node node3 = ls.AddTwoNumbers(node1, node2);
            ls2.showList(node3);
            Console.ReadLine();
        }
    }
}
