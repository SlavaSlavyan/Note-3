import java.util.Scanner;

public class App 
{
    public static void main(String[] args) throws Exception 
    {
        int age;

        // меня бесит постоянная плашка предупреждения
        @SuppressWarnings("resource")
        Scanner scanner = new Scanner(System.in);
        
        System.out.print("Age << ");
        age = Integer.parseInt(scanner.nextLine());

        if (age < 0) System.out.println("\nInvalid age number!");

        else if (age < 6) System.out.println("\nFree ticket :)");

        else if (age < 18) System.out.println("\nTicket cost >> 300 rub.");

        else if (age < 60) System.out.println("\nTicket cost >> 500 rub.");

        else System.out.println("\nTicket cost >> 250 rub.");

        System.out.println("\nPress ENTER to exit...");
        
        scanner.nextLine();

        scanner.close();
    }
}