import java.util.List;
import java.util.Objects;

public class BankAccount {
    public static final List<String> BACK_ACCOUNT_TYPES = List.of(
        "SAVINGS", "CHECKING", "CREDIT");

    private String id, owner, type;
    private double balance;

    public BankAccount(String id, String owner, double balance) {
        if (balance < 0) {
            throw new IllegalArgumentException("Account balance cannot be negative");
        }

        this.setId(id);
        this.setOwner(owner);
        this.balance = balance;

        this.setType(1);
    }

    public BankAccount(String id, String owner, double balance, int type) {
        this(id, owner, balance);

        this.setType(type);
    }

    public String getId() {
        return id;
    }

    public String getOwner() {
        return owner;
    }

    public String getType() {
        return type;
    }

    public double getBalance() {
        return balance;
    }

    public void setId(String id) {
        if (id.isEmpty() || id.isBlank()) {
            throw new IllegalArgumentException("Account id cannot be blank or null");
        }

        this.id = id;
    }

    public void setOwner(String owner) {
        if (owner.isEmpty() || owner.isBlank()) {
            throw new IllegalArgumentException("Account owner cannot be blank or null");
        }

        this.owner = owner;
    }

    public void setType(int idType) {
        if (idType < 0 || idType >= BACK_ACCOUNT_TYPES.size()) {
            throw new IllegalArgumentException("No such bank account type.");
        }

        this.type = BACK_ACCOUNT_TYPES.get(idType);
    }

    public void deposit(double amount) {
        if (amount <= 0) {
            throw new IllegalArgumentException("Deposit value must be positive.");
        }

        this.balance += amount;
    }

    public void withdraw(double amount) {
        if (amount <= 0) {
            throw new IllegalArgumentException("Withdraw value must be positive.");
        }
        if (amount > this.balance) {
            throw new IllegalArgumentException("The transaction was declined due to insufficient funds.");
        }

        this.balance -= amount;
    }

    public void transfer(BankAccount target, double amount) {
        if (target == null || target == this) {
            throw new IllegalArgumentException("Invalid target for transfer.");
        }

        this.withdraw(amount);
        target.deposit(amount);
    }

    public boolean isPositive() {
        return this.balance >= 0;
    }

    @Override 
    public String toString() {
        return "Account " + getId() + " (" + getOwner() + ", " + getType() + "): " + getBalance();
    }

    @Override 
    public boolean equals(Object o) {
        if (this == o) {
            return  true;
        }

        if (o == null || getClass() != o.getClass()) {
            return false;
        }

        BankAccount account = (BankAccount) o;

        return Objects.equals(id, account.id) && 
               Objects.equals(owner, account.owner) && 
               Objects.equals(type, account.type) && 
               balance == account.balance; 
    }

    @Override 
    public int hashCode() {
        return  Objects.hash(id, owner, balance, type);
    }
}
