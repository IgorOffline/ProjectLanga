package practice.langd;

import org.antlr.v4.runtime.ParserRuleContext;
import org.antlr.v4.runtime.tree.ErrorNode;
import org.antlr.v4.runtime.tree.TerminalNode;
import practice.langd.antlr4.AddListener;
import practice.langd.antlr4.AddParser;

import java.util.Arrays;

public class LangdListener implements AddListener {
    @Override
    public void enterEquation(AddParser.EquationContext ctx) {
        System.out.println("enterEquation::" + ctx.getText());
        var split = ctx.getText().split("\\+");
        System.out.println(Arrays.toString(split));
        if (split.length == 2) {
            try {
                var int0 = Integer.parseInt(split[0]);
                var int1 = Integer.parseInt(split[1]);
                var sum = int0 + int1;
                System.out.println("sum=" + sum);
            } catch (NumberFormatException e) {
                System.out.println("NumberFormatException");
            }
        }
    }

    @Override
    public void exitEquation(AddParser.EquationContext ctx) {
        System.out.println("exitEquation::" + ctx.getText());
    }

    @Override
    public void visitTerminal(TerminalNode terminalNode) {
        System.out.println("visitTerminal");
    }

    @Override
    public void visitErrorNode(ErrorNode errorNode) {
        System.out.println("visitErrorNode");
    }

    @Override
    public void enterEveryRule(ParserRuleContext parserRuleContext) {
        System.out.println("enterEveryRule");
    }

    @Override
    public void exitEveryRule(ParserRuleContext parserRuleContext) {
        System.out.println("exitEveryRule");
    }
}