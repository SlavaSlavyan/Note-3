import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.Scanner;


public class App {
    public static void main(String[] args) throws Exception {
        System.out.println("==========[SLL TEXT ANALYZER]==========\n");

        try (Scanner scanner = new Scanner(System.in)) {
            
            System.out.print("Path to file << ");
            String path = scanner.nextLine();

            try (BufferedReader reader = new BufferedReader(new FileReader(path))) {
                System.out.println("Data from file `" + path + "` >> [");

                String line, longest_word = "";
                int[] stats = new int[3];
                boolean empty = true;

                while ((line = reader.readLine()) != null) {
                    System.out.println("  " + line);

                    stats[0]++;
                    String[] words = line.split("\\s+");
                    
                    for (String word : words) {
                        if (word.length() > longest_word.length()) {
                            longest_word = word;
                        }

                        stats[1]++;
                    }

                    if (line.contains("Java")) {
                        stats[2]++;
                    }

                    empty = false;
                }

                if (empty) {
                    System.out.println("];\n\nFile is empty.");
                } else {
                    System.out.println("];\n\nStats:\n  Lines: " + stats[0] + 
                                       "\n  Words: " + stats[1] + 
                                       "\n  Longest word: " + longest_word + 
                                       "\n  Lines with word `Java`: " + stats[2]);
                }

            } catch (java.io.FileNotFoundException e) {
                System.err.println("\nCannot found file `" + path + "`");
            } catch (IOException e) {
                System.err.println("\nError: " + e.toString());
            }

            System.out.println("\nPress ENTER to exit...");
                scanner.nextLine();

        } catch (Exception e) {
            System.err.println("Error: " + e.toString());
        }
    }
}
