using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown.HTMLConverter
{
    class Tags
    {
        public static Dictionary<TokenProperty, string> Open = new() {
            { TokenProperty.Bold, "<strong>"},
            { TokenProperty.Head, "<h1>"},
            { TokenProperty.Italic, "<em>"},
            { TokenProperty.Paragraph, ""},
            { TokenProperty.Normal, ""}
        };

        public static Dictionary<TokenProperty, string> Close = new() {
            { TokenProperty.Bold, "</strong>"},
            { TokenProperty.Head, "</h1>\n"},
            { TokenProperty.Italic, "</em>"},
            { TokenProperty.Paragraph, "\n"},
            { TokenProperty.Normal, ""}
        };
    }
}

