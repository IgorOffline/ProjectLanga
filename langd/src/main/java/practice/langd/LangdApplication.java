package practice.langd;

import org.antlr.v4.runtime.ANTLRFileStream;
import org.antlr.v4.runtime.CommonTokenStream;
import org.antlr.v4.runtime.tree.ParseTreeWalker;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import practice.langd.antlr4.AddLexer;
import practice.langd.antlr4.AddParser;

import java.io.IOException;

@SpringBootApplication
public class LangdApplication {

	public static void main(String[] args) throws IOException {
		System.out.println("<START>");
		var lexer = new AddLexer(new ANTLRFileStream("equation.txt"));
		var tokens = new CommonTokenStream(lexer);
		var parser = new AddParser(tokens);
		var tree = parser.equation();
		var walker = new ParseTreeWalker();
		walker.walk(new LangdListener(), tree);
		System.out.println("<END>");
		SpringApplication.run(LangdApplication.class, args);
	}

}
