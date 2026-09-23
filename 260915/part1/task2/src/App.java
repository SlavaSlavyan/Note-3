import java.util.Scanner;

public class App 
{
    public static void main(String[] args) throws Exception 
    {
        int user_inp;
        Scanner scanner = new Scanner(System.in);

        System.out.print("Number << ");
        user_inp = Integer.parseInt(scanner.nextLine());

        if (user_inp > 100) System.out.println("\nInvalid Input!");

        else if (user_inp > 89) System.out.println("\nGrade >> A");

        else if (user_inp > 79) System.out.println("\nGrade >> B");

        else if (user_inp > 69) System.out.println("\nGrade >> C");

        else if (user_inp > 59) System.out.println("\nGrade >> D");

        else if (user_inp > -1) System.out.println("\nGrade >> F");

        else System.out.println("\nInvalid Input!");

        System.out.println("\nPress ENTER to exit...");
        scanner.nextLine();
        scanner.close();
    }
}