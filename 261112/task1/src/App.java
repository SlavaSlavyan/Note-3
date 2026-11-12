import java.util.Scanner;
import java.util.Stack;

public class App {
    public static void main(String[] args) throws Exception {
        
        Stack<Character> reversed_word = new Stack<>();
        System.out.print("Input word << ");
        
        try (Scanner scanner = new Scanner(System.in)) {

            String word = scanner.nextLine();

            for (int i = 0; i < word.length(); i++) {
                reversed_word.push(word.charAt(i));
            }

            System.out.print("Reversed word >> ");

            while (!reversed_word.isEmpty()) {
                System.out.print(reversed_word.pop());
            }

            System.out.println("\n\nPress ENTER to exit...");
            scanner.nextLine();

        } catch (Exception e) {
            System.err.println(e.toString());
        }
    }
}
