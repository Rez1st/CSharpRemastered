using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack
{
    public class PostfixCalculator
    {
        private readonly ArrayStack<int> _stack = new ArrayStack<int>();
        private readonly string[] _tokenList = {"%", "/", "+", "-", "*"};

        private readonly Dictionary<string, Func<int, int, int>> _actions = new Dictionary<string, Func<int, int, int>>
        {
            {"%", (lhs, rhs) => lhs % rhs},
            {"/", (lhs, rhs) => lhs / rhs},
            {"*", (lhs, rhs) => lhs * rhs},
            {"+", (lhs, rhs) => lhs + rhs},
            {"-", (lhs, rhs) => lhs - rhs}
        };

        public int Process(string[] tokenSet)
        {
            var validationResult = ValidateTokens(tokenSet);

            if (string.IsNullOrEmpty(validationResult))
                Count(tokenSet);
            else
                throw new InvalidOperationException(validationResult);

            return _stack.Pop();
        }

        private string ValidateTokens(string[] tokenSet)
        {
            var validationResult = new StringBuilder();

            for (var i = 0; i < tokenSet.Length; i++)
                if (int.TryParse(tokenSet[i], out _))
                {
                }
                else
                {
                    if (!_tokenList.Any(x => x.Equals(tokenSet[i])))
                        validationResult.AppendLine($"{tokenSet[i]} - is not a valid token");
                }

            return validationResult.ToString();
        }

        private void Count(string[] tokenSet)
        {
            for (var i = 0; i < tokenSet.Length; i++)
            {
                _stack.Push(int.TryParse(tokenSet[i], out int value)
                    ? value
                    : _actions[tokenSet[i]].Invoke(_stack.Pop(), _stack.Pop()));
            }
        }
    }
}