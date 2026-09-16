import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {

        int num1, num2, num3;
        Scanner scanner = new Scanner(System.in);

        System.out.print("Number 1 << ");
        num1 = Integer.parseInt(scanner.nextLine());
        System.out.print("Number 2 << ");
        num2 = Integer.parseInt(scanner.nextLine());
        System.out.print("Number 3 << ");
        num3 = Integer.parseInt(scanner.nextLine());

        System.out.println("\nResult >> " + String.format("%.2f", ((num1 + num2 + num3) / 3.0f)) + "\n\nPress ENTER to exit...\n");

        scanner.nextLine();
    }
}