import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {

        int num1, num2;
        Scanner scanner = new Scanner(System.in);

        System.out.print("Number 1 << ");
        num1 = Integer.parseInt(scanner.nextLine());
        System.out.print("Number 2 << ");
        num2 = Integer.parseInt(scanner.nextLine());

        // через дополнительную переменную
        {
            int _temp = num1;
            num1 = num2;
            num2 = _temp;
        }

        System.out.println("\nSwap! N1 >> " + num1 + " | N2 >> " + num2);

        // БЕЗ дополнительной переменной (через XOR)
        num1 = num1 ^ num2;
        num2 = num1 ^ num2;
        num1 = num1 ^ num2;

        System.out.println("\nSwap! N1 >> " + num1 + " | N2 >> " + num2);

        System.out.println("\n\nPress ENTER to exit...\n");

        scanner.nextLine();
    }
}