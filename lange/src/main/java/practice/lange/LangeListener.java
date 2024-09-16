package practice.lange;

import org.antlr.v4.runtime.ParserRuleContext;
import org.antlr.v4.runtime.tree.ErrorNode;
import org.antlr.v4.runtime.tree.TerminalNode;
import practice.lange.antlr4.ArrayInitListener;
import practice.lange.antlr4.ArrayInitParser;

public class LangeListener implements ArrayInitListener {
    @Override
    public void enterInit(ArrayInitParser.InitContext ctx) {
        System.out.println("enterInit=" + ctx.getText());
    }

    @Override
    public void exitInit(ArrayInitParser.InitContext ctx) {
        System.out.println("exitInit=" + ctx.getText());
    }

    @Override
    public void enterValue(ArrayInitParser.ValueContext ctx) {
        System.out.println("enterValue=" + ctx.getText());
    }

    @Override
    public void exitValue(ArrayInitParser.ValueContext ctx) {
        System.out.println("exitValue=" + ctx.getText());
    }

    @Override
    public void visitTerminal(TerminalNode terminalNode) {
        //
    }

    @Override
    public void visitErrorNode(ErrorNode errorNode) {
        //
    }

    @Override
    public void enterEveryRule(ParserRuleContext parserRuleContext) {
        //
    }

    @Override
    public void exitEveryRule(ParserRuleContext parserRuleContext) {
        //
    }
}
