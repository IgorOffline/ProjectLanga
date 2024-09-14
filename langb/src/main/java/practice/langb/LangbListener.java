package practice.langb;

import org.antlr.v4.runtime.ParserRuleContext;
import org.antlr.v4.runtime.tree.ErrorNode;
import org.antlr.v4.runtime.tree.TerminalNode;
import practice.langb.antlr4.HelloListener;
import practice.langb.antlr4.HelloParser;

public class LangbListener implements HelloListener {
    @Override
    public void enterR(HelloParser.RContext ctx) {
        System.out.println("enterR::" + ctx.getText());
    }

    @Override
    public void exitR(HelloParser.RContext ctx) {
        System.out.println("exitR::" + ctx.getText());
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
