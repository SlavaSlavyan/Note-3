import java.util.Scanner;

public class App 
{
    public static void main(String[] args) throws Exception 
    {
        for (int x = 1; x < 11; x++)
        {
            for (int y = 1; y < 11; y++)
            {
                System.out.printf("%02d * %02d = %02d; ", x, y, x * y);
            }

            System.out.print('\n');
        }

        System.out.println("\nPress ENTER to exit...");

        Scanner scanner = new Scanner(System.in);
        scanner.nextLine();
        scanner.close();
    }
}
