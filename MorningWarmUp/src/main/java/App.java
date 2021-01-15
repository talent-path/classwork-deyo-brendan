import java.util.*;

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

        // fizzBuzz();

//        System.out.println(canBalance(new int[]{2, 8, 5, 5}));
//        System.out.println(canBalance(new int[]{1, 2, 3, 4, 4, 3, 2, 1}));
//        System.out.println(canBalance(new int[]{2, 8, 1, 5, 5}));

        System.out.println(noTriples(new int[]{1, 2, 2, 2, 3, 4, 5, 6})); // false
        System.out.println(noTriples(new int[]{1, 2, 3, 4})); // true
        System.out.println(noTriples(new int[]{1 , 2, 100, 100, 100, 4, 5, 6, 7})); // false
        System.out.println(noTriples(new int[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 10})); // true





    }

    public static int middleOfThree(int a, int b, int c) // WORKS
    {
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

    public static int maxNum(int a, int b, int c) // WORKS!!
    {
        int max = Math.max(a, b);

        if (max > c)
        {

        }
        else
            max = c;

        return max;
    }

    public static void fizzBuzz() // WORKS :D
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

    public static boolean canBalance(int[] arr) // WORKS (^.^)
    {

        int sum = 0;
        int balance = 0;

        for (int i = 0; i < arr.length; i++)
        {
            sum += arr[i];
        }

        if (sum % 2 != 0)
            return false;
        else
            sum /= 2;

        for (int j = 0; j < arr.length; j++)
        {
            balance += arr[j];
            if (balance == sum)
            {
                return true;
            }
        }

        return false;

    }

    public static boolean noTriples(int[] arr) // DOESNT WORK >:(
    {
        if (arr.length < 3)
            return true;

        for (int i = 0; i < arr.length; i++)
        {
            for (int j = 1; j < arr.length; j++)
            {
                if (arr[i] != arr[j])
                {
                    break;
                }
                else if (arr[i] == arr[j])
                {
                    for (int k = 2; k < arr.length; k++)
                    {
                        if (arr[i] != arr[k])
                            break;
                        else if (arr[i] == arr[k])
                        {
                            return false;
                        }

                    }
                }
            }
        }
        return true;
    }


}
