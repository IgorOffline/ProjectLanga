package practice.lange;

import org.antlr.v4.runtime.ANTLRFileStream;
import org.antlr.v4.runtime.CommonTokenStream;
import org.antlr.v4.runtime.tree.ParseTreeWalker;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import practice.lange.antlr4.ArrayInitLexer;
import practice.lange.antlr4.ArrayInitParser;

import java.io.IOException;

@SpringBootApplication
public class LangeApplication {

	public static void main(String[] args) throws IOException {
		System.out.println("<START>");
		var lexer = new ArrayInitLexer(new ANTLRFileStream("input.txt"));
		var tokens = new CommonTokenStream(lexer);
		var parser = new ArrayInitParser(tokens);
		var tree = parser.init();
		var walker = new ParseTreeWalker();
		walker.walk(new LangeListener(), tree);
		System.out.println("<END>");
		SpringApplication.run(LangeApplication.class, args);
	}

}
