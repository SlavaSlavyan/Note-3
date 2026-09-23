import java.util.Scanner;

public class App 
{
    public static void main(String[] args) throws Exception 
    {
        int n, even_count = 0;
        Scanner scanner = new Scanner(System.in);

        System.out.print("Number << ");
        n = Integer.parseInt(scanner.nextLine());

        for (int i = 1; i < n; i++)
        {
            if (i % 2 == 0)
            {
                System.out.println("Number " + i + " is EVEN");
                even_count++;
                continue;
            }

            System.out.println("Number " + i + " is ODD");
        }

        System.out.println("\nCount of even numbers >> " + even_count);

        System.out.println("\nPress ENTER to exit...");

        scanner.nextLine();
        scanner.close();
    }
}
