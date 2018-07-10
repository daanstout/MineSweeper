using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Datastructures {
    /// <summary>
    /// A simple Stack system. The first item in is the last item to leave (AKA FILO)
    /// </summary>
    /// <typeparam name="T">The item-type to store</typeparam>
    public class Stack<T> {
        #region Variables
        /// <summary>
        /// The stack
        /// </summary>
        T[] stack;
        /// <summary>
        /// The index of the top element
        /// </summary>
        int top;
        /// <summary>
        /// The max size of the stack
        /// </summary>
        int maxStackSize;
        /// <summary>
        /// The amount of elements in our stack
        /// </summary>
        int stackSize;
        /// <summary>
        /// Indicates whether the stack is empty
        /// </summary>
        public bool isEmpty {
            get {
                return stackSize == 0;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Simple constructor
        /// </summary>
        public Stack() : this(5) { }

        /// <summary>
        /// Simple constructor
        /// </summary>
        /// <param name="size">The starting size of our stack (default = 5)</param>
        public Stack(int size) {
            maxStackSize = size;
            stack = new T[maxStackSize];
            top = stackSize = 0;
        }
        #endregion

        #region Functions
        /// <summary>
        /// Pops an item (returns it)
        /// </summary>
        /// <returns>The top item</returns>
        public T Pop() {
            if (stackSize == 0) // If the stack is empty, return the default value
                return default(T);
            top = stackSize -= 1;
            return stack[top + 1];
        }

        /// <summary>
        /// Pushes an item onto the stack
        /// </summary>
        /// <param name="data">The item to push</param>
        public void Push(T data) {
            if (stackSize == maxStackSize) // If we are at max capacity, double the size
                DoubleStack();
            top = stackSize += 1;
            stack[top] = data;
        }

        /// <summary>
        /// Returns the top element without removing it from the stack, so you can peak at what's at the top
        /// </summary>
        /// <returns>The item at the top (doesn't get removed like with Pop())</returns>
        public T Top() {
            return stack[top];
        }

        /// <summary>
        /// Doubles the stack size
        /// </summary>
        private void DoubleStack() {
            T[] temp = new T[maxStackSize * 2];
            for (int i = 0; i < maxStackSize; i++)
                temp[i] = stack[i];
            maxStackSize *= 2;
            stack = temp;
        }
        #endregion
    }
}
