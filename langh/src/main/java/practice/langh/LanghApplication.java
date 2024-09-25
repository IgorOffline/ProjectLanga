package practice.langh;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class LanghApplication {

	public static void main(String[] args) {
		System.out.println("<START>");
		System.out.println("<END>");
		SpringApplication.run(LanghApplication.class, args);
	}

}
