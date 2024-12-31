import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

import java.io.BufferedReader;
import java.io.InputStreamReader;

@RestController
public class OsInjectionController {

    @GetMapping("/api/osInjection/{binFile}")
    public String os(@PathVariable String binFile) {
        StringBuilder output = new StringBuilder();

        try {
            // Vulnerable to OS Command Injection
            Process process = Runtime.getRuntime().exec(binFile); // Noncompliant
            BufferedReader reader = new BufferedReader(new InputStreamReader(process.getInputStream()));

            String line;
            while ((line = reader.readLine()) != null) {
                output.append(line).append("\n");
            }

            reader.close();
            process.destroy();
        } catch (Exception e) {
            return "Error: " + e.getMessage();
        }

        return output.toString();
    }
}

