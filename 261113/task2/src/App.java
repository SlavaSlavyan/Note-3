import java.util.ArrayDeque;
import java.util.Deque;
import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
        int k;
        Deque<Integer> deque = new ArrayDeque<>();

        try (Scanner scanner = new Scanner(System.in)) {
            while (true) { 
                System.out.print("K << ");
                
                try {
                    k = Integer.parseInt(scanner.nextLine());
                } catch (NumberFormatException | NullPointerException e) {
                    System.out.println("Invalid input!");
                    continue;
                }

                if (k <= 1) {
                    System.out.println("Number value must be above 1!");
                    continue;
                }
                
                break;
            }

            System.out.println("\nPrint `/end` for end deque");

            while (true) { 
                System.out.print("Deque element [" + deque.size() + "] << ");
                
                String _userInput = scanner.nextLine();

                if (_userInput.equals("/end")) {
                    if (deque.size() < k) {
                        System.out.println("Deque size needs to be bigger than " + k + "!");
                        continue;
                    }
                    break;
                }
                
                try {
                    deque.addLast(Integer.valueOf(_userInput));
                } catch (NumberFormatException | NullPointerException e) {
                    System.out.println("Invalid input!");
                }
            }

            System.out.println("\nOriginal deque >> " + deque);

            Deque<Integer> _tempDeque = new ArrayDeque<>();

            for (int i = 0; i < k; i++) {
                _tempDeque.addLast(deque.removeFirst());
            }

            for (int i = 0; i < k; i++) {
                deque.addFirst(_tempDeque.removeFirst());
            }

            System.out.println("New deque >> " + deque);
            
        } catch (Exception e) {
            System.err.println(e.toString());
        }
    }
}
