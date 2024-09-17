// See https://aka.ms/new-console-template for more information

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using SecondHello.BusinessSecondHello;

Console.WriteLine("Hello, World! " + Class1.HelloClass1);

var lexer = new HelloLexer(new AntlrFileStream("input.txt"));
var tokens = new CommonTokenStream(lexer);
var parser = new HelloParser(tokens);
var tree = parser.r();
var walker = new ParseTreeWalker();
walker.Walk(new MyHelloListener(), tree);

Console.WriteLine("Hello, World! " + Class1.HelloClass1);