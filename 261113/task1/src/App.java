import java.util.ArrayDeque;
import java.util.Deque;
import java.util.Objects;
import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
        String userInput;
        boolean isPalindrome = true;

        try (Scanner scanner = new Scanner(System.in)) {
            while (true) { 
                System.out.print("word << ");
                userInput = scanner.nextLine();

                if (!(userInput.isBlank() || userInput.isEmpty())) {
                    break;
                }
                
                System.out.println("Invalid input.");
            }

            userInput = userInput.replaceAll(" ", "").toLowerCase();

            Deque<Character> deque = new ArrayDeque<>();

            for (int i = 0; i < userInput.length(); i++) {
                deque.add(userInput.charAt(i));
            }

            while (!deque.isEmpty()) {
                if (deque.size() == 1) {
                    break;
                }
                
                if (!(Objects.equals(deque.removeFirst(), deque.removeLast()))) {
                    isPalindrome = false;
                    break;
                }
            }

            if (isPalindrome) {
                System.out.println("IS palindrome!");
            } else {
                System.out.println("NOT palindrome!");
            }

            System.out.println("\nPress ENTER to exit...");
            scanner.nextLine();
            
        } catch (Exception e) {
            System.err.println(e.toString());
        }
    }
}
