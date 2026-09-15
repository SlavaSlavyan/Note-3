import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {

        float price, sale;
        Scanner scanner = new Scanner(System.in);

        System.out.print("Price << ");
        price = Float.parseFloat(scanner.nextLine());
        System.out.print("Sale (%) << ");
        sale = Float.parseFloat(scanner.nextLine());

        price -= price * (sale/100);

        System.out.printf("Rusult price >> " + price);

        System.out.print("\n\nPress ENTER to exit...\n");
        scanner.nextLine();
    }
}