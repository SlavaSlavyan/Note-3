import java.util.Scanner;

public class App 
{
    public static void main(String[] args) throws Exception 
    {
        int number = 42;
        Scanner scanner = new Scanner(System.in);

        while (true) 
        { 
            System.out.print("Guess number >> ");
            
            int user_inp = Integer.parseInt(scanner.nextLine());
            
            if (user_inp > number)
            {
                System.out.println("smaller...");
            }
            else if (user_inp < number)
            {
                System.out.println("bigger...");
            }
            else break;
        }
            
        

        System.out.println("Nice!\n\nPress ENTER to exit...");

        scanner.nextLine();
        scanner.close();
    }
}
