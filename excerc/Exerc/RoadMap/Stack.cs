using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace excerc.Exerc.RoadMap
{
    public class Stack
    {
        static List<string> resParenthesis = new List<string>();

        public bool IsValid(string s)
        {
            if (s.Length % 2 != 0)
                return false;

            if (!(s.StartsWith('(') || s.StartsWith('[') || s.StartsWith('{')))
                return false;

            var stack = new Stack<char>();

            foreach (char c in s)
            {
                if (c == '(' || c == '{' || c == '[')
                    stack.Push(c);

                else if (c == ')' || c == '}' || c == ']')
                {
                    if (stack.Count == 0 || !IsMatchingBracket(stack.Peek(), c))
                        return 1 == 2;

                    stack.Pop();
                }
            }

            return stack.Count == 0;
        }
        private bool IsMatchingBracket(char open, char close)
        {
            return (open == '(' && close == ')') ||
                   (open == '{' && close == '}') ||
                   (open == '[' && close == ']');
        }
        public static int EvalRPN(string[] tokens)
        {
            var res = new Stack<int>();
            for (int i = 0; i < tokens.Length; i++)
            {
                int left;
                int right;

                switch (tokens[i])
                {
                    case "+":
                        right = res.Pop();
                        left = res.Pop();
                        res.Push(left + right);
                        break;
                    case "-":
                        right = res.Pop();
                        left = res.Pop();
                        res.Push(left - right);
                        break;
                    case "*":
                        right = res.Pop();
                        left = res.Pop();
                        res.Push(left * right);
                        break;
                    case "/":
                        right = res.Pop();
                        left = res.Pop();
                        res.Push(left / right);
                        break;
                    default:
                        res.Push(int.Parse(tokens[i]));
                        break;
                }
            }
            Console.WriteLine(res.Pop());
            return res.Pop();
        }
        public static IList<string> GenerateParenthesis(int n)
        {
            Recursive(" ", n, 0);
            return resParenthesis;
        }
        public static void Recursive(string current, int remaining, int leftCount)
        {
            if (remaining == 0 && leftCount == 0)
            {
                resParenthesis.Add(current);
                return;
            }
            if (remaining > 0)
                Recursive(current + "(", remaining - 1, leftCount + 1);
            if (leftCount > 0)
                Recursive(current + ")", remaining, leftCount - 1);
        }
        public static int[] DailyTemperatures(int[] temperatures)
        {
            var length = temperatures.Length;
            var res = new int[length];

            for (int i = 0; i < length - 1; i++)
            {
                if (temperatures[i] < temperatures[i + 1])
                {
                    res[i] = 1;
                    continue;
                }

                else
                {
                    for (int j = i + 1; j < length; j++)
                    {
                        if (temperatures[i] < temperatures[j])
                        {
                            res[i] = j - i;
                            break;
                        }
                    }
                }
            }

            return res;
        }
        public static int CarFleet(int target, int[] position, int[] speed)
        {
            var fleet = 1;
            int sl = speed.Length;
            int pl = position.Length;

            if (pl != sl)
                return 1;

            Array.Sort(position, speed, Comparer<int>.Create((b, a) => a - b));

            for (int i = 0; i < sl - 1; i++)
            {
                if (speed[i] == 0) continue;

                if (speed[i + 1] == 0)
                {
                    fleet++;
                    continue;
                }

                double x = (double)(target - position[i]) / speed[i];
                double y = (double)(target - position[i + 1]) / speed[i + 1];

                if (x < y) fleet++;

                else
                {
                    position[i + 1] = position[i];
                    speed[i + 1] = speed[i];
                }
            }

            return fleet;
        }
        public static int LargestRecangle(int[] heights)
        {
            int res = 0;
            var stack = new Stack<int>();

            for (int i = 0; i <= heights.Length; i++)
            {
                var height = i < heights.Length ? heights[i] : 0;

                while (stack.Any() && heights[stack.Peek()] > height)
                {
                    var currHeight = heights[stack.Pop()];
                    var prevIndex = stack.Count == 0 ? -1 : stack.Peek();

                    res = Math.Max(res, currHeight * (i - 1 - prevIndex));
                }

                stack.Push(i);
            }

            return res;
        }
        public static int LargestRectangleArea(int[] heights)
        {
            var stack = new Stack<int>();

            for (int i = 0; i < heights.Length - 1; i++)
            {
                while (heights[i] - heights[i + 1] > 0)
                {
                    i++;
                    var temp = heights[i] - heights[i + 1];
                    stack.Push(temp + heights[i + 1]);
                    if (stack.Count() > heights.Length) break;
                }
            }
            Console.WriteLine(stack.Max());

            return stack.Max();
        }
    }
    public class MinStack
    {
        Stack<int> stack = null;
        Stack<int> minimumStack = null;
        public MinStack()
        {
            stack = new Stack<int>();
            minimumStack = new Stack<int>();
        }

        public void Push(int val)
        {
            if (minimumStack.Count > 0)
            {
                int minimumValue = minimumStack.Peek();
                if (minimumValue >= val)
                {
                    minimumStack.Push(val);
                }
            }
            else
            {
                minimumStack.Push(val);
            }
            stack.Push(val);
        }
        public void Pop()
        {
            int val = 0;
            val = stack.Pop();
            if (minimumStack.Count > 0 && val == minimumStack.Peek())
            {
                minimumStack.Pop();
            }
        }
        public int Top()
        {
            return stack.Peek();
        }
        public int GetMin()
        {
            return minimumStack.Peek();
        }
    }
}
