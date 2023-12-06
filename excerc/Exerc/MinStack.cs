namespace exerc
{
    public class MinStack
    {
        Stack<int> stack = null;
        Stack<int> minStack = null;
        public MinStack()
        {
            stack = new Stack<int>();
            minStack = new Stack<int>();
        }

        public void Push(int val)
        {
            if (minStack.Count <= 0)
                minStack.Push(val);


            if (minStack.Peek() >= val)
                minStack.Push(val);

            stack.Push(val);
        }

        public void Pop()
        {
            int val = 0;
            val = stack.Pop();

            if (minStack.Count > 0 && val == minStack.Peek())
                minStack.Pop();
        }

        public int Top()
        {
            return stack.Peek();
        }

        public int GetMin()
        {
            return minStack.Peek();
        }
    }
}