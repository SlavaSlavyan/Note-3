import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Scanner;

public class App {

    private static final String FILE_PATH = "diary.txt";
    public static void main(String[] args) throws Exception {
        System.out.println("==========[SLL WRITER]==========\n\n(for exit input `/exit`)\n");

        int line_count = 0;

        try (Scanner scanner = new Scanner(System.in)) {
            try (BufferedWriter writer = new BufferedWriter(new FileWriter(FILE_PATH, true))) {
                while (true) { 
                    System.out.print("> ");

                    String _userInp = scanner.nextLine();

                    if (_userInp.equals("/exit")) {
                        break;
                    }

                    writer.write(_userInp);
                    writer.newLine();

                    line_count++;
                }
                System.out.println("Saved " + line_count + " lines.\nPress ENTER to exit...");
                
                scanner.nextLine();

            } catch (IOException e) {
                System.err.println("Error: " + e.toString());
            }
        } catch (Exception e) {
            System.err.println("Error: " + e.toString());
        }
    }
}
