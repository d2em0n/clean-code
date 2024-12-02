using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown.HTMLConverter
{
    public class Converter : IConverter
    {
        private static string PrintToken(Token token)
        {
            var result = new StringBuilder();
            var stack = new Stack<Token>();
            var closings = new Stack<string>();
            stack.Push(token);
            result.Append(Tags.Open[token.Property]);
            closings.Push(Tags.Close[token.Property]);
            while (stack.Count != 0)
            {
                var current = stack.Pop();
                foreach (var next in current.Children)
                {
                    result.Append(Tags.Open[next.Property]);
                    if (next.Property is TokenProperty.Normal or TokenProperty.Italic)
                    {
                        result.Append(next.Value);
                        result.Append(Tags.Close[next.Property]);
                    }
                    else closings.Push(Tags.Close[next.Property]);
                    stack.Push(next);
                }
            }
            while (closings.Count != 0)
                result.Append(closings.Pop());
            return result.ToString();
        }

        public string Convert(DOM dom)
        {
            var result = new StringBuilder();
            foreach (var token in dom.Tokens)
                result.Append(PrintToken(token));
            return result.ToString();
        }
    }
}
