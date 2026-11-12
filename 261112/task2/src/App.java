import java.util.Scanner;
import java.util.Stack;

public class App {
    public static final String START_BRACKETS = "([{";
    public static final String END_BRACKETS = ")]}";
    
    public static void main(String[] args) throws Exception {
        
        boolean isCorrect = true;
        Stack<Character> brackets = new Stack<>();
        System.out.print("Input string for bracket check << ");

        try (Scanner scanner = new Scanner(System.in)) {

            String word = scanner.nextLine();

            for (int i = 0; i < word.length(); i++) {

                if (START_BRACKETS.indexOf(word.charAt(i)) != -1) {
                    brackets.push(word.charAt(i));
                }

                if (END_BRACKETS.indexOf(word.charAt(i)) != -1) {

                    if (brackets.isEmpty()) {
                        isCorrect = false;
                        break;
                    }

                    char _braket = brackets.pop();

                    if (START_BRACKETS.indexOf(_braket) != END_BRACKETS.indexOf(word.charAt(i))) {
                        isCorrect = false;
                        break;
                    }
                }
            }

            if (!isCorrect || !brackets.isEmpty()) {
                System.out.println("Input is incorrect!");
            } else {
                System.out.println("Input is correct!");
            }

            System.out.println("\nPress ENTER to exit...");
            scanner.nextLine();
            
        } catch (Exception e) {
            System.err.println(e.toString());
        }
    }
}
