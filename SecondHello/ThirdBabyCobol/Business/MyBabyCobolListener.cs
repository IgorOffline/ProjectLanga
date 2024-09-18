using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using ThirdBabyCobol.BusinessGenerated;

namespace ThirdBabyCobol.Business;

public class MyBabyCobolListener : IBabyCobolListener
{
    public int CommandOrder { get; set; }
    public string ProgramId { get; set; }
    
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

    public void EnterBacoheader(BabyCobolParser.BacoheaderContext context)
    {
        if (CommandOrder != 0)
        {
            throw new InvalidOperationException("This command order is currently not supported");
        }
        
        ++CommandOrder;
        
        Console.WriteLine($"EnterHeader={context.GetText()}");
    }

    public void ExitBacoheader(BabyCobolParser.BacoheaderContext context)
    {
        //
    }

    public void EnterBacoprogramid(BabyCobolParser.BacoprogramidContext context)
    {
        if (CommandOrder != 1)
        {
            throw new InvalidOperationException("This command order is currently not supported");
        }
        
        ++CommandOrder;
        
        Console.WriteLine($"EnterProgramname={context.GetText()}");

        ProgramId = context.children[2].GetText();
    }

    public void ExitBacoprogramid(BabyCobolParser.BacoprogramidContext context)
    {
        //
    }

    public void EnterBacomain(BabyCobolParser.BacomainContext context)
    {
        Console.WriteLine($"EnterMain={context.GetText()}");
    }

    public void ExitBacomain(BabyCobolParser.BacomainContext context)
    {
        //
    }
}