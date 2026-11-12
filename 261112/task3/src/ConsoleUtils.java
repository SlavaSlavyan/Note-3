import java.io.IOException;
import java.util.Scanner;

public class ConsoleUtils {
    private static final String START_MESSAGE = """
    ==========[SLL ACTION MANAGER]==========

        1. Do action
        2. Undo last action
        3. Redo action
        4. Show history
        0. Exit

    >> 
    """;
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

    public static int UserMenu(Scanner scanner, int funcCount) {

        while (true) { 
            clearConsole();
            System.out.print(START_MESSAGE);
            int _userInput;

            try {
                _userInput = Integer.parseInt(scanner.nextLine());
            } catch (Exception e) {
                clearConsole();
                System.out.println(e.toString());
                scanner.nextLine();
                continue;
            }

            if (_userInput < 0 || _userInput >= funcCount) {
                clearConsole();
                System.out.println("Invali");
                scanner.nextLine();
                continue;
            }
        }
    }
}
