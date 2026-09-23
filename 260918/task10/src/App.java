import java.util.Scanner;

public class App 
{
    public static int fizz_buzz_check(int n) 
    {
        if (n < 1 || n > 99) return 0; // "Error"

        if (n % 3 == 0 && n % 5 == 0) return 1; // "Fizz Buzz"

        if (n % 3 == 0) return 2; // "Fizz"

        if (n % 5 == 0) return 3; // "Buzz"
        
        return 4; // "None"
    }

    public static void main(String[] args) throws Exception 
    {
        int n, result;
        Scanner scanner = new Scanner(System.in);

        System.out.print("Number [1-99] << ");
        n = Integer.parseInt(scanner.nextLine());

        result = fizz_buzz_check(n);

        switch (result) {
            case 0:
                System.out.println("Invalid number input!");
                break;
            case 1:
                System.out.println("Fizz Buzz!");
                break;
            case 2:
                System.out.println("Fizz!");
                break;
            case 3:
                System.out.println("Buzz!");
                break;

            case 4:
                int nearest = -1;

                for (int i = n; i < 100; i++) 
                {
                    if (fizz_buzz_check(i) == 1)
                    {
                        nearest = i;
                        break;
                    }
                }

                for (int i = n; i > 0; i--)
                {
                    if (fizz_buzz_check(i) == 1)
                    {
                        if (i < nearest || nearest == -1) nearest = i;
                        break;
                    }
                }

                System.out.println("Not an Fizz or Buzz.\nNearest Fizz Buzz is " + nearest);

                break;
        }

        System.out.println("\nPress ENTER to exit...");

        scanner.nextLine();
        scanner.close();
    }
}
