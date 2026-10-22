import  java.util.List;
import java.util.Random;
import java.util.Scanner;

public class App {

    public static final List<String> ROPE_ANIMATION = List.of(
        "   ####\r\n" + //
                    "   #  |\r\n" + //
                    "   #  \r\n" + //
                    "   #  \r\n" + //
                    "   # \r\n" + //
                    "   #\r\n" + //
                    "#######",
        "   ####\r\n" + //
                        "   #  |\r\n" + //
                        "   #  0\r\n" + //
                        "   #  \r\n" + //
                        "   # \r\n" + //
                        "   #\r\n" + //
                        "#######",
        "   ####\r\n" + //
                        "   #  |\r\n" + //
                        "   #  0\r\n" + //
                        "   #  |\r\n" + //
                        "   # \r\n" + //
                        "   #\r\n" + //
                        "#######",
        "   ####\r\n" + //
                        "   #  |\r\n" + //
                        "   #  0\r\n" + //
                        "   # /|\r\n" + //
                        "   # \r\n" + //
                        "   #\r\n" + //
                        "#######",
        "   ####\r\n" + //
                        "   #  |\r\n" + //
                        "   #  0\r\n" + //
                        "   # /|\\\r\n" + //
                        "   # \r\n" + //
                        "   #\r\n" + //
                        "#######",
        "   ####\r\n" + //
                        "   #  |\r\n" + //
                        "   #  0\r\n" + //
                        "   # /|\\\r\n" + //
                        "   # / \r\n" + //
                        "   #\r\n" + //
                        "#######",
        "   ####\r\n" + //
                        "   #  |\r\n" + //
                        "   #  0\r\n" + //
                        "   # /|\\\r\n" + //
                        "   # / \\\r\n" + //
                        "   #\r\n" + //
                        "#######"
    );

    public static final List<String> WORDS = List.of("test", "doing", "something", "well");

    public static void main(String[] args) throws Exception {
        Scanner scanner = new Scanner(System.in);
        Random random = new Random();

        String word = WORDS.get(random.nextInt(0, WORDS.size()));
        String user_word = "";
        int health = 6;

        for (int i = 0; i < word.length(); i++) {
            user_word += "*";
        }

        while (true) {
            System.out.print(ROPE_ANIMATION.get(ROPE_ANIMATION.size() - health - 1) + "\n\nword >> " + user_word + "\n\n> ");

            String _user_inp;

            try {
                _user_inp = scanner.nextLine().toLowerCase();
                if (_user_inp.length() == 0) {
                    continue;
                }
            } catch (Exception e) {
                continue;
            }

            boolean found = find(word, _user_inp);

            if (!found) {
                health--;
            }
            else {
                user_word = replaceChar(word, user_word, _user_inp);
            }

            if (user_word.equals(word)) {
                System.out.println("You won!");
                break;
            }
            if (health == 0) {
                System.out.print(ROPE_ANIMATION.get(ROPE_ANIMATION.size() - health - 1) + "\n\nYou lose!");
                break;
            }
        }
    }

    public static boolean find(String word, String _user_inp) {

        for (int i = 0; i < word.length(); i++) {
            if (_user_inp.charAt(0) == word.charAt(i)) {
                return true; 
            }
        }

        return  false;
    }

    public static String replaceChar(String word, String user_word, String _user_inp) {

        String _temp = "";

        for (int i = 0; i < user_word.length(); i++) {
            if (_user_inp.charAt(0) == word.charAt(i)) {
                _temp += String.valueOf(word.charAt(i));
                continue;
            }
            _temp += String.valueOf(user_word.charAt(i));
        }

        return _temp;
    }
}