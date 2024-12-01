using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown
{
    public class DOM(IEnumerable<Token> tokens)
    {
        public readonly List<Token> Tokens = tokens.ToList();
    }
}
