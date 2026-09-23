import java.util.Scanner;

public class App 
{
    public static void main(String[] args) throws Exception 
    {
        int end, n1 = 0, n2 = 1;
        Scanner scanner = new Scanner(System.in);

        System.out.print("Number << ");
        end = Integer.parseInt(scanner.nextLine());

        System.out.print("Fibonacci >> [0, 1");

        while (n2 < end)
        {
            int _temp = n1 + n2;
            n1 = n2;
            n2 = _temp;

            if (_temp < end) System.out.print(", " + _temp);
        }

        System.out.println("]\n\nPress ENTER to exit...");

        scanner.nextLine();
        scanner.close();
    }
}
