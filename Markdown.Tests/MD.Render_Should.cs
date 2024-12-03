using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using FluentAssertions;
using Markdown.MDParser;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Markdown.HTMLConverter;

namespace Markdown.Tests
{
    [TestFixture]
    public class Render_Should
    {
        private readonly Parser _parser = new();
        private readonly Converter _converter = new();

        [Test]
        public void Render_ShouldReturnItalic()
        {
            Md.Render(
                    "_italic_", _parser, _converter)
                .Should().Be("<em>italic</em>\n");
        }

        [Test]
        public void Render_ShouldReturnBold()
        {
            Md.Render(
                    "__bold__", _parser, _converter)
                .Should().Be("<strong>bold</strong>\n");
        }

        [Test]
        public void Render_ShouldSkipEscapedChars()
        {
            Md.Render(@"\_notItalic\_", _parser, _converter)
                .Should().NotBe("<em>notItalic</em>\n");
            Md.Render(@"\_notItalic\_", _parser, _converter)
            .Should().Be("_notItalic_\n");
        }

        [Test]
        public void Render_ShouldNotSkipSlashWithoutMarker()
        {
            Md.Render(@"a\a", _parser, _converter)
                .Should().Be("a\\a\n");
        }

        [Test]
        public void Render_SlashHaveToBeEscapedWithAnotherSlash()
        {
            Md.Render(@"\\", _parser, _converter)
                .Should().Be("\\\n");
        }

        [Test]
        public void Render_ItalicInBold()
        {
            Md.Render("Внутри __двойного выделения _одинарное_ тоже__ работает", _parser, _converter)
                .Should().Be("Внутри <strong>двойного выделения <em>одинарное</em> тоже</strong> работает\n");
        }

        [Test]
        public void Render_ConvertLink()
        {
            Md.Render("[name](address)", _parser, _converter)
                .Should().Be("<a href=address>name</a>\n");
        }
    }
}
