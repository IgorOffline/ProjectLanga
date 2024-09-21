// See https://aka.ms/new-console-template for more information

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using ThirdBabyCobol.Business;
using ThirdBabyCobol.BusinessGenerated;

Console.WriteLine("<START>");

var listener = new MyBabyCobolListener();

var lexer = new BabyCobolLexer(new AntlrFileStream("input.txt"));
var tokens = new CommonTokenStream(lexer);
var parser = new BabyCobolParser(tokens);
var tree = parser.bacomain();
var walker = new ParseTreeWalker();
walker.Walk(listener, tree);

Console.WriteLine("--- --- ---");
Console.WriteLine($"Program id= {listener.ProgramId}");
Console.WriteLine("Variables:");
foreach (var kv in listener.Values.AsEnumerable())
{
    Console.WriteLine($"{kv.Key} {kv.Value}");
}

Console.WriteLine("<END>");
