import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {

        int sec;
        Scanner scanner = new Scanner(System.in);

        System.out.print("Seconds << ");
        sec = Integer.parseInt(scanner.nextLine());

        System.out.println("\nMinutes >> " + String.format("%.2f", (sec / 60.0f)) + 
        "\nHours >> " + String.format("%.2f", (sec / 60.0f / 60)) + "\n\nPress ENTER to exit...\n");

        scanner.nextLine();
    }
}