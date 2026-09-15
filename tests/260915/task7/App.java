import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {

        int a, b;
        Scanner scanner = new Scanner(System.in);

        System.out.print("Lenght << ");
        a = Integer.parseInt(scanner.nextLine());
        System.out.print("Width << ");
        b = Integer.parseInt(scanner.nextLine());

        System.out.println("Perimeter >> " + (a + b) * 2 + "\nSpace >> " + a * b + "\n\nPress ENTER to exit...\n");

        scanner.nextLine();
    }
}