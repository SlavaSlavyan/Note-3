import java.util.Scanner;

public class App 
{
    public static final int HEIGHT = 7;

    public static void main(String[] args) throws Exception 
    {
        Scanner scanner = new Scanner(System.in);

        for (int i = 0; i < HEIGHT; i++)
        {
            for (int j = 0; j < HEIGHT - i; j++)
            {
                System.out.print(" ");
            }

            for (int j = 0; j < i * 2 + 1; j++)
            {
                System.out.print("*");
            }
            
            System.out.println();
        }

        System.out.println("\nPress ENTER to exit...");

        scanner.nextLine();
        scanner.close();
    }
}
