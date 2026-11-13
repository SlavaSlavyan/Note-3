import java.io.IOException;
import java.util.Scanner;


public class UI {
    private static final String MENU_STRING = """
    ===============[SLL ACTION MANAGER]===============

      1. Do action
      2. Undo action
      3. Redo action
      4. Show history
      0. Exit

    >>\s""";

    public static void clearConsole() {
        try {
            String operatingSystem = System.getProperty("os.name");
            
            if (operatingSystem.contains("Windows")) {
                new ProcessBuilder("cmd", "/c", "cls").inheritIO().start().waitFor();
            } else {
                new ProcessBuilder("/bin/bash", "-c", "clear").inheritIO().start().waitFor();
            }
        } catch (IOException | InterruptedException e) {
            System.err.println(e.toString());
        }
    }

    public static int menu(Scanner scanner, int functionsCount) {
        int userInput;
        
        while (true) {
            clearConsole();
            System.out.print(MENU_STRING);
            
            try {
                userInput = Integer.parseInt(scanner.nextLine());
            } catch (NumberFormatException | NullPointerException e) {
                clearConsole();
                System.out.println("Invalid Input!");
                scanner.nextLine();
                continue;
            }

            if (userInput < 0 || userInput >= functionsCount) {
                clearConsole();
                System.out.println("No such function!");
                scanner.nextLine();
                continue;
            }

            return userInput;
        }
    }
}
