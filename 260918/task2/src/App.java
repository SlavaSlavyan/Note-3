import java.util.Scanner;

public class App 
{
    public static void main(String[] args) throws Exception 
    {
        long sum = 0;

        for (int i = 1; i < 101; i++) 
        {
            sum += i;
        }

        System.out.println("Sum of 100 >> " + sum + "\n\nPress ENTER to exit...");

        Scanner scanner = new Scanner(System.in);
        scanner.nextLine();
        scanner.close();
    }
}
