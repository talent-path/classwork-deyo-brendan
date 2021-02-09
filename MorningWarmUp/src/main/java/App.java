import com.sun.source.tree.Tree;

import javax.swing.tree.TreeNode;
import java.sql.SQLOutput;
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

//        System.out.println(noTriples(new int[]{1, 2, 2, 2, 3, 4, 5, 6})); // false
//        System.out.println(noTriples(new int[]{1, 2, 3, 4})); // true
//        System.out.println(noTriples(new int[]{1 , 2, 100, 100, 100, 4, 5, 6, 7})); // false
//        System.out.println(noTriples(new int[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 10})); // true

//        int[] arr1 = new int[100];
//        int[] arr2 = new int[100];
//
//        for (int i = 0; i < arr1.length; i++)
//        {
//            arr1[i] = RNG.randInt(0, 9);
//        }
//
//        for (int j = 0; j < arr2.length; j++)
//        {
//            arr2[j] = RNG.randInt(0, 9);
//        }
//
//        int[] sum = addBigNum(arr1, arr2);
//
//        System.out.println(sum);


//        int[] arr1 = {1, 2, 3, 8, 9, 3, 2, 1};
//        int[] arr2 = {1, 2, 1, 4};
//        int[] arr3 = {7, 1, 2, 9, 7, 2, 1};
//
//        System.out.println(maxMirror(arr1));
//        System.out.println(maxMirror(arr2));
//        System.out.println(maxMirror(arr3));

//        List<String> testList = new ArrayList<>();
//
//        testList.add("Bob");
//        testList.add("Bobby");
//        testList.add("Robert");
//        testList.add("Roberto");
//        testList.add("Alice");
//        testList.add("Alicia");
//
//        String[] allNames = testList.toArray(new String[0]);
//
//        Map<String, List<String>> testMap = new HashMap<>();
//
//        List<String> someList = new ArrayList<>();
//
//        testMap.put(" some string", someList);
//
//        for (int i = 0; i < someList.size(); i++)
//        {
//            System.out.println(someList.get(i));
//        }
//
//        Map<String, List<String>> groupedNames = groupByFirstTwoLetters(allNames);


//            longestChain();

//        System.out.println(digitReverse(1234));
//        System.out.println(digitReverse(0002));
//        System.out.println(digitReverse(-10245));

//        System.out.println(lengthOfLongestSubstring("abcabcbb"));

//        System.out.println(isPerfect(6));
//        System.out.println(isPerfect(28));
//        System.out.println(isPerfect(10));
//        System.out.println(isPerfect(99));
//        System.out.println(isPerfect(496));
//        System.out.println(isPerfect(8128));



//        char[][] board = {{'5','3','.','.','7','.','.','.','.'},
//                        {'6','.','.','1','9','5','.','.','.'},
//                        {'.','9','8','.','.','.','.','6','.'},
//                        {'8','.','.','.','6','.','.','.','3'},
//                        {'4','.','.','8','.','3','.','.','1'},
//                        {'7','.','.','.','2','.','.','.','6'},
//                        {'.','6','.','.','.','.','2','8','.'},
//                        {'.','.','.','4','1','9','.','.','5'},
//                        {'.','.','.','.','8','.','.','7','9'}};
//
//        solveSudoku(board);








    }





    public int search(int[] nums, int target) {

        int pivot = Integer.MIN_VALUE;
        int i = nums[0];
        int searchArr = nums[nums.length - 1];

        while (i <= searchArr)
        {
            pivot = i + (searchArr - i) / 2;
            if (nums[pivot] == target)
                return pivot;
            if (target < nums[pivot])
                searchArr = pivot - 1;
            else if (target > nums[pivot])
                i = pivot + 1;
        }
        return -1;




    }


    public int rangeSumBST(TreeNode root, int low, int high) {

        List<TreeNode> newTree = new ArrayList<TreeNode>();

        TreeNode node = new TreeNode() {
            @Override
            public TreeNode getChildAt(int childIndex) {
                return null;
            }

            @Override
            public int getChildCount() {
                return 0;
            }

            @Override
            public TreeNode getParent() {
                return null;
            }

            @Override
            public int getIndex(TreeNode node) {
                return 0;
            }

            @Override
            public boolean getAllowsChildren() {
                return false;
            }

            @Override
            public boolean isLeaf() {
                return false;
            }

            @Override
            public Enumeration<? extends TreeNode> children() {
                return null;
            }
        }

        int output = 0;

        newTree.add(root);

        if (root != null)
        {
            for (int i = 0; i < newTree.size(); i++)
            {
                newTree.remove(i);
                if (newTree != null)
                {
                    int value = newTree.indexOf(i);
                    if (low <= value && value <= high )
                    {
                        output += value;
                    }
                    if (low < value)
                    {
                        newTree.remove(root.left);
                    }
                    if (value < high)
                    {
                        newTree.add(root.right);
                    }
                }
            }
        }


    }

    public static void solveSudoku(char[][] board)
    {
        boolean isValid = false;

        while (!isValid)
        {
            for (int row = 0; row <  board.length; row++)
            {
                for (int col = 0; col < board.length; col++)
                {
                    if (board[row][col] == '.')
                    {
                        char[] index = {'1','2','3','4','5','6','7','8','9'};
                        for (int check = 0; check <= index.length; check++)
                        {
                            board[row][col] = index[check];
                            if (isValidSudoku(board, row, col))
                            {
                                isValid = true;
                            }
                            else
                                board[row][col] = '.';
                        }
                    }
                }
            }
        }

    }

    public static boolean isValidSudoku(char[][] board, int row, int col)
    {
        for (int i = 0; i < board.length; i++)
        {
            if ((i != row || i != '.') && board[i][col] == board[row][col])
                return false;
        }
        for (int j = 0; j < board.length; j++)
        {
            if((j != col || j != '.') && board[row][j] == board[row][col])
                return false;
        }
        for (int i = (row / 3) * 3; i < (i / 3) * 3 + 3; i++)
        {
            for (int j = (col / 3) * 3; i < (col / 3) * 3 + 3; j++)
            {
                if (((i != row || j != col) && board[i][j] != '.') &&
                        board[i][j] == board[row][col])
                    return false;
            }
        }

        return true;

    }

    public static boolean isPerfect(int num) {
        int sum = 0;

        boolean isPerfect;

        for (int i = 1; i < num; i++) {
            // check if perfectly divisible by i
            if (num % i == 0)
                sum += i;
        }

        if (sum == num)
            isPerfect = true;
        else
            isPerfect = false;

        return isPerfect;
    }

    public static int lengthOfLongestSubstring(String s) {

        char[] toArr = s.toCharArray();
        char[] newArr = new char[0];
        StringBuilder newStr = new StringBuilder();

        for (char check : toArr) {

            if (newStr.length() == 0) {
                newStr.append(check);
            }

            newArr = newStr.toString().toCharArray();

            for (int i = 0; i < newArr.length; i++) {

                if (newArr[i] == check) {
                    break;
                } else {
                    newStr.append(check);
                }
            }

        }

        return newStr.length();

    }

    public static int digitReverse(int num) {
        int reverseNum = 0;

        for (; Math.abs(num) > 0; num /= 10) {
            reverseNum = (num % 10) + (reverseNum * 10);
        }

        return reverseNum;

    }

    public static void longestChain() {
        int max = 1;
        int chainSize;
        int temp = Integer.MIN_VALUE;
        int startPoint = 2;

        while (startPoint < 1000000) {
            chainSize = collatzSequence(startPoint);
            if (chainSize > max) {
                max = chainSize;
                temp = startPoint;
            }
            startPoint++;
        }

        System.out.println("# which produces longest chain is: " + temp);
    }

    public static int collatzSequence(long num) {
        List<Long> newList = new ArrayList<>();
        int listSize;

        while (num > 1) {
            newList.add(num);

            if (num % 2 == 0)
                num /= 2;
            else if (num % 2 != 0)
                num = 3 * num + 1;
        }

        listSize = newList.size();
        return listSize;

    }


    //input: ["Bob", "Bobby", "Robert", "Roberto", "Alice", "Alicia" ]
    //output:
    //      Map with 3 keys:
    //      "Bo"    -> List: {"Bob", "Bobby"}
    //      "Ro"    ->  List: { "Robert", "Roberto" }
    //      "Al"    ->  List: { "Alice", "Alicia" }

    public static Map<String, List<String>> groupByFirstTwoLetters(String[] toGroup) {
        String twoRootLetters;

        Map<String, List<String>> newMap = new HashMap<>();
        List<String> newList = new ArrayList<>();

        for (int i = 0; i < toGroup.length; i++) {

            twoRootLetters = toGroup[i].substring(0, 2);

            System.out.print(twoRootLetters + ": ");

            if (toGroup[i].startsWith(twoRootLetters)) {
                newList.add(toGroup[i]);
                newMap.put(toGroup[i], newList);
                System.out.println(newList);
            }
        }

        return newMap;

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
        } else if (a > c && a > b) {
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

        if (max > c) {

        } else
            max = c;

        return max;
    }

    public static void fizzBuzz() // WORKS :D
    {
        for (int i = 1; i < 100; i++) {
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

        for (int i = 0; i < arr.length; i++) {
            sum += arr[i];
        }

        if (sum % 2 != 0)
            return false;
        else
            sum /= 2;

        for (int j = 0; j < arr.length; j++) {
            balance += arr[j];
            if (balance == sum) {
                return true;
            }
        }

        return false;

    }

    public static boolean noTriples(int[] arr) // DOESNT WORK >:(
    {
        if (arr.length < 3)
            return true;

        for (int i = 0; i < arr.length; i++) {
            for (int j = 1; j < arr.length; j++) {
                if (arr[i] != arr[j]) {
                    break;
                } else if (arr[i] == arr[j]) {
                    for (int k = 2; k < arr.length; k++) {
                        if (arr[i] != arr[k])
                            break;
                        else if (arr[i] == arr[k]) {
                            return false;
                        }

                    }
                }
            }
        }
        return true;
    }

    //given two arrays of size 100 each representing a 100 digit number
    // (each element of the input array will have a value between 0 and 9)
    // return the 101 element "sum" of these two numbers
    // (in the output array, the digits should also be between 0 and 9)
    // the digit at index 0 is the one's place, index 1 is the 10's place and so on

    public static int[] addBigNum(int[] left, int[] right) // another failed attempt
    {
        StringBuilder sumArray1 = new StringBuilder();
        StringBuilder sumArray2 = new StringBuilder();

        for (int num1 : left) {
            sumArray1.append(num1);
        }

        for (int num2 : right) {
            sumArray2.append(num2);
        }

        int totalInt1 = Integer.parseInt(sumArray1.toString());
        int totalInt2 = Integer.parseInt(sumArray2.toString());

        String temp = Integer.toString(totalInt1 + totalInt2);

        int[] totalSumArray = new int[temp.length()];

        for (int k = 0; k < totalSumArray.length; k++) {
            totalSumArray[k] = temp.charAt(k) - '0';
        }

        return totalSumArray;

    }

    public static int maxMirror(int[] nums) {
        int num = Integer.MIN_VALUE;

        for (int i = 0; i < nums.length; i++) {
            for (int j = nums.length - 1; j >= 0; j--) {

                int count = 0;

                while (i <= nums.length - 1 && j >= 0 && nums[i] == nums[j]) {
                    i++;
                    j--;
                    count++;
                }

                if (num <= count)
                    num = count;

            }
        }

        return num;

    }


}
