import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;

public class InsecureLoginServlet extends HttpServlet {

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        // Retrieve sensitive data from the login form
        String username = request.getParameter("username");
        String password = request.getParameter("password");

        // Insecure: Logging sensitive information (password in plain text)
        System.out.println("User attempting to login: " + username + " with password: " + password);

        // Insecure: Sending sensitive data in response (password included in error message)
        PrintWriter out = response.getWriter();
        out.println("<html><body>");
        out.println("<h1>Login Failed</h1>");
        out.println("<p>Your password " + password + " is incorrect.</p>");
        out.println("</body></html>");
    }
}

