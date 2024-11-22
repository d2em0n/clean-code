using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown
{
    public class Token
    {
        public readonly int Position;
      
        public readonly string Value;

        public readonly TokenProperty Property;

        public Token(int position, string value)
        {
            Position = position;
            Value = value;
        }
    }
}
