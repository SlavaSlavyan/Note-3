import java.util.Scanner;

public class App 
{
    public static void main(String[] args) throws Exception 
    {
        boolean triangle = true;
        float[] edges = new float[3];
        Scanner scanner = new Scanner(System.in);

        for (int i = 0; i < 3; i++)
        {
            System.out.print("Triangle edge [" + (i + 1) + "] << ");
            edges[i] = Float.parseFloat(scanner.nextLine());
        }

        if (edges[0] > edges[1] + edges[2]) triangle = false;
        if (edges[1] > edges[0] + edges[2]) triangle = false;
        if (edges[2] > edges[1] + edges[0]) triangle = false;
        
        if (triangle)
        {
            int _count = 0;

            if (edges[0] == edges[1]) _count++;
            if (edges[1] == edges[2]) _count++;
            if (edges[2] == edges[0]) _count++;

            switch (_count) 
            {
                case 1 -> System.out.println("\nTriangle is isosceles.");
                case 3 -> System.out.println("\nTriangle is equilateral.");
                default -> System.out.println("\nTriangle is scalene.");
            }
        }
        else System.out.println("\nThis triangle cannot exist!");

        System.out.println("\nPress ENTER to exit...");
        scanner.nextLine();
        scanner.close();
    }
}