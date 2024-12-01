using Markdown.MDParser;

namespace Markdown
{
    internal class Program
    {
        public static void FindChildren(Token token)
        {
            if (!Complex.Properties.Contains(token.Property))
                return;

            var i = 0;
            var text = token.Value;
            var len = token.Value.Length;
            while (i < len)
            {
                var start = text[i];
                switch (start)
                {
                    case '_':
                        {
                            var italic = new Italic();
                            var child = italic.TryFindToken(text, i);
                            token.Children.Add(child);

                            i += child.Property switch
                            {
                                TokenProperty.Italic => child.Value.Length + 2,
                                TokenProperty.Bold => child.Value.Length + 4,
                                _ => child.Value.Length,
                            };
                            break;
                        }

                    case '\\':
                        {
                            var hidden = new Hidden();
                            var child = hidden.TryFindToken(text, i);
                            i += child.Value.Length + 1;
                            if (child.Value == string.Empty)
                                child.Value = "\\";
                            token.Children.Add(child);
                            break;
                        }

                    default:
                        {
                            var norm = new Normal();
                            var child = norm.TryFindToken(text, i);
                            token.Children.Add(child);
                            i += child.Value.Length;
                            break;
                        }
                }
            }
        }

        static void Main()
        {
            var text = "# Спецификация _языка_ _ раз_метки\nfs__df dfh__\n#sef";

            var parser = new Parser();
            var dom = parser.BuildDom(text);

            //var tokens = text.Split("\n", StringSplitOptions.None)
            //    .Select(line => new Token(line, TokenProperty.Paragraph))
            //    .Select(t => t = t.Value.StartsWith('#') ? new Token(t.Value[1..], TokenProperty.Head) : t)
            //    ;

            //foreach (var token in tokens)
            //{
            //    var queue = new Queue<Token>();
            //    queue.Enqueue(token);
            //    while (queue.Count > 0)
            //    {
            //        var current = queue.Dequeue();
            //        FindChildren(current);
            //        foreach (var child in current.Children)
            //            queue.Enqueue(child);
            //    }

            //Console.WriteLine(token);
            //Console.WriteLine("---------------------------");
            //FindChildren(token);
            //foreach (var c in token.Children)
            //    Console.WriteLine(c);
            //Console.WriteLine("=========");
            //Console.WriteLine();
            //}
        }
    }
}
