using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Datastructures {
    /// <summary>
    /// A priority queue, the node with the highest priority will always be first in line here
    /// </summary>
    /// <typeparam name="T">The item-type to queue</typeparam>
    public class PriorityQueue<T> {
        #region Variables
        /// <summary>
        /// The list of notes
        /// </summary>
        PriorityNode<T>[] heap;
        /// <summary>
        /// The size of the heap (not the max size, but current)
        /// </summary>
        int size;

        /// <summary>
        /// Indicates whether the queue is empty or not
        /// </summary>
        public bool isEmpty {
            get {
                return size == 0;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// A simple constructor
        /// </summary>
        public PriorityQueue() {
            heap = new PriorityNode<T>[5];
            size = 0;
        }
        #endregion

        #region Functions
        #region Private Functions
        /// <summary>
        /// Prints the heap
        /// </summary>
        /// <param name="i">The index from which to print</param>
        /// <param name="t">How many tabs deep we are</param>
        private void PrintHeap(int i, int t) {
            if (i > size)
                return;

            PrintHeap(i * 2 + 1, t + 1);

            for (int j = 0; j < t; j++)
                Console.Write('\t');
            Console.WriteLine("P: {1}", heap[i].node, heap[i].priority);

            PrintHeap(i * 2, t + 1);

        }

        /// <summary>
        /// Goes down the tree, swapping every item that is in the incorrect spot
        /// </summary>
        /// <param name="i">The index from which to percolate</param>
        private void PercolateDown(int i) {
            if (i * 2 > size) // If we are at max size, return. nothing to do
                return;
            else if (i * 2 == size) { // If we only have a child node, we are in the wrong function. go to the correct one
                PercolateDownLeft(i);
                return;
            }

            int left = i * 2; // The index of our left child
            int right = i * 2 + 1; // The index of our right child
            int smallest = heap[left].priority > heap[right].priority ? right : left; // Get which of our childs has the highest priority

            if (heap[i].priority > heap[smallest].priority) { // If our priority is lower, we need to swap
                heap[0] = heap[i]; // We can use the 0th index for swapping since we don't use that
                heap[i] = heap[smallest];
                heap[smallest] = heap[0];

                if (smallest * 2 <= size) { // If the swapped node has a left node, we need to go down there as well
                    if (smallest * 2 + 1 <= size) // Also checck for a right child
                        PercolateDown(smallest);

                    PercolateDownLeft(smallest);
                }
            }
        }

        /// <summary>
        /// Checks if the object is in the correct spot with its left child
        /// </summary>
        /// <param name="i"></param>
        private void PercolateDownLeft(int i) {
            int left = i * 2;
            if (heap[i].priority > heap[left].priority) {
                heap[0] = heap[i];
                heap[i] = heap[left];
                heap[left] = heap[0];
            }
        }

        /// <summary>
        /// Doubles the array
        /// </summary>
        private void DoubleArray() {
            PriorityNode<T>[] temp = new PriorityNode<T>[heap.Length * 2];
            for (int i = 1; i < heap.Length; i++)
                temp[i] = heap[i];

            heap = temp;
        }

        /// <summary>
        /// Checks if the node is already in the queue
        /// </summary>
        /// <param name="n">The node to check for</param>
        /// <returns>True if the node is present in the heap, false if not</returns>
        private bool HeapContainsNode(T n) {
            foreach (PriorityNode<T> node in heap) {
                if (node == null)
                    continue;
                if (node.node.Equals(n))
                    return true;
            }
            return false;
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// Adds a new item to the queue
        /// </summary>
        /// <param name="node">The node to add</param>
        /// <param name="priority">The priority of the node</param>
        public void Insert(T node, int priority) {
            if (node == null)
                return;

            if (HeapContainsNode(node)) // We return if the node is either null or already in the heap
                return;

            if (size + 1 == heap.Length)
                DoubleArray(); // If the array would get full, double it first

            PriorityNode<T> n = new PriorityNode<T>(node, priority);

            int hole = ++size; // We have a hole at the end check from
            heap[0] = n; // Store the node in the 0th index so we can percolate it down

            for (; n.priority <= heap[hole / 2].priority && hole > 1; hole /= 2) // We start at the end of our tree, while our new node's priority if higher, we go up and move all the nodes down
                heap[hole] = heap[hole / 2];

            heap[hole] = n;
        }

        /// <summary>
        /// Gets the highest priority item in the queue
        /// </summary>
        /// <returns>The highest priority item</returns>
        public T GetHighestPriority() {
            if (size == 0)
                return default(T); // If we are empty, return null or zero or whatever the default value of an item is

            if (size == 1) 
                return heap[size--].node; // If we only have 1 node, we won't have to worry about keeping the prioritys right

            // Else we get our node, move our last node to the start and percolate it down
            T n = heap[1].node;

            heap[1] = heap[size--];

            PercolateDown();

            return n;
        }

        /// <summary>
        /// Prints the heap
        /// </summary>
        public void PrintHeap() {
            PrintHeap(1, 0);
        }

        /// <summary>
        /// Goes up the tree, swapping every item that is not in the correct spot
        /// </summary>
        /// <param name="i">The index to percolate from</param>
        public void PercolateUp(int i) {
            if (i == 1) // Our first node doesn't have any parents ( it's an orphan QQ ), we won't have to percolate then
                return;

            if (heap[i / 2].priority < heap[i].priority) { // If our parent has a lower priority, swap and continue to percolate
                heap[0] = heap[i];
                heap[i] = heap[i / 2];
                heap[i / 2] = heap[0];

                PercolateUp(i / 2);
            }
        }

        /// <summary>
        /// Goes down the tree, swapping every item that is not in the correct spot
        /// </summary>
        public void PercolateDown() {
            PercolateDown(1);
        }
        #endregion
        #endregion
    }

    /// <summary>
    /// A simple node that contains both the node and its priority
    /// </summary>
    /// <typeparam name="T">The item-type to queue</typeparam>
    class PriorityNode<T> {
        #region Variables
        /// <summary>
        /// The node stored
        /// </summary>
        public T node;
        /// <summary>
        /// The priority of the node
        /// </summary>
        public int priority;
        #endregion

        #region Constructors
        /// <summary>
        /// A simple constructor
        /// </summary>
        /// <param name="node">The node to store</param>
        /// <param name="priority">The priority of the node</param>
        public PriorityNode(T node, int priority) {
            this.node = node;
            this.priority = priority;
        }
        #endregion
    }
}
