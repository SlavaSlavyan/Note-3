import java.util.Scanner;

public class App 
{
    public static void main(String[] args) throws Exception 
    {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Celsius << ");
        int user_inp = Integer.parseInt(scanner.nextLine());

        System.out.println("\nFahrenheit >> " + (user_inp * 9/5.0 + 32));

        System.out.println("\nPress ENTER to exit...");
        scanner.nextLine();
        scanner.close();
    }
}