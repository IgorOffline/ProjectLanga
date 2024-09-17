package practice.langf;

import org.antlr.v4.runtime.ParserRuleContext;
import org.antlr.v4.runtime.tree.ErrorNode;
import org.antlr.v4.runtime.tree.TerminalNode;
import practice.langf.antlr4.AddSubtractListener;
import practice.langf.antlr4.AddSubtractParser;

import java.util.ArrayDeque;
import java.util.Deque;
import java.util.HashMap;
import java.util.Map;

public class LangfListener implements AddSubtractListener {

    private final Deque<LangfOperation> operations = new ArrayDeque<>();
    public final Map<String, Integer> values = new HashMap<>();

    public static final String FIRST = "first";

    public LangfListener() {
        values.put(FIRST, 0);
    }

    @Override
    public void enterAdd(AddSubtractParser.AddContext ctx) {
        System.out.println("enterAdd=" + ctx.getText() + ";" + operations);
        operations.add(LangfOperation.ADD);
    }

    @Override
    public void exitAdd(AddSubtractParser.AddContext ctx) {
        System.out.println("exitAdd=" + ctx.getText() + ";" + operations);
    }

    @Override
    public void enterSubtract(AddSubtractParser.SubtractContext ctx) {
        System.out.println("enterSubtract=" + ctx.getText() + ";" + operations);
        operations.add(LangfOperation.SUBTRACT);
    }

    @Override
    public void exitSubtract(AddSubtractParser.SubtractContext ctx) {
        System.out.println("exitSubtract=" + ctx.getText() + ";" + operations);
        operations.pop();
    }

    @Override
    public void enterMyint(AddSubtractParser.MyintContext ctx) {
        System.out.println("enterMyint=" + ctx.getText());
        final var operation = operations.peek();
        switch (operation) {
            case ADD:
                final var getAdd = values.get(FIRST);
                final var newGetAdd = getAdd + Integer.parseInt(ctx.getText());
                values.put(FIRST, newGetAdd);
                break;
            case SUBTRACT:
                final var getSubtract = values.get(FIRST);
                final var newGetSubtract = getSubtract - Integer.parseInt(ctx.getText());
                values.put(FIRST, newGetSubtract);
                break;
            case null:
                throw new IllegalStateException("No operation");
            default:
                throw new IllegalArgumentException("Unknown operation=" + operation);
        }
    }

    @Override
    public void exitMyint(AddSubtractParser.MyintContext ctx) {
        System.out.println("exitMyint=" + ctx.getText());
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
