﻿// MIT License
//
// Copyright(c) 2017 ICARUS Consulting GmbH
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System.Xml;
using Xunit;
using Yaapii.Atoms.Enumerable;
using Yaapii.Xml.Xambly.Cursor;
using Yaapii.Xml.Xambly.Stack;

namespace Yaapii.Xml.Xambly.Directive.Tests
{
    public class RemoveDirectiveTest
    {
        [Fact]
        public void RemoveCurrentNode() {

            Assert.True(
                new Xambler(
                    new Yaapii.Atoms.Enumerable.EnumerableOf<IDirective>(
                        new AddDirective("root"),
                        new AddDirective("foobar"),
                        new RemoveDirective()
                    )
                ).Apply(
                    new XmlDocument()
                ).InnerXml == "<root></root>", "Remove node failed"
            );
        }

        [Fact]
        public void ThrowsExceptionOnRemoveRootNode() {
            Assert.Throws<ImpossibleModificationException>(() =>
                {
                    new Xambler(
                        new Yaapii.Atoms.Enumerable.EnumerableOf<IDirective>(
                            new AddDirective("root"),
                            new RemoveDirective()
                        )
                    ).Apply(
                        new XmlDocument()
                    );
                }
            );
        }

        [Fact]
        public void ThrowsExceptionOnRemoveDocumentNode()
        {
            Assert.Throws<ImpossibleModificationException>(() =>
                {
                    new Xambler(
                        new Yaapii.Atoms.Enumerable.EnumerableOf<IDirective>(
                            new RemoveDirective()
                        )
                    ).Apply(
                        new XmlDocument()
                    );
                }
            );
        }

        [Fact]
        public void RemoveDomNodesDirectly()
        {
            var dom = new XmlDocument();
            var root = dom.CreateElement("root");
            var first = dom.CreateElement("a");
            root.AppendChild(first);
            var second = dom.CreateElement("b");
            root.AppendChild(second);

            dom.AppendChild(root);

            new RemoveDirective().Exec(
                dom,
                new DomCursor(new Yaapii.Atoms.Enumerable.EnumerableOf<XmlNode>(first)),
                new DomStack()
            );

            Assert.True(
                dom.InnerXml == "<root><b /></root>", "Remove directive failed"
            );
        }

        [Fact]
        public void CursorPointsToParents()
        {
            var dom = new XmlDocument();
            var root = dom.CreateElement("root");
            var first = dom.CreateElement("a");
            var firstChild = dom.CreateElement("a_child");
            first.AppendChild(firstChild);
            root.AppendChild(first);
            var second = dom.CreateElement("b");
            var secondChild = dom.CreateElement("b_child");
            second.AppendChild(secondChild);
            root.AppendChild(second);

            dom.AppendChild(root);

            var cursor =
                new RemoveDirective().Exec(
                    dom,
                    new DomCursor(new EnumerableOf<XmlNode>(firstChild, secondChild)),
                    new DomStack()
                );
            Assert.Equal(
                new EnumerableOf<XmlNode>(first, second),
                cursor
            );
        }
    }
}