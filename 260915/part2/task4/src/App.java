import java.util.Scanner;

public class App 
{
    public static void main(String[] args) throws Exception 
    {
        Scanner sc = new Scanner(System.in);

        System.out.print("Enter first number << ");
        double a = sc.nextDouble();

        System.out.print("Enter second number << ");
        double b = sc.nextDouble();

        System.out.print("Enter operation [+, -, *, /] << ");
        char op = sc.next().charAt(0);

        switch (op)
        {
            case '+':
                System.out.printf("%.3f%n", a + b);
                break;

            case '-':
                System.out.printf("%.3f%n", a - b);
                break;

            case '*':
                System.out.printf("%.3f%n", a * b);
                break;

            case '/':
                if (b == 0.0) 
                {
                    System.out.println("Error: division by zero!");
                    break;
                }
                
                System.out.printf("%.3f%n", a / b);
                break;

            default:
                System.out.println("Unknown operation.");
        }

        sc.close();
    }
}
