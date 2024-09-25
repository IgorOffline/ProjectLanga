// See https://aka.ms/new-console-template for more information

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using CsUlica.Business;
using CsUlica.BusinessGenerated;

Console.WriteLine("<START>");

var listener = new UlicaListenerImpl();

var lexer = new UlicaLexer(new AntlrFileStream("input.txt"));
var tokens = new CommonTokenStream(lexer);
var parser = new UlicaParser(tokens);
var tree = parser.ulicamain();
var walker = new ParseTreeWalker();
walker.Walk(listener, tree);

Console.WriteLine("<END>");
