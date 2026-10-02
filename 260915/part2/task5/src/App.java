import java.util.Scanner;

public class App 
{
    public static void main(String[] args) 
    {
        Scanner sc = new Scanner(System.in);

        System.out.print("Enter a << ");
        double a = sc.nextDouble();

        System.out.print("Enter b << ");
        double b = sc.nextDouble();

        System.out.print("Enter c << ");
        double c = sc.nextDouble();

        if (a == 0.0) 
        {
            System.out.println("Not a quadratic equation");
            sc.close();
            return;
        }

        double d = b * b - 4 * a * c;

        System.out.printf("D = %.2f%n", d);

        if (d > 0) System.out.println("Two roots");
        else if (d == 0) System.out.println("One root");
        else System.out.println("No roots");
        
        sc.close();
    }
}