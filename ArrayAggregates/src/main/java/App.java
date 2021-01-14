public class App {

    public static void main(String[] args) {

        /* int[] arr = {82, 95, 71, 6, 34};

        int min = Aggregate.min(arr);
        int max = Aggregate.max(arr);
        int sum = Aggregate.sum(arr);
        double avg = Aggregate.avg(arr);
        double stdDev = Aggregate.stdDev(arr);

        System.out.println("Min: " + min);
        System.out.println("Max: " + max);
        System.out.println("Sum: " + sum);
        System.out.println("Avg: " + avg);
        System.out.println("stdDev: " + stdDev); */

        final int ROCK = 1;
        final int PAPER = 2;
        final int SCISSORS = 3;

        System.out.println("1 - ROCK | 2 - PAPER | 3 - SCISSORS");

        int player = RNG.getUserChoice();
        int comp = RNG.getComputerChoice();

        RNG.isWinner(player, comp);




    }

}
