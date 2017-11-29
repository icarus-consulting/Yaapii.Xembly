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

using System.Collections.Generic;
using System.Xml;
using Yaapii.Atoms.Text;
using Yaapii.Xml.Xambly.Arg;
using Yaapii.Xml.Xambly.Cursor;

namespace Yaapii.Xml.Xambly
{
    /// <summary>
    /// ADDIF directive.
    /// Adds new node, if it's absent.
    /// </summary>
    public class AddIfDirective : IDirective
    {
        private readonly IArg _name;

        /// <summary>
        /// ADDIF directive.
        /// Adds new node, if it's absent.
        /// </summary>
        /// <param name="node">Name of node to add</param>
        /// <exception cref="XmlContentException">If invalid input</exception>
        public AddIfDirective(string node)
        {
            _name = new ArgOf(node);
        }

        /// <summary>
        /// String representation.
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString()
        {
            return new FormattedText("ADDIF {0}", _name.Raw()).AsString();
        }

        /// <summary>
        /// Execute it in the given document with current position at the given node.
        /// </summary>
        /// <param name="dom">Document</param>
        /// <param name="cursor">Nodes we're currently at</param>
        /// <param name="stack">Execution stack</param>
        /// <returns>New current nodes</returns>
        public ICursor Exec(XmlNode dom, ICursor cursor, IStack stack)
        {
            var targets = new List<XmlNode>();
            var label = _name.Raw().ToLower();
            foreach (var node in cursor)
            {
                var kids = node.ChildNodes;
                XmlNode target = null;
                var len = kids.Count;
                for (int i = 0; i < len; i++)
                {
                    if(kids[i].Name.ToLower() == label)
                    {
                        target = kids[i];
                        break;
                    }
                }

                if(target == null){
                    XmlDocument doc = null;
                    if(dom.OwnerDocument == null)
                    {
                        doc = (XmlDocument)dom;
                    } else
                    {
                        doc = dom.OwnerDocument;
                    }

                    target = doc.CreateElement(this._name.Raw());
                    node.AppendChild(target);
                }

                targets.Add(target);
            }

            return new DomCursor(targets);
        }
    }
}