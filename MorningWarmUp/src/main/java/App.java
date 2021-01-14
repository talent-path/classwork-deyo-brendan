import java.sql.SQLOutput;

public class App {

    public static void main(String[] args) {

        /* System.out.println(middleOfThree(1, 2, 3));
        System.out.println(middleOfThree(1, 3, 2));
        System.out.println(middleOfThree(2, 1, 3));
        System.out.println(middleOfThree(2, 3, 1));
        System.out.println(middleOfThree(3, 1, 2));
        System.out.println(middleOfThree(3, 2, 1));
        System.out.println(middleOfThree(2, 2, 3));
        System.out.println(middleOfThree(1, 1, 2));
        System.out.println(maxNum(1, 2, 3));
        System.out.println(maxNum(2, 2, 3));
        System.out.println(maxNum(1, 1, 3));
        System.out.println(maxNum(3, 2, 3));
        System.out.println(maxNum(1, 2, 2)); */

        fizzBuzz();


    }

    public static int middleOfThree(int a, int b, int c) {
        int temp = a;

        if (a > c && a < b)
            temp = a;
        else if (a < c && a < b) {
            temp = c;
            if (temp > b) {
                temp = b;
            }
        }
        else if (a > c && a > b) {
            temp = c;
            if (temp > b && temp < a)
                temp = c;
            else
                temp = b;
        }

        return temp;

    }

    public static int maxNum(int a, int b, int c)
    {
        int max = Math.max(a, b);

        if (max > c)
        {

        }
        else
            max = c;

        return max;
    }

    public static void fizzBuzz()
    {
        for (int i = 1; i < 100; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
                System.out.println("FIZZBUZZ");
            else if (i % 3 == 0)
                System.out.println("FIZZ");
            else if (i % 5 == 0)
                System.out.println("BUZZ");
            else
                System.out.println(i);
        }
    }


}
