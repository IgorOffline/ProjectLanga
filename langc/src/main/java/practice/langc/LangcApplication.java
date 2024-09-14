package practice.langc;

import org.antlr.v4.runtime.ANTLRFileStream;
import org.antlr.v4.runtime.CommonTokenStream;
import org.antlr.v4.runtime.tree.ParseTreeWalker;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import practice.langc.antlr4.HelloLexer;
import practice.langc.antlr4.HelloParser;

import java.io.IOException;

@SpringBootApplication
public class LangcApplication {

	public static void main(String[] args) throws IOException {
		System.out.println("<START>");
		var lexer = new HelloLexer(new ANTLRFileStream("test.txt"));
		var tokens = new CommonTokenStream(lexer);
		var parser = new HelloParser(tokens);
		var tree = parser.r();
		var walker = new ParseTreeWalker();
		walker.walk(new LangcListener(), tree);
		System.out.println("<END>");
		SpringApplication.run(LangcApplication.class, args);
	}

}
