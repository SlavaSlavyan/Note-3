import java.util.Scanner;

public class App 
{
    public static void main(String[] args) throws Exception 
    {
        Scanner scanner = new Scanner(System.in);

        for (int i = 1; i < 10; i++)
        {
            for (int j = 1; j < 10; j++)
            {
                int _temp = i * j;
                if (_temp > 20 && _temp < 70) System.out.print(i + " * " + j + " = " + _temp + "; ");
            }

            System.out.println();
        }

        System.out.println("\nPress ENTER to exit...");

        scanner.nextLine();
        scanner.close();
    }
}
