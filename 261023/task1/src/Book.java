import java.time.LocalDate;

public class Book {
    private String name, author;
    private int publishYear, pagesCount;

    public String getName() {
        return name;
    }

    public String getAuthor() {
        return author;
    }

    public int getPublishYear() {
        return publishYear;
    }

    public int getPagesCount() {
        return pagesCount;
    }

    public void setName(String initName) {
        if (initName.isEmpty() || initName.isBlank()) {
            throw new IllegalArgumentException("Book name cannot be blank or null.");
        }
        this.name = initName;
    }

    public void setAuthor(String initAuthor) {
        if (initAuthor.isEmpty() || initAuthor.isBlank()) {
            throw new IllegalArgumentException("Book author cannot be blank or null.");
        }
        this.author = initAuthor;
    }

    public void setPublishYear(int initPublishYear) {
        if (initPublishYear < 1000 || initPublishYear > LocalDate.now().getYear()) {
            throw new IllegalArgumentException("Book publish year cannot be lesser than 1000 or be from future.");
        }
        this.publishYear = initPublishYear;
    }

    public void setPagesCount(int initPagesCount) {
        if (initPagesCount < 0) {
            throw new IllegalArgumentException("Book pages count cannot be negative.");
        }
        this.pagesCount = initPagesCount;
    }

    public Book(String initName, String initAuthor, int initPublishYear, int initPagesCount) {
        this.setName(initName);
        this.setAuthor(initAuthor);
        this.setPublishYear(initPublishYear);
        this.setPagesCount(initPagesCount);
    }

    public Book(String initName, String initAuthor) {
        this.setName(initName);
        this.setAuthor(initAuthor);
        this.setPublishYear(LocalDate.now().getYear());
        this.setPagesCount(0);
    }

    @Override 
    public String toString() {
        return getName() + " - " + getAuthor() + " (" + getPublishYear() + "), " + getPagesCount() + " pages;";
    }

    public boolean isModern() {
        return getPublishYear() > 2000;
    }

    public boolean isShort() {
        return getPublishYear() < 200;
    }
}