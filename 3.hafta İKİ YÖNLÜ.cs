using System;
using System.Collections.Generic;

namespace DoublyLinkedListExample
{
    // Düğüm (Node) yapısı
    class Node
    {
        public int Data;
        public Node Prev;
        public Node Next;

        public Node(int data)
        {
            Data = data;
        }
    }

    // İki yönlü bağlı liste
    class DoublyLinkedList
    {
        private Node head;
        private Node tail;

        // Başa ekleme
        public void AddFirst(int data)
        {
            Node newNode = new Node(data);

            if (head == null)
                head = tail = newNode;
            else
            {
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
            }
        }

        // Sona ekleme
        public void AddLast(int data)
        {
            Node newNode = new Node(data);

            if (head == null)
                head = tail = newNode;
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
        }

        // Belirli bir veriden SONRA ekleme
        public void AddAfter(int afterData, int newData)
        {
            Node current = head;
            while (current != null && current.Data != afterData)
                current = current.Next;

            if (current == null)
            {
                Console.WriteLine($"{afterData} bulunamadı!");
                return;
            }

            Node newNode = new Node(newData);
            newNode.Next = current.Next;
            newNode.Prev = current;

            if (current.Next != null)
                current.Next.Prev = newNode;
            else
                tail = newNode;

            current.Next = newNode;
        }

        // Belirli bir veriden ÖNCE ekleme
        public void AddBefore(int beforeData, int newData)
        {
            Node current = head;
            while (current != null && current.Data != beforeData)
                current = current.Next;

            if (current == null)
            {
                Console.WriteLine($"{beforeData} bulunamadı!");
                return;
            }

            Node newNode = new Node(newData);
            newNode.Next = current;
            newNode.Prev = current.Prev;

            if (current.Prev != null)
                current.Prev.Next = newNode;
            else
                head = newNode;

            current.Prev = newNode;
        }

        // Baştan silme
        public void RemoveFirst()
        {
            if (head == null) return;

            if (head.Next == null)
                head = tail = null;
            else
            {
                head = head.Next;
                head.Prev = null;
            }
        }

        // Sondan silme
        public void RemoveLast()
        {
            if (tail == null) return;

            if (tail.Prev == null)
                head = tail = null;
            else
            {
                tail = tail.Prev;
                tail.Next = null;
            }
        }

        // Aradan silme (veri ile)
        public void Remove(int data)
        {
            Node current = head;

            while (current != null && current.Data != data)
                current = current.Next;

            if (current == null)
            {
                Console.WriteLine($"{data} bulunamadı!");
                return;
            }

            if (current.Prev != null)
                current.Prev.Next = current.Next;
            else
                head = current.Next;

            if (current.Next != null)
                current.Next.Prev = current.Prev;
            else
                tail = current.Prev;
        }

        // Arama
        public bool Search(int data)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data == data)
                    return true;
                current = current.Next;
            }
            return false;
        }

        // Listeleme
        public void Display()
        {
            Node current = head;
            Console.Write("Liste: ");
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        // Tümünü silme
        public void Clear()
        {
            head = tail = null;
        }

        // Linked List → Diziye çevirme
        public int[] ToArray()
        {
            List<int> list = new List<int>();
            Node current = head;

            while (current != null)
            {
                list.Add(current.Data);
                current = current.Next;
            }

            return list.ToArray();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList list = new DoublyLinkedList();

            list.AddFirst(10);
            list.AddLast(20);
            list.AddLast(30);
            list.AddBefore(20, 15);
            list.AddAfter(30, 35);

            list.Display(); // 10 15 20 30 35

            list.RemoveFirst();
            list.RemoveLast();
            list.Display(); // 15 20 30

            list.Remove(20);
            list.Display(); // 15 30

            Console.WriteLine("30 var mı? " + list.Search(30));

            int[] dizi = list.ToArray();
            Console.WriteLine("Diziye aktarıldı: " + string.Join(", ", dizi));

            list.Clear();
            list.Display(); // Boş liste
        }
    }
}
