package practice.langb;

import org.antlr.v4.runtime.ANTLRFileStream;
import org.antlr.v4.runtime.ANTLRInputStream;
import org.antlr.v4.runtime.CodePointBuffer;
import org.antlr.v4.runtime.CodePointCharStream;
import org.antlr.v4.runtime.CommonTokenStream;
import org.antlr.v4.runtime.tree.ParseTreeWalker;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import practice.langb.antlr4.HelloBaseListener;
import practice.langb.antlr4.HelloLexer;
import practice.langb.antlr4.HelloParser;

import java.io.IOException;
import java.nio.CharBuffer;

@SpringBootApplication
public class LangbApplication {

	public static void main(String[] args) throws IOException {
		System.out.println("<START>");
		var str = "hello world";
		var lexer = new HelloLexer(new ANTLRFileStream("test.txt"));
		var tokens = new CommonTokenStream(lexer);
		var parser = new HelloParser(tokens);
		var tree = parser.r();
		var walker = new ParseTreeWalker();
		walker.walk(new LangbListener(), tree);
		System.out.println("<END>");
		SpringApplication.run(LangbApplication.class, args);
	}

}
