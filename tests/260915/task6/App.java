import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {

        int n1, n2, n3, max;
        Scanner scanner = new Scanner(System.in);

        System.out.print("Number 1 << ");
        n1 = Integer.parseInt(scanner.nextLine());
        System.out.print("Number 2 << ");
        n2 = Integer.parseInt(scanner.nextLine());
        System.out.print("Number 3 << ");
        n3 = Integer.parseInt(scanner.nextLine());

        max = (n1 > n2) ? n1 : n2;
        max = (max > n3) ? max : n3;

        System.out.println("Max >> " + max + "\n\nPress ENTER to exit...\n");

        scanner.nextLine();
    }
}