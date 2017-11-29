﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.XPath;
using Xunit;
using Yaapii.Atoms.IO;
using Yaapii.Atoms.List;
using Yaapii.Xml.Xambly.Cursor;
using Yaapii.Xml.Xambly.Stack;

namespace Yaapii.Xml.Xambly.Directive.Tests
{
    public class DirectivesTest
    {
        /// <summary>
        /// Directives can make a document
        /// </summary>
        [Fact]
        public void MakesXmlDocument()
        {
            string xml =
                new Xambler(
                    new Directives()
                        //.pi("xml-stylesheet", "none")
                        .Add("page")
                        .Attr("the-name", "with \u20ac")
                        .Add("child-node").Set(" the text\n").Up()
                        .Add("big-text").Cdata("<<hello!!!>>").Up()
                ).Xml();

            Assert.NotNull(FromXPath(xml, "/page[@the-name]"));
            Assert.NotNull(FromXPath(xml, "/page/big-text[normalize-space(.)='<<hello!!!>>']"));
        }

        /// <summary>
        /// Directives can parse Xambly grammar
        /// </summary>
        [Fact]
        public void ParsesIncomingGrammar()
        {
            IEnumerable<IDirective> dirs =
               new Directives(
                   "ADD 'yummy directive';"
           );

            Assert.True(
                new Yaapii.Atoms.Enumerable.LengthOf(dirs).Value() == 1);
        }

        /// <summary>
        /// Directives throw on incorrect grammar
        /// </summary>
        [Fact]
        public void ThrowsOnBrokenGrammar()
        {
            Assert.Throws<SyntaxException>(() =>
                new Directives("not a xambly at all"));
        }

        /// <summary>
        /// Directives throw on incorrect xmlcontent
        /// </summary>
        [Fact]
        public void ThrowsOnBrokenXmlContent()
        {
            Assert.Throws<SyntaxException>(() =>
                new Directives("ADD '\u001b';"));
        }


        /// <summary>
        /// Directives throw on incorrectly escaped xmlcontent
        /// </summary>
        [Fact]
        public void ThrowsOnBrokenEscapedXmlContent()
        {
            Assert.Throws<SyntaxException>(() =>
                new Directives("ADD '&#27;';"));

        }

        /// <summary>
        /// Directives can add map of values.
        /// </summary>
        [Fact]
        public void AddsMapOfValues()
        {
            var dom = new XmlDocument();
            dom.AppendChild(dom.CreateElement("root"));
            var xml =
                new Xambler(
                    new Directives()
                    .Xpath("//root")
                    .Add(
                        new Dictionary<String, Object>() {
                            { "first", 1 },{ "second", "two" }
                        })
                    .Add("third")
                ).Apply(dom).InnerXml;

            Assert.True(FromXPath(xml, "/root/first[.=1]") != null);
            Assert.True(FromXPath(xml, "/root/second[.='two']") != null);
            Assert.True(FromXPath(xml, "/root/second[.='two']") != null);
        }

        /// <summary>
        /// Directives can ignore empty input.
        /// </summary>
        [Fact]
        public void IgnoresEmptyInput()
        {
            Assert.Empty(
                new Directives("\n\t   \r"));
        }

        /// <summary>
        /// Directives can build a correct modification programme.
        /// </summary>
        [Fact]
        public void PerformsFullScaleModifications()
        {
            Assert.True(
                new Xambler(
                    new Directives(
                        new Directives()
                            .Add("html").Attr("xmlns", "http://www.w3.org/1999/xhtml")
                            .Add("body")
                            .Add("p")
                            .Set("\u20ac \\")
                            .ToString()
                    )
                ).Apply(
                    new XmlDocument()
                ).InnerXml == "<html xmlns=\"http://www.w3.org/1999/xhtml\"><body><p>€ \\</p></body></html>");
        }

        //NOT FOR NOW - CopyTo missing atm
        /// <summary>
        /// Directives can copy an existing node
        /// </summary>
        [Fact]
        public void CopiesExistingNode()
        {
            //final Document dom = DocumentBuilderFactory.newInstance()
            //.newDocumentBuilder().newDocument();
            //new Xambler(
            //    new Directives().add("dudes").append(
            //        Directives.copyOf(
            //            new XMLDocument(
            //                StringUtils.join(
            //                    "<jeff name='Jeffrey'><first/><second/>",
            //                    "<?some-pi test?>",
            //                    "<file a='x'><f><name>\u20ac</name></f></file>",
            //                    "<!-- some comment -->",
            //                    "<x><![CDATA[hey you]]></x>  </jeff>"
            //                )
            //            ).node()
            //        )
            //    )
            //).apply(dom);
            //MatcherAssert.assertThat(
            //    XhtmlMatchers.xhtml(dom),
            //    XhtmlMatchers.hasXPaths(
            //        "/dudes/jeff[@name = 'Jeffrey']",
            //        "/dudes/jeff[first and second]",
            //        "/dudes/jeff/file[@a='x']/f[name='\u20ac']"
            //    )
            //);
        }

        /// <summary>
        /// Directives can understand case.
        /// </summary>
        [Fact]
        public void AddsElementsCaseSensitively()
        {
            var xml = new Xambler(new Directives().Add("XHtml").AddIf("Body")).Xml();
            Assert.True(
                 xml == "<?xml version=\"1.0\" encoding=\"utf-16\"?><XHtml><Body /></XHtml>"
                );
        }

        /// <summary>
        /// Directives can convert to string.
        /// </summary>
        [Fact]
        public void ConvertsToString()
        {
            Directives dirs = new Directives();
            for (int idx = 0; idx < 10; ++idx)
            {
                dirs.Add("HELLO");
            }

            var xml = dirs.ToString();

            Assert.True(
                new Regex("ADD \"HELLO\";").Matches(xml).Count == 10);
        }

        /// <summary>
        /// Directives can push and pop
        /// </summary>
        [Fact]
        public void PushesAndPopsCursor()
        {
            var xml = new Xambler(
                             new Directives()
                                 .Add("jeff")
                                 .Push().Add("lebowski")
                                 .Push().Xpath("/jeff").Add("dude").Pop()
                                 .Attr("birthday", "today").Pop()
                                 .Add("los-angeles")
                       ).Xml();

            Assert.True(
                null != FromXPath(
                    xml, "/jeff/lebowski[@birthday]") &&
                null != FromXPath(
                    xml, "/jeff/los-angeles") &&
                null != FromXPath(
                    xml, "/jeff/dude"));
        }

        /// <summary>
        /// Directives can use namespaces.
        /// </summary>
        [Fact]
        public void PrefixesItemsWithNamespaces()
        {
            var xml =
                new Xambler(
                    new Directives()
                        .Add("bbb")
                        .Attr("xmlns:x", "http://www.w3.org/1999/xhtml")
                        .Add("x:node").Set("HELLO WORLD!")
                ).Xml();

            Assert.NotNull(FromXPath(xml, "//x:node"));
        }

        /// <summary>
        /// Directives can accept directives from multiple threads.
        /// </summary>
        [Fact(Skip = "True")]
        public void AcceptsFromMultipleThreads()
        {
            //final Directives dirs = new Directives().add("mt6");
            //new Callable<Void>() {
            //@Parallel(threads = Tv.FIFTY)
            //@Override
            //public Void call() throws Exception
            //{
            //    dirs.append(
            //            new Directives()
            //                .add("fo9").attr("yu", "").set("some text 90")
            //                .add("tr4").attr("s2w3", "").set("some other text 76")
            //                .up().up()
            //        );
            //        return null;
            //    }
            //} .call();
            //MatcherAssert.assertThat(
            //    XhtmlMatchers.xhtml(new Xambler(dirs).xml()),
            //            XhtmlMatchers.hasXPath("/mt6[count(fo9[@yu])=50]")
            //        );
        }

        /// <summary>
        /// Directives can parse Xambly script
        /// </summary>
        [Fact]
        public void ParsesGrammar()
        {
            IEnumerable<IDirective> dirs =
                new Directives(
                    "ADD 'root'; ADD 'something'; SET 'Teststring';" +
                    "XPATH '/root/something[contains(.,\"Teststring\")]'; UP; " +
                    "ADD 'yummydirective';");

            new Xambler(dirs).Apply(new XmlDocument());

            Assert.True(
                new Yaapii.Atoms.Enumerable.LengthOf(dirs).Value() == 6);
        }


        /// <summary>
        /// A navigator from an Xml and XPath
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="xpath"></param>
        /// <returns></returns>
        private XPathNavigator FromXPath(string xml, string xpath)
        {
            var nav =
                new XPathDocument(
                    new StringReader(xml)
                ).CreateNavigator();

            var nsm = NamespacesOfDom(xml);
            return nav.SelectSingleNode(xpath, nsm);
        }

        private XmlNamespaceManager NamespacesOfDom(string xml)
        {
            var xDoc = new XmlDocument();
            xDoc.LoadXml(xml);
            return NamespacesOfDom(xDoc);
        }
        private XmlNamespaceManager NamespacesOfDom(XmlDocument xDoc)
        {
            XmlNamespaceManager result = new XmlNamespaceManager(xDoc.NameTable);

            IDictionary<string, string> localNamespaces = null;
            XPathNavigator xNav = xDoc.CreateNavigator();
            while (xNav.MoveToFollowing(XPathNodeType.Element))
            {
                localNamespaces = xNav.GetNamespacesInScope(XmlNamespaceScope.Local);
                foreach (var localNamespace in localNamespaces)
                {
                    string prefix = localNamespace.Key;
                    if (string.IsNullOrEmpty(prefix))
                        prefix = "";

                    result.AddNamespace(prefix, localNamespace.Value);
                }
            }

            return result;
        }
    }
}