import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
        try (Scanner scanner = new Scanner(System.in)) {
            int userInput;
            
            while (true) { 
                userInput = UI.menu(scanner, 5);

                if (userInput == 0) {
                    break;
                }
                
                dofunction(userInput, scanner);
            }
        } catch (Exception e) {
            System.err.println(e.toString());
        }
    }

    public static void dofunction(int functionID, Scanner scanner) {
        switch (functionID) {
            case 1 -> ActionManager.doAction(scanner);
            case 2 -> {
                History.undo();
                scanner.nextLine();
            }
            case 3 -> {
                History.redo();
                scanner.nextLine();
            }
            case 4 -> {
                History.print();
                scanner.nextLine();
            }
            default -> throw new AssertionError();
        }
    }
}