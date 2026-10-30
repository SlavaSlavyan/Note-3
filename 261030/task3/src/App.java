import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Scanner;

public class App {
    private static final String INPUT_FILE_PATH = "input.txt";
    private static final String OUTPUT_FILE_PATH = "output.txt";

    public static void main(String[] args) throws Exception {
        System.out.println("==========[SLL FORMATER]==========\n");

        try (BufferedReader reader = new BufferedReader(new FileReader(INPUT_FILE_PATH));
             BufferedWriter writer = new BufferedWriter(new FileWriter(OUTPUT_FILE_PATH))) {

            String line;
            int line_ID = 1;

            while ((line = reader.readLine()) != null) { 
                if (line.length() > 10) {
                    writer.write(line_ID + ": " + line);
                    writer.newLine();
                    line_ID++;
                }
            }
            writer.write("--- END ---");

            System.out.println("Filtered " + (line_ID - 1) + " lines.");

            try (Scanner scanner = new Scanner(System.in)) {
                System.out.println("\nPress ENTER to exit...");
                scanner.nextLine();
            } catch (Exception e) {
                System.err.println("Error: " + e.toString());
            }
            
        } catch (IOException e) {
            System.err.println("Error: " + e.toString());
        }
    }
}
