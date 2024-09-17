package practice.langf;

import org.antlr.v4.runtime.ANTLRFileStream;
import org.antlr.v4.runtime.CommonTokenStream;
import org.antlr.v4.runtime.tree.ParseTreeWalker;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import practice.langf.antlr4.AddSubtractLexer;
import practice.langf.antlr4.AddSubtractParser;

import java.io.IOException;

@SpringBootApplication
public class LangfApplication {

	public static void main(String[] args) throws IOException {
		System.out.println("<START>");
		int add = 0;
		int subtract = 0;
		{
			var lexer = new AddSubtractLexer(new ANTLRFileStream("input-add.txt"));
			var tokens = new CommonTokenStream(lexer);
			var parser = new AddSubtractParser(tokens);
			var tree = parser.add();
			var walker = new ParseTreeWalker();
			final var langfListener = new LangfListener();
			walker.walk(langfListener, tree);
			System.out.println("langfListener.values=" + langfListener.values);

			add = langfListener.values.get(LangfListener.FIRST);
		}
		{
			var lexer = new AddSubtractLexer(new ANTLRFileStream("input-subtract.txt"));
			var tokens = new CommonTokenStream(lexer);
			var parser = new AddSubtractParser(tokens);
			var tree = parser.subtract();
			var walker = new ParseTreeWalker();
			final var langfListener = new LangfListener();
			walker.walk(langfListener, tree);
			System.out.println("langfListener.values=" + langfListener.values);

			subtract = langfListener.values.get(LangfListener.FIRST);
		}
		final var sum = add + subtract;
		System.out.println("sum=" + sum);
		System.out.println("<END>");
		SpringApplication.run(LangfApplication.class, args);
	}

}
