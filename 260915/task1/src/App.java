import java.util.Scanner;

public class App 
{
    public static void main(String[] args) throws Exception 
    {
        int max = 0;
        Scanner scanner = new Scanner(System.in);

        for (int i = 0; i < 3; i++)
        {
            System.out.print("Number [" + i + "] << ");
            int user_inp = Integer.parseInt(scanner.nextLine());

            if (max < user_inp || max == 0) max = user_inp;
        }

        System.out.println("\nMax number >> " + max);

        System.out.println("\nPress ENTER to exit...");
        scanner.nextLine();
        scanner.close();
    }
}