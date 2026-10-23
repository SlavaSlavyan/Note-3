import java.util.HashSet;
import java.util.Set;

public class App {
    public static void main(String[] args) throws Exception {
        Set<BankAccount> bank = new HashSet<>();

        bank.add(new BankAccount("A001", "Artem", 1500));
        bank.add(new BankAccount("A002", "Marat", 1200));
        bank.add(new BankAccount("A003", "Ivan", 1000));   
        bank.add(new BankAccount("A003", "Ivan", 1000)); 


        for (BankAccount item : bank) {
            System.out.println(item);
        }
    }
}
