package practice.langg;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class LanggApplication {

	public static void main(String[] args) {
		System.out.println("<START>");
		System.out.println("<END>");
		SpringApplication.run(LanggApplication.class, args);
	}

}
