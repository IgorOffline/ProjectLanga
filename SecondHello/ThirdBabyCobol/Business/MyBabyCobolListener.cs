using System.Numerics;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using ThirdBabyCobol.BusinessGenerated;

namespace ThirdBabyCobol.Business;

public class MyBabyCobolListener : IBabyCobolListener
{
    public BigInteger CommandOrder { get; set; } = BigInteger.Zero;
    public string ProgramId { get; private set; } = string.Empty;
    public string LastVariable { get; set; } = string.Empty;
    public Dictionary<string, BigInteger> Values { get; } = new();
    public BacoOperation Operation { get; set; } = BacoOperation.None;
    
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
        
        Console.WriteLine($"EnterBacoheader={context.GetText()}");
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
        
        Console.WriteLine($"EnterBacoprogramid={context.GetText()}");

        ProgramId = context.children[2].GetText();
    }

    public void ExitBacoprogramid(BabyCobolParser.BacoprogramidContext context)
    {
        //
    }

    public void EnterBacovar(BabyCobolParser.BacovarContext context)
    {
        LastVariable = context.GetText();
        if (!Values.ContainsKey(LastVariable))
        {
            Values.Add(LastVariable, BigInteger.Zero);
        }
        
        Console.WriteLine($"EnterBacovar={context.GetText()}");
    }

    public void ExitBacovar(BabyCobolParser.BacovarContext context)
    {
        //
    }

    public void EnterBacoint(BabyCobolParser.BacointContext context)
    {
        Console.WriteLine($"EnterBacoint={context.GetText()}");

        switch (Operation)
        {
            case BacoOperation.None:
                break;
            case BacoOperation.Add:
                if (!LastVariable.Equals(string.Empty))
                {
                    Values.TryGetValue(LastVariable, out var bigval);
                    bigval += int.Parse(context.GetText());
                    Values[LastVariable] = bigval;
                }
                break;
            case BacoOperation.Subtract:
                if (!LastVariable.Equals(string.Empty))
                {
                    Values.TryGetValue(LastVariable, out var bigval);
                    bigval -= int.Parse(context.GetText());
                    Values[LastVariable] = bigval;
                }
                break;
            default:
                throw new NotSupportedException($"Operation ${Operation} is not supported");
        }
    }

    public void ExitBacoint(BabyCobolParser.BacointContext context)
    {
        //
    }

    public void EnterBacosepint(BabyCobolParser.BacosepintContext context)
    {
        Console.WriteLine($"EnterBacosepint={context.GetText()}");
    }

    public void ExitBacosepint(BabyCobolParser.BacosepintContext context)
    {
        //
    }

    public void EnterBacoaddition(BabyCobolParser.BacoadditionContext context)
    {
        if (CommandOrder < 1)
        {
            throw new InvalidOperationException("This command order is currently not supported");
        }
        
        ++CommandOrder;

        Operation = BacoOperation.Add;
        
        Console.WriteLine($"EnterBacoaddition={context.GetText()}");
    }

    public void ExitBacoaddition(BabyCobolParser.BacoadditionContext context)
    {
        Operation = BacoOperation.None;
    }

    public void EnterBacosubtraction(BabyCobolParser.BacosubtractionContext context)
    {
        if (CommandOrder < 1)
        {
            throw new InvalidOperationException("This command order is currently not supported");
        }
        
        ++CommandOrder;

        Operation = BacoOperation.Subtract;
        
        Console.WriteLine($"EnterBacosubtraction={context.GetText()}");
    }

    public void ExitBacosubtraction(BabyCobolParser.BacosubtractionContext context)
    {
        Operation = BacoOperation.None;
    }

    public void EnterBacofin(BabyCobolParser.BacofinContext context)
    {
        Console.WriteLine($"EnterBacofin={context.GetText()}");
    }

    public void ExitBacofin(BabyCobolParser.BacofinContext context)
    {
        //
    }

    public void EnterBacomain(BabyCobolParser.BacomainContext context)
    {
        Console.WriteLine($"EnterBacomain={context.GetText()}");
    }

    public void ExitBacomain(BabyCobolParser.BacomainContext context)
    {
        //
    }
}