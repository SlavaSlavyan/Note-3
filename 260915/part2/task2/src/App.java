import java.util.List;
import  java.util.Scanner;

public class App 
{
    public static final List<String> MONTHS = List.of("January", "February", "March", 
    "April", "May", "June", "July", "August", "September", "October", "November", "December");

    public static void main(String[] args) throws Exception 
    {
        int[] date = new int[3];

        Scanner scanner = new Scanner(System.in);

        System.out.print("Day << ");
        date[0] = Integer.parseInt(scanner.nextLine());

        System.out.print("Month << ");
        date[1] = Integer.parseInt(scanner.nextLine());

        System.out.print("Year << ");
        date[2] = Integer.parseInt(scanner.nextLine());

        if (date[2] < 0) System.out.println("\nYear cannot be negative!");

        else if (date[1] < 1 || date[1] > 12) System.out.println("\nNo such month!");

        else if (date[0] < 1) System.out.println("\nNo such day!");
        
        else
        {
            boolean check = true;

            if (date[1] == 2)
            {
                boolean is_leap = false;
                if (date[2] % 4 == 0 && date[2] % 100 != 0 || date[2] % 400 == 0) is_leap = true;

                if (is_leap && date[0] > 29 || !is_leap && date[0] > 28) check = false;
            }
            else if (date[1] % 2 == 0 && date[1] > 30) check = false;
            
            else if (date[1] > 31) check = false;

            if (check) System.out.println("Date >> " + date[0] + " " + MONTHS.get(date[1] - 1) + " " + date[2] + " year.");

            else System.out.println("\nNo such day!");
        }

        System.out.println("\nPress ENTER to exit...");
        scanner.nextLine();
        scanner.close();
    }
}
