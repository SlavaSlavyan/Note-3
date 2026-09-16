import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {

        int c;
        Scanner scanner = new Scanner(System.in);

        System.out.print("Celsius << ");
        c = Integer.parseInt(scanner.nextLine());

        System.out.println("Fahrenheit >> " + (c * 9/5.0f + 32) + "\n\nPress ENTER to exit...\n");

        scanner.nextLine();
    }
}