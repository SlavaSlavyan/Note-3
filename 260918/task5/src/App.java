import java.util.Scanner;

public class App 
{
    
    public static void main(String[] args) throws Exception 
    {
        String PASSWORD = new String("1234");
        Scanner scanner = new Scanner(System.in);

        do 
        { 
            System.out.print("Password << ");

        } 
        while (!PASSWORD.equals(scanner.nextLine()));

        System.out.println("\nSuccess!\n\nPress ENTER to exit...");
        
        scanner.nextLine();
        scanner.close();
    }
}