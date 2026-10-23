public class App {
    public static void main(String[] args) throws Exception {
        Book[] books = {
            new Book("Master margarita", "Bulgacov", 1967, 500),
            new Book("Dead souls", "Gogol"),
            new Book("Kapitan's daughter", "Pushkin")
        };

        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 40; j++) {
               System.out.print("="); 
            }

            System.out.print("\n" + books[i] + "\nIs modern >> ");

            if (books[i].isModern()) {
                System.out.println("YES");
            } else {
                System.out.println("NO");
            }

            System.out.print("Is short >> ");

            if (books[i].isShort()) {
                System.out.println("YES");
            } else {
                System.out.println("NO");
            }
        }

        try {
            Book test = new Book("", "");
            System.out.println(test);
        } catch (Exception e) {
            System.err.println("Error while putting null value: " + e.toString());
        }
    }
}
