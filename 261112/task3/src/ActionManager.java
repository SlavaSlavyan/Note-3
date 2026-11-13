import java.util.Scanner;

public class ActionManager {
    public static void doAction(Scanner scanner) {
        UI.clearConsole();
        System.out.println("===============[DO ACTION]===============\n");

        String userInput;

        while (true) { 
            System.out.print("  Action << ");
            userInput = scanner.nextLine();

            if (!(userInput.isBlank() | userInput.isEmpty())) {
                break;
            }

            System.out.println("  Action cannot be empty!");
        }

        Action act = new Action(userInput);
        History.pushAction(act);

        UI.clearConsole();
        System.out.println("New action added!");
        scanner.nextLine();
    }
}
