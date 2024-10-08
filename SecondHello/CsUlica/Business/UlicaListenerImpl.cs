using System.Numerics;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using CsUlica.BusinessGenerated;

namespace CsUlica.Business;

public class UlicaListenerImpl : IUlicaListener
{
    public UlicaVariable LastVariable { get; set; } = UlicaUtil.UlicaVariableDefault();
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

    public void EnterUlicadeclare(UlicaParser.UlicadeclareContext context)
    {
        //
    }

    public void ExitUlicadeclare(UlicaParser.UlicadeclareContext context)
    {
        //
    }

    public void EnterUlicaprint(UlicaParser.UlicaprintContext context)
    {
        var programIdKey = context.children[1].GetText()!;
        var programIdValue = (string) Values[programIdKey].Value!;
        
        Console.WriteLine(programIdValue);
    }

    public void ExitUlicaprint(UlicaParser.UlicaprintContext context)
    {
        //
    }

    public void EnterUlicasepint(UlicaParser.UlicasepintContext context)
    {
        //
    }

    public void ExitUlicasepint(UlicaParser.UlicasepintContext context)
    {
        //
    }

    public void EnterUlicaaddition(UlicaParser.UlicaadditionContext context)
    {
        //
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