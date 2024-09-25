using System.Numerics;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using CsUlica.BusinessGenerated;

namespace CsUlica.Business;

public class UlicaListenerImpl : IUlicaListener
{
    public UlicaVariable LastVariable { get; set; } = UlicaUtil.UlicaVariableDefault();
    public UlicaOperation LastOperation { get; set; } = UlicaOperation.None;
    public Dictionary<string, UlicaVariable> Values { get; set; } = new();
    public const string ProgramIdVal = "__program_id__";
    
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

    public void EnterUlicaprogramid(UlicaParser.UlicaprogramidContext context)
    {
        Values[ProgramIdVal] = new UlicaVariable(UlicaType.String, ProgramIdVal, context.children[1].GetText());
    }

    public void ExitUlicaprogramid(UlicaParser.UlicaprogramidContext context)
    {
        //
    }

    public void EnterUlicavar(UlicaParser.UlicavarContext context)
    {
        //
    }

    public void ExitUlicavar(UlicaParser.UlicavarContext context)
    {
        //
    }

    public void EnterUlicaint(UlicaParser.UlicaintContext context)
    {
        //
    }

    public void ExitUlicaint(UlicaParser.UlicaintContext context)
    {
        //
    }

    public void EnterUlicadeclaredefault(UlicaParser.UlicadeclaredefaultContext context)
    {
        var bigintKey = context.children[1].GetText()!;
        
        Values[bigintKey] = new UlicaVariable(UlicaType.Bigint, bigintKey, BigInteger.Zero);
    }

    public void ExitUlicadeclaredefault(UlicaParser.UlicadeclaredefaultContext context)
    {
        //
    }

    public void EnterUlicadeclare(UlicaParser.UlicadeclareContext context)
    {
        var bigintKey = context.children[1].GetText()!;
        var bigintValue = BigInteger.Parse(context.children[3].GetText()!);
        
        Values[bigintKey] = new UlicaVariable(UlicaType.Bigint, bigintKey, bigintValue);
    }

    public void ExitUlicadeclare(UlicaParser.UlicadeclareContext context)
    {
        //
    }

    public void EnterUlicaprint(UlicaParser.UlicaprintContext context)
    {
        var printKey = context.children[1].GetText()!;
        var printValue = Values[printKey];
        
        switch (printValue.Type)
        {
            case UlicaType.String:
                Console.WriteLine((string) printValue.Value!);
                break;
            case UlicaType.Bigint:
                Console.WriteLine((BigInteger) printValue.Value!);
                break;
            case UlicaType.Object:
            default:
                throw new ArgumentException($"Unsupported type= {printValue.Type.ToString()}");
        }
    }

    public void ExitUlicaprint(UlicaParser.UlicaprintContext context)
    {
        //
    }

    public void EnterUlicasepint(UlicaParser.UlicasepintContext context)
    {
        if (LastVariable.Type != UlicaType.Bigint)
        {
            throw new ArgumentException("Last variable ulica type must be bigint");
        }

        if (LastOperation != UlicaOperation.Add)
        {
            throw new ArgumentException("Last operation must be add");
        }

        var name = LastVariable.Name;
        
        for (int i = 1; i < context.children.Count; i += 2)
        {
            var addBy = (BigInteger) Values[name].Value!;
            var parse = BigInteger.Parse(context.children[i].GetText());
            addBy += parse;
            Values[name] = new UlicaVariable(UlicaType.Bigint, name, addBy);
        }
    }

    public void ExitUlicasepint(UlicaParser.UlicasepintContext context)
    {
        //
    }

    public void EnterUlicaaddition(UlicaParser.UlicaadditionContext context)
    {
        var additionKey = context.children[0].GetText()!;
        
        LastVariable = new UlicaVariable(UlicaType.Bigint, additionKey, null);
        LastOperation = UlicaOperation.Add;
    }

    public void ExitUlicaaddition(UlicaParser.UlicaadditionContext context)
    {
        //
    }

    public void EnterUlicasubtraction(UlicaParser.UlicasubtractionContext context)
    {
        //
    }

    public void ExitUlicasubtraction(UlicaParser.UlicasubtractionContext context)
    {
        //
    }

    public void EnterUlicamain(UlicaParser.UlicamainContext context)
    {
        //
    }

    public void ExitUlicamain(UlicaParser.UlicamainContext context)
    {
        //
    }
}