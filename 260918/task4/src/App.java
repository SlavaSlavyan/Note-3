import java.util.Scanner;

public class App 
{
    public static void main(String[] args) throws Exception 
    {
        int n, sum = 0;
        Scanner scanner = new Scanner(System.in);

        System.out.print("N >> ");
        n = Integer.parseInt(scanner.nextLine()) - 1;

        while (n > 0)
        {
            sum += n;
            n--;
        }

        System.out.println("Sum from 1 to N >> " + sum + "\n\nPress ENTER to exit...");

        scanner.nextLine();
        scanner.close();
    }
}
