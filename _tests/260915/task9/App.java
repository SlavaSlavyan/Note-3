import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {

        String name = new String(), age = new String();
        float avg;
        Scanner scanner = new Scanner(System.in);

        System.out.print("Student Name << ");
        name = scanner.nextLine();
        System.out.print("age << ");
        age = scanner.nextLine();
        System.out.print("Average grade << ");
        avg = Float.parseFloat(scanner.nextLine());

        System.out.printf("\n==========[Student]==========" +
        "\n  Name >> %s" + "\n  Age >> %s" + "\n  AVG >> %.2f\n\n", name, age, avg);


        System.out.print("\n\nPress ENTER to exit...\n");
        scanner.nextLine();
    }
}