import java.util.Random;
import java.util.Scanner;


public class RNG {

    static Random RNG = new Random();

    public static int randInt(int incMin, int incMax) {
        int rand = incMin + RNG.nextInt((incMax - incMin) + 1);
        return rand;
    }

    public static double randDouble(double incMin, double incMax) {
        double rand = incMin + RNG.nextDouble() * (incMax - incMin);
        return rand;
    }

    public static boolean coinFlip() {
        return RNG.nextBoolean();
    }

    public static int getUserChoice(int choice) {

        if (choice == 1)
            System.out.println("Player chooses rock!");
        else if (choice == 2)
            System.out.println("Player chooses paper!");
        else if (choice == 3)
            System.out.println("Player chooses scissors!");

        return choice;

    }

    public static int getComputerChoice() {

        if (choice == 1)
            System.out.println("Computer chooses rock!");
        else if (choice == 2)
            System.out.println("Computer chooses paper!");
        else if (choice == 3)
            System.out.println("Computer chooses scissors!");

        return choice;
    }

    public static String isWinner(int player, int comp) {
        player = getUserChoice();
        comp = getComputerChoice();

        if (player == 1 && comp == 3) {
            theWinner = "PLAYER WINS";
        } else if (player == 2 && comp == 1) {
            theWinner = "PLAYER WINS";
        } else if (player == 3 && comp == 2) {
            theWinner = "PLAYER WINS";
        } else if (comp == 1 && player == 3) {
            theWinner = "COMPUTER WINS";
        } else if (player == 2 && comp == 1) {
            theWinner = "COMPUTER WINS";
        } else if (player == 3 && comp == 2) {
            theWinner = "COMPUTER WINS";
        } else if (player == comp) {
            theWinner = "DRAW";
        }

        return theWinner;
    }

}
