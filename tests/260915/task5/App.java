import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {

        int n;
        String result = new String() ;
        Scanner scanner = new Scanner(System.in);

        System.out.print("Number << ");
        n = Integer.parseInt(scanner.nextLine());

        result = (n % 2 == 0) ? "even" : "odd";

        System.out.println("Result >> " + result + "\n\nPress ENTER to exit...\n");

        scanner.nextLine();
    }
}