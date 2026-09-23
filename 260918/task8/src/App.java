import java.util.Scanner;

public class App 
{
    public static void main(String[] args) throws Exception 
    {
        String user_inp;
        boolean check = true;
        Scanner scanner = new Scanner(System.in);

        System.out.print("Number << ");
        user_inp = scanner.nextLine();

        for (int i = 0; i < user_inp.length() / 2; i++) 
        {
            if (user_inp.charAt(i) != user_inp.charAt(user_inp.length() - 1 - i)) 
            {
                check = false;
                break;
            }
        }
        
        if (check) System.out.println("IS palindrome.");
        else System.out.println("NOT palindrome.");

        System.out.println("\nPress ENTER to exit...");
        
        scanner.nextLine();
        scanner.close();
    }
}
