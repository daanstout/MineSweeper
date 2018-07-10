using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Datastructures {
    /// <summary>
    /// A simple queue system. The first node is is also the first node out (AKA FIFO)
    /// </summary>
    /// <typeparam name="T">The item-type to store</typeparam>
    public class Queue<T> {
        #region Variables
        /// <summary>
        /// An array of the items
        /// </summary>
        T[] queue;
        /// <summary>
        /// The front index of the queue
        /// </summary>
        int front;
        /// <summary>
        /// The back index of the queue
        /// </summary>
        int back;
        /// <summary>
        /// The max size of the queue
        /// </summary>
        int queueMaxSize;
        /// <summary>
        /// The current size of the queue
        /// </summary>
        int queueSize;
        /// <summary>
        /// Indicates whether the queue is empty or not
        /// </summary>
        public bool isEmpty {
            get {
                return queueSize == 0;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Simple constructor
        /// </summary>
        public Queue() {
            queueMaxSize = 5;
            queue = new T[queueMaxSize];
            front = back = queueSize = 0; // Optional
        }
        #endregion

        #region Functions
        #region Private Functions
        /// <summary>
        /// Doubles the queue
        /// </summary>
        private void DoubleQueue() {
            T[] temp = new T[queueMaxSize * 2]; // Create a new queue twice the size as our current one
            for (int i = 0; i < queueMaxSize; i++) {
                temp[i] = queue[(i + back) % queueMaxSize]; // Fill the new array. i + back makes sure the index we have is of the (i + 1)th item and we use modulo maxsize to make sure we don't overgo our queue
            }
            back = queueMaxSize;
            front = 0;
            queueMaxSize *= 2;
            queue = temp; // then we set the values to the correct sizes
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// Adds an item to the queue
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item) {
            if (queueSize == queueMaxSize) // If our array is full, double it
                DoubleQueue();
            queue[back++] = item; // put the item at the back
            queueSize++;
            back %= queueMaxSize; // Make sure our back doesn't overgo it's max value
        }

        /// <summary>
        /// Returns the first item in the queue
        /// </summary>
        /// <returns></returns>
        public T Dequeue() {
            if (queueSize == 0) // If there is nothing in the queue, we return the default value of T
                return default(T);
            T item = queue[front];
            queue[front++] = default(T); // Set the default value to T (not needed but used as a safety precaution)
            queueSize--;
            front %= queueMaxSize; // Make sure our front indicater loops around the queue
            return item;
        }

        /// <summary>
        /// Empties the array
        /// </summary>
        public void makeEmpty() {
            for (int i = 0; i < queueMaxSize; i++) {
                queue[i] = default(T); // Reset all the values (not needed but used as a safety precaution
            }
            front = back = queueSize = 0;
        }
        #endregion
        #endregion
    }
}
