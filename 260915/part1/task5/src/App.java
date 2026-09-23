import java.util.Scanner;

public class App 
{
    public static void main(String[] args) throws Exception 
    {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Month number << ");
        int user_inp = Integer.parseInt(scanner.nextLine());

        switch (user_inp) 
        {
            case 1 -> System.out.println("\nSelected month >> January");
            case 2 -> System.out.println("\nSelected month >> February");
            case 3 -> System.out.println("\nSelected month >> March");
            case 4 -> System.out.println("\nSelected month >> April");
            case 5 -> System.out.println("\nSelected month >> May");
            case 6 -> System.out.println("\nSelected month >> June");
            case 7 -> System.out.println("\nSelected month >> July");
            case 8 -> System.out.println("\nSelected month >> August");
            case 9 -> System.out.println("\nSelected month >> September");
            case 10 -> System.out.println("\nSelected month >> October");
            case 11 -> System.out.println("\nSelected month >> November");
            case 12 -> System.out.println("\nSelected month >> December");
            default -> System.out.println("\nInvalid number!");
        }

        System.out.println("\nPress ENTER to exit...");
        scanner.nextLine();
        scanner.close();
    }
}