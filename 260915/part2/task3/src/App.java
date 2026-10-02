import java.util.Scanner;

public class App {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int score = 0;

        System.out.println("Question 1");
        System.out.println("What is the capital of France?");
        System.out.println("1. Paris");
        System.out.println("2. London");
        System.out.println("3. Berlin");
        System.out.print("Your answer: ");
        int answer1 = sc.nextInt();
        if (answer1 == 1) {
            score++;
        }

        System.out.println("Question 2");
        System.out.println("What is 2 + 2?");
        System.out.println("1. 3");
        System.out.println("2. 4");
        System.out.println("3. 5");
        System.out.print("Your answer: ");
        int answer2 = sc.nextInt();
        if (answer2 == 2) {
            score++;
        }

        System.out.println("Question 3");
        System.out.println("What is the largest planet in the Solar System?");
        System.out.println("1. Earth");
        System.out.println("2. Mars");
        System.out.println("3. Jupiter");
        System.out.print("Your answer: ");
        int answer3 = sc.nextInt();
        if (answer3 == 3) {
            score++;
        }

        System.out.println("Question 4");
        System.out.println("What is the chemical formula of water?");
        System.out.println("1. H2O");
        System.out.println("2. CO2");
        System.out.println("3. O2");
        System.out.print("Your answer: ");
        int answer4 = sc.nextInt();
        if (answer4 == 1) {
            score++;
        }

        System.out.println("Question 5");
        System.out.println("How many days are there in a leap year?");
        System.out.println("1. 365");
        System.out.println("2. 366");
        System.out.println("3. 367");
        System.out.print("Your answer: ");
        int answer5 = sc.nextInt();
        if (answer5 == 2) {
            score++;
        }

        System.out.println("Question 6");
        System.out.println("What color is the sky on a clear day?");
        System.out.println("1. Green");
        System.out.println("2. Blue");
        System.out.println("3. Red");
        System.out.print("Your answer: ");
        int answer6 = sc.nextInt();
        if (answer6 == 2) {
            score++;
        }

        System.out.println("Question 7");
        System.out.println("What is the first month of the year?");
        System.out.println("1. January");
        System.out.println("2. February");
        System.out.println("3. March");
        System.out.print("Your answer: ");
        int answer7 = sc.nextInt();
        if (answer7 == 1) {
            score++;
        }

        System.out.println("Correct answers: " + score + " out of 7");

        if (score == 7) {
            System.out.println("Grade: Excellent");
        } else if (score >= 5) {
            System.out.println("Grade: Good");
        } else if (score >= 3) {
            System.out.println("Grade: Satisfactory");
        } else {
            System.out.println("Grade: Bad");
        }

        sc.close();
    }
}