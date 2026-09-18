import java.util.Scanner;

public class App 
{
    public static void main(String[] args) throws Exception 
    {

        for (int i = 1; i < 11; i++) {
            System.out.println(i);
        }

        System.out.println("\nPress ENTER to exit...");

        Scanner scanner = new Scanner(System.in);
        scanner.nextLine();
        scanner.close();
    }
}
