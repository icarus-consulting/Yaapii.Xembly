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
using Yaapii.Atoms.Error;
using Yaapii.Xml.Xembly.Error;

namespace Yaapii.Xml.Xembly
{
    public sealed  class RemoveDirective : IDirective
    {
        void HandleFunc()
        {

        }

        public RemoveDirective()
        {
        }

        public new string ToString() {

            return "REMOVE";
        }

        public ICursor Exec(XmlNode dom, ICursor cursor, IStack stack)
        {
            var parents = new HashSet<XmlNode>();
            foreach (var node in cursor)
            {
                XmlNode parent;
                if(node.NodeType == XmlNodeType.Attribute) {
                    var attr = node as XmlAttribute;
                    parent = attr.ParentNode;
                    parent.Attributes.Remove(attr);
                } else {
                    parent = node.ParentNode;
                    new FailPrecise(
                        new FailNull(
                            parent
                        ),
                        new IllegalArgumentException("you can't delete root document element from XML")
                    ).Go();

                    new FailPrecise(
                        new FailWhen(
                            parent.NodeType == XmlNodeType.Document
                        ),
                        new IllegalArgumentException("you can't delete root document element from XML")
                    ).Go();

                    parent.RemoveChild(node);
                }

                parents.Add(parent);
            }

            return cursor;
        }
    }
}