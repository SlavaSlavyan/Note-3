import java.io.IOException;
import java.util.Scanner;


public class App {
    private static int player = 1;
    private static final int[] cells = {0,0,0,0,0,0,0,0,0};
    public static void main(String[] args) throws Exception {
        try (Scanner scanner = new Scanner(System.in)) {
            while (true) { 
                makeMove(input(scanner));
                int _winStatus = checkWin();
                if (_winStatus != 0) {
                    printWin(scanner, _winStatus);
                    break;
                }
                switchPlayer();
            }
        } catch (Exception e) {
            System.err.println(e.toString());
        }
    }

    private static int input(Scanner scanner) {
        int userInput;

        while (true) { 
            printCells();
            try {
                userInput = Integer.parseInt(scanner.nextLine()) - 1;          
            } catch (NumberFormatException | NullPointerException e) {
                errorPrint(scanner, "Invalid input!");
                continue;
            }

            if (userInput < 0 || userInput > 8) {
                errorPrint(scanner, "No such cell!");
                continue;
            }

            if (cells[userInput] != 0) {
                errorPrint(scanner, "Cell is already taken!");
                continue;
            }

            return userInput;
        }
    }

    private static void clearConsole() {
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

    private static void errorPrint(Scanner scanner, String message) {
        clearConsole();
        System.out.println(message);
        scanner.nextLine();
    }

    private static void makeMove(int cell) {
        cells[cell] = player;
    }

    private static void switchPlayer() {
        if (player == 1) {
            player = 2;
            return;
        }
        player = 1;
    }

    private static int checkWin() {
        for (int p = 1; p < 3; p++) {
            for (int i = 0; i < 3; i++) {
                if (cells[i] == p && cells[i+3] == p && cells[i+6] == p) {
                    return p;
                }
                if (cells[3*i] == p && cells[3*i+1] == p && cells[3*i+2] == p) {
                    return p;
                }
            }
            if (cells[0] == p && cells[4] == p && cells[8] == p) {
                return p;
            }
            if (cells[2] == p && cells[4] == p && cells[6] == p) {
                return p;
            }
        }

        boolean isFull = true;

        for (int i : cells) {
            if (i == 0) {
                isFull = false;
                break;
            }
        }

        if (isFull) {
            return -1;
        }

        return 0;
    }

    private static void printCells() {
        clearConsole();
        for (int i = 0; i < 9; i++) {
            switch (cells[i]) {
                case 0 -> System.out.print(". ");
                case 1 -> System.out.print("X ");
                case 2 -> System.out.print("0 ");
            }
            if ((i + 1) % 3 == 0) {
                System.out.print("\n");
            }
        }

        System.out.print("\n>> ");
    }

    private static void printWin(Scanner scanner, int winStatus) {
        clearConsole();
        if (winStatus == -1) {
            System.out.println("Draw.");
        }
        else {
            System.out.println("Player " + player + " winner!");
        }

        System.out.println("\nPress ENTER to exit...");
        scanner.nextLine();
    }
}