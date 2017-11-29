//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\mtu.ICARUS-CONSULT\Documents\Projekte\Yaapii.Xambly\src\Yaapii.Xml.Xambly\\Antlr4\Xambly.g by ANTLR 4.6

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419


using System.Xml;
using Yaapii.Atoms;
using Yaapii.Atoms.Text;
using Yaapii.Xml.Xambly;
using Yaapii.Xml.Xambly.Arg;
using Yaapii.Xml.Xambly.Error;
using Yaapii.Xml.Xambly.Directive;

using System;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6")]
[System.CLSCompliant(false)]
public partial class XamblyLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, DIGIT=14, COMMA=15, COLON=16, SEMICOLON=17, 
		TEXT=18, SPACE=19;
	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "T__10", "T__11", "T__12", "DIGIT", "COMMA", "COLON", "SEMICOLON", 
		"TEXT", "SPACE"
	};


	    public void emitErrorMessage(String msg) {
	        throw new ParsingException(msg);
	    }


	public XamblyLexer(ICharStream input)
		: base(input)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'XPATH'", "'SET'", "'XSET'", "'ATTR'", "'ADD'", "'ADDIF'", "'REMOVE'", 
		"'STRICT'", "'UP'", "'PI'", "'PUSH'", "'POP'", "'CDATA'", null, "','", 
		"':'", "';'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, "DIGIT", "COMMA", "COLON", "SEMICOLON", "TEXT", "SPACE"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Xambly.g"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	static XamblyLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	public override void Action(RuleContext _localctx, int ruleIndex, int actionIndex) {
		switch (ruleIndex) {
		case 17 : TEXT_action(_localctx, actionIndex); break;
		case 18 : SPACE_action(_localctx, actionIndex); break;
		}
	}
	private void TEXT_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 0: 
		        try {
		            this.Text = new Unescaped(this.Text).AsString();
		        } catch (XmlException ex) {
		            throw new ParsingException(ex);
		        }
		     break;
		case 1: 
		        try {
		            this.Text = new Unescaped(this.Text).AsString();
		        } catch (XmlException ex) {
		            throw new ParsingException(ex);
		        }
		     break;
		}
	}
	private void SPACE_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 2:  this.Skip();  break;
		}
	}

	private static string _serializedATN = _serializeATN();
	private static string _serializeATN()
	{
	    StringBuilder sb = new StringBuilder();
	    sb.Append("\x3\x430\xD6D1\x8206\xAD2D\x4417\xAEF1\x8D80\xAADD\x2\x15");
		sb.Append("\x8D\b\x1\x4\x2\t\x2\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6");
		sb.Append("\t\x6\x4\a\t\a\x4\b\t\b\x4\t\t\t\x4\n\t\n\x4\v\t\v\x4\f\t\f");
		sb.Append("\x4\r\t\r\x4\xE\t\xE\x4\xF\t\xF\x4\x10\t\x10\x4\x11\t\x11\x4");
		sb.Append("\x12\t\x12\x4\x13\t\x13\x4\x14\t\x14\x3\x2\x3\x2\x3\x2\x3\x2");
		sb.Append("\x3\x2\x3\x2\x3\x3\x3\x3\x3\x3\x3\x3\x3\x4\x3\x4\x3\x4\x3\x4");
		sb.Append("\x3\x4\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x6\x3\x6\x3\x6\x3\x6");
		sb.Append("\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b");
		sb.Append("\x3\b\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\n\x3\n\x3\n\x3\v");
		sb.Append("\x3\v\x3\v\x3\f\x3\f\x3\f\x3\f\x3\f\x3\r\x3\r\x3\r\x3\r\x3\xE");
		sb.Append("\x3\xE\x3\xE\x3\xE\x3\xE\x3\xE\x3\xF\x3\xF\x3\x10\x3\x10\x3");
		sb.Append("\x11\x3\x11\x3\x12\x3\x12\x3\x13\x3\x13\a\x13u\n\x13\f\x13\xE");
		sb.Append("\x13x\v\x13\x3\x13\x3\x13\x3\x13\x3\x13\a\x13~\n\x13\f\x13\xE");
		sb.Append("\x13\x81\v\x13\x3\x13\x3\x13\x5\x13\x85\n\x13\x3\x14\x6\x14");
		sb.Append("\x88\n\x14\r\x14\xE\x14\x89\x3\x14\x3\x14\x2\x2\x15\x3\x3\x5");
		sb.Append("\x4\a\x5\t\x6\v\a\r\b\xF\t\x11\n\x13\v\x15\f\x17\r\x19\xE\x1B");
		sb.Append("\xF\x1D\x10\x1F\x11!\x12#\x13%\x14\'\x15\x3\x2\x5\x3\x2$$\x3");
		sb.Append("\x2))\x5\x2\v\f\xF\xF\"\"\x90\x2\x3\x3\x2\x2\x2\x2\x5\x3\x2");
		sb.Append("\x2\x2\x2\a\x3\x2\x2\x2\x2\t\x3\x2\x2\x2\x2\v\x3\x2\x2\x2\x2");
		sb.Append("\r\x3\x2\x2\x2\x2\xF\x3\x2\x2\x2\x2\x11\x3\x2\x2\x2\x2\x13\x3");
		sb.Append("\x2\x2\x2\x2\x15\x3\x2\x2\x2\x2\x17\x3\x2\x2\x2\x2\x19\x3\x2");
		sb.Append("\x2\x2\x2\x1B\x3\x2\x2\x2\x2\x1D\x3\x2\x2\x2\x2\x1F\x3\x2\x2");
		sb.Append("\x2\x2!\x3\x2\x2\x2\x2#\x3\x2\x2\x2\x2%\x3\x2\x2\x2\x2\'\x3");
		sb.Append("\x2\x2\x2\x3)\x3\x2\x2\x2\x5/\x3\x2\x2\x2\a\x33\x3\x2\x2\x2");
		sb.Append("\t\x38\x3\x2\x2\x2\v=\x3\x2\x2\x2\r\x41\x3\x2\x2\x2\xFG\x3\x2");
		sb.Append("\x2\x2\x11N\x3\x2\x2\x2\x13U\x3\x2\x2\x2\x15X\x3\x2\x2\x2\x17");
		sb.Append("[\x3\x2\x2\x2\x19`\x3\x2\x2\x2\x1B\x64\x3\x2\x2\x2\x1Dj\x3\x2");
		sb.Append("\x2\x2\x1Fl\x3\x2\x2\x2!n\x3\x2\x2\x2#p\x3\x2\x2\x2%\x84\x3");
		sb.Append("\x2\x2\x2\'\x87\x3\x2\x2\x2)*\aZ\x2\x2*+\aR\x2\x2+,\a\x43\x2");
		sb.Append("\x2,-\aV\x2\x2-.\aJ\x2\x2.\x4\x3\x2\x2\x2/\x30\aU\x2\x2\x30");
		sb.Append("\x31\aG\x2\x2\x31\x32\aV\x2\x2\x32\x6\x3\x2\x2\x2\x33\x34\a");
		sb.Append("Z\x2\x2\x34\x35\aU\x2\x2\x35\x36\aG\x2\x2\x36\x37\aV\x2\x2\x37");
		sb.Append("\b\x3\x2\x2\x2\x38\x39\a\x43\x2\x2\x39:\aV\x2\x2:;\aV\x2\x2");
		sb.Append(";<\aT\x2\x2<\n\x3\x2\x2\x2=>\a\x43\x2\x2>?\a\x46\x2\x2?@\a\x46");
		sb.Append("\x2\x2@\f\x3\x2\x2\x2\x41\x42\a\x43\x2\x2\x42\x43\a\x46\x2\x2");
		sb.Append("\x43\x44\a\x46\x2\x2\x44\x45\aK\x2\x2\x45\x46\aH\x2\x2\x46\xE");
		sb.Append("\x3\x2\x2\x2GH\aT\x2\x2HI\aG\x2\x2IJ\aO\x2\x2JK\aQ\x2\x2KL\a");
		sb.Append("X\x2\x2LM\aG\x2\x2M\x10\x3\x2\x2\x2NO\aU\x2\x2OP\aV\x2\x2PQ");
		sb.Append("\aT\x2\x2QR\aK\x2\x2RS\a\x45\x2\x2ST\aV\x2\x2T\x12\x3\x2\x2");
		sb.Append("\x2UV\aW\x2\x2VW\aR\x2\x2W\x14\x3\x2\x2\x2XY\aR\x2\x2YZ\aK\x2");
		sb.Append("\x2Z\x16\x3\x2\x2\x2[\\\aR\x2\x2\\]\aW\x2\x2]^\aU\x2\x2^_\a");
		sb.Append("J\x2\x2_\x18\x3\x2\x2\x2`\x61\aR\x2\x2\x61\x62\aQ\x2\x2\x62");
		sb.Append("\x63\aR\x2\x2\x63\x1A\x3\x2\x2\x2\x64\x65\a\x45\x2\x2\x65\x66");
		sb.Append("\a\x46\x2\x2\x66g\a\x43\x2\x2gh\aV\x2\x2hi\a\x43\x2\x2i\x1C");
		sb.Append("\x3\x2\x2\x2jk\x4\x32;\x2k\x1E\x3\x2\x2\x2lm\a.\x2\x2m \x3\x2");
		sb.Append("\x2\x2no\a<\x2\x2o\"\x3\x2\x2\x2pq\a=\x2\x2q$\x3\x2\x2\x2rv");
		sb.Append("\a$\x2\x2su\n\x2\x2\x2ts\x3\x2\x2\x2ux\x3\x2\x2\x2vt\x3\x2\x2");
		sb.Append("\x2vw\x3\x2\x2\x2wy\x3\x2\x2\x2xv\x3\x2\x2\x2yz\a$\x2\x2z\x85");
		sb.Append("\b\x13\x2\x2{\x7F\a)\x2\x2|~\n\x3\x2\x2}|\x3\x2\x2\x2~\x81\x3");
		sb.Append("\x2\x2\x2\x7F}\x3\x2\x2\x2\x7F\x80\x3\x2\x2\x2\x80\x82\x3\x2");
		sb.Append("\x2\x2\x81\x7F\x3\x2\x2\x2\x82\x83\a)\x2\x2\x83\x85\b\x13\x3");
		sb.Append("\x2\x84r\x3\x2\x2\x2\x84{\x3\x2\x2\x2\x85&\x3\x2\x2\x2\x86\x88");
		sb.Append("\t\x4\x2\x2\x87\x86\x3\x2\x2\x2\x88\x89\x3\x2\x2\x2\x89\x87");
		sb.Append("\x3\x2\x2\x2\x89\x8A\x3\x2\x2\x2\x8A\x8B\x3\x2\x2\x2\x8B\x8C");
		sb.Append("\b\x14\x4\x2\x8C(\x3\x2\x2\x2\a\x2v\x7F\x84\x89\x5\x3\x13\x2");
		sb.Append("\x3\x13\x3\x3\x14\x4");
	    return sb.ToString();
	}

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());


}