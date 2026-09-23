import java.util.Scanner;

public class App 
{
    public static void main(String[] args) throws Exception 
    {
        int n, divisors_count = 0;
        Scanner scanner = new Scanner(System.in);

        System.out.print("Number << ");
        n = Integer.parseInt(scanner.nextLine());

        System.out.print("Divisors >> [1");

        for (int i = 2; i < n; i++)
        {
            if (n % i == 0)
            {
                System.out.print(", " + i);
                divisors_count++;
            }
        }

        System.out.println(", " + n + "];");

        if (divisors_count == 0) System.out.println("Simple number!");

        System.out.println("\nPress ENTER to exit...");

        scanner.nextLine();
        scanner.close();
    }
}
