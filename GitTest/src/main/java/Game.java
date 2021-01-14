import java.util.InputMismatchException;
import java.util.Scanner;

public class Game {

    public static void main(String[] args) {

        Scanner scan = new Scanner(System.in);
        boolean isValid = true;


        System.out.println("You're in a Haunted House, there are 3 doors. ");
        System.out.println("Door 1: Written on the first door is the words, \"Very Scary\".");
        System.out.println("Door 2: Written on the second door is the words, \"Kinda Scary\".");
        System.out.println("Door 3: Written on the third door is the words, \"Not-so Scary\".");

        while (isValid == true) {

            try {
                System.out.println("Choose a door, which one will you choose?");
                int choice = scan.nextInt();
                if (choice == 1) {
                    System.out.println("There is a pool of sulfuric acid, but you see a path on the side of the wall,"
                            + "will you risk creeping on the side of the wall? (Y/N)");
                    isValid = false;
                }
                else if (choice == 2) {
                    System.out.println("The door opens... there is nothing there, just pure darkness. You reach to open"
                            + " the other doors but they are now locked. You are forced to walk alone into the dark.");
                    isValid = false;
                }
                else if (choice == 3) {
                    System.out.println("You open the door... there is a cute poodle. You reach down to pet the"
                            + "poodle. Everything is fine, until the poodle turns into an alligator-poodle hybrid monster" +
                            "and eats you!!! You are dead now.");
                    isValid = false;
                }
                else {
                    throw new InputMismatchException("Please enter a valid integer for choosing door.");
                }
            } catch (InputMismatchException e) {
                scan = new Scanner(System.in);
                System.out.println("Please input a valid choice (1, 2, or 3)");
            }
        }
    }
}
