import java.util.Scanner;

public class App 
{
    public static void main(String[] args) throws Exception 
    {
        int user_inp, count = 0, sum = 0, max = 0, min = 0;
        Scanner scanner = new Scanner(System.in);

        while (true)
        {
            System.out.print("Number [" + count + "] << ");
            user_inp = Integer.parseInt(scanner.nextLine());
            
            if (user_inp == 0) break;

            if (max == 0 || user_inp > max) max = user_inp;
            
            if (min == 0 || user_inp < min) min = user_inp;

            sum += user_inp;
            
            count++;
        }

        System.out.printf(
            "\nSum of last %d numbers >> %d\nMax number >> %d\nMin number >> %d",
            count, sum, max, min
        );

        System.out.println("\n\nPress ENTER to exit...");

        scanner.nextLine();
        scanner.close();
    }
}
