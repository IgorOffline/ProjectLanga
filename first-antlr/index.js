import antlr from 'antlr4';
import HelloLexer from './generated/HelloLexer'
import HelloParser from './generated/HelloParser'
import HelloListener from './generated/HelloListener'

class HelloListenerExtended extends HelloListener {

    enterR(ctx) {
        console.log(`enterR=${ctx.getText()}`);
    }

    exitR(ctx) {
        console.log(`exitR=${ctx.getText()}`);
    }

    visitTerminal() {
        //
    }
    visitErrorNode() {
        //
    }
    enterEveryRule() {
        //
    }
    exitEveryRule() {
        //
    }
}

console.log('<START>');
const input = 'hello one two three';
const chars = new antlr.InputStream(input);
const lexer = new HelloLexer(chars);
const tokens = new antlr.CommonTokenStream(lexer);
const parser = new HelloParser(tokens);
const tree = parser.r();
antlr.tree.ParseTreeWalker.DEFAULT.walk(new HelloListenerExtended(), tree);
console.log('<END>');
