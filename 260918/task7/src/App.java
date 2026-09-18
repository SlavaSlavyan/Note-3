import java.util.Scanner;

public class App 
{
    public static void main(String[] args) throws Exception 
    {
        String user_inp;
        Scanner scanner = new Scanner(System.in);

        System.out.print("Input << ");
        user_inp = scanner.nextLine();
        
        System.out.println("Result >> " + new StringBuilder(user_inp).reverse().toString());

        System.out.println("\nPress ENTER to exit...");

        scanner.nextLine();
        scanner.close();
    }
}
