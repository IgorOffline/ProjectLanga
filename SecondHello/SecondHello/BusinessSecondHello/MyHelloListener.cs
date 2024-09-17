using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace SecondHello.BusinessSecondHello;

public class MyHelloListener : IHelloListener
{
    public void EnterR(HelloParser.RContext context)
    {
        Console.WriteLine($"EnterR={context.GetText()}");
    }

    public void ExitR(HelloParser.RContext context)
    {
        Console.WriteLine($"ExitR={context.GetText()}");
    }
    
    public void VisitTerminal(ITerminalNode node)
    {
        //
    }

    public void VisitErrorNode(IErrorNode node)
    {
        //
    }

    public void EnterEveryRule(ParserRuleContext ctx)
    {
        //
    }

    public void ExitEveryRule(ParserRuleContext ctx)
    {
        //
    }
}