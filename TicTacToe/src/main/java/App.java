import java.util.*;

public class App {

    private static Scanner scan = new Scanner(System.in);
    private static char emptyCell = '-';

    public static void main(String[] args) {

        char[][] board = new char[3][3];
        char playerSymbol = 'X';
        char compSymbol = 'O';
        int numOfGames;
        int playerWins = 0;
        int compWins = 0;
        int numDraws = 0;


        System.out.println("--- Tic Tac Toe! Player (X) vs Computer (O) --- ");
        System.out.println();

        System.out.print("How many games do you want to play?: ");
        numOfGames = scan.nextInt();
        System.out.println();

        while (numOfGames != 0) {
            createBoard(board);

            System.out.println();

            int cellCount = 9;
            int turnNum = Integer.MIN_VALUE;
            boolean isValid = false;

            while (!isValid) {
                try {
                    System.out.print("Will Player be moving first? (Y/N)");

                    char turnChoice = scan.next().toLowerCase().charAt(0);
                    System.out.println();

                    if (turnChoice == 'y') {
                        turnNum = 0;
                        playerMove(board, playerSymbol);
                        isValid = true;
                    } else if (turnChoice == 'n') {
                        turnNum = 1;
                        compMove(board, compSymbol);
                        isValid = true;
                    }
                } catch (InputMismatchException ex) {
                }
            }

            displayBoard(board);
            cellCount--;

            boolean isGameOver = false;

            while (!isGameOver && cellCount != 0) {
                isGameOver = declareWinner(board);

                if (isGameOver == true) {
                    if (turnNum == 0) {
                        System.out.println("PLAYER WINS!");
                        playerWins++;
                        break;
                    } else if (turnNum == 1) {
                        System.out.println("COMPUTER WINS!");
                        compWins++;
                        break;
                    }
                } else
                    turnNum = (turnNum + 1) % 2;

                if (turnNum == 0)
                    playerMove(board, playerSymbol);
                else
                    compMove(board, compSymbol);

                if (cellCount != 0) {
                    displayBoard(board);
                    cellCount--;

                } else if (cellCount == 0) {
                    System.out.println("DRAW");
                    numDraws++;
                    break;
                }

            }

            numOfGames--;

        }

        System.out.println();
        System.out.println("# of Player Wins: " + playerWins);
        System.out.println("# of Computer Wins: " + compWins);
        System.out.println("# of Draws: " + numDraws);

    }

    public static void createBoard(char[][] board) {
        for (int i = 0; i < board.length; i++) {
            for (int j = 0; j < board[i].length; j++) {
                board[i][j] = emptyCell;
                System.out.print(" " + board[i][j] + " ");
            }
            System.out.println();
        }

        // displayBoard(board);
    }

    public static void displayBoard(char[][] board) {
        System.out.println();
        System.out.println("CURRENT BOARD");
        System.out.println();

        for (int i = 0; i < board.length; i++) {
            for (int j = 0; j < board[0].length; j++) {
                System.out.print(" " + board[i][j] + " ");
            }
            System.out.println();
        }

    }


    public static void playerMove(char[][] board, char playerX) {

        System.out.println();

        int rowIndex = Integer.MIN_VALUE;
        int colIndex = Integer.MIN_VALUE;

        boolean isEmpty = false;

        while (!isEmpty) {
            rowIndex = Console.readInt("Enter the Row Index:", 0, 2);
            colIndex = Console.readInt("Enter the Column Index:", 0, 2);
            if (board[rowIndex][colIndex] == emptyCell) {
                isEmpty = true;
            }

        }

        board[rowIndex][colIndex] = playerX;

    }

    public static void compMove(char[][] board, char compO) {
        for (int i = 0; i < board.length; i++) {
            for (int j = 0; j < board[0].length; j++) {
                if (board[i][j] == emptyCell) {
                    board[i][j] = compO;
                    return;
                }
            }
        }
    }

    public static boolean declareWinner(char[][] board) {

        for (int i = 0; i < board.length; i++) {
            for (int j = 0; j < board[0].length; j++) {
                if (board[i][j] == emptyCell) {
                    return false;
                }
            }
        }

        return (board[0][0] == board[0][1] && board[0][0] == board[0][2]) ||
                (board[0][0] == board[1][1] && board[0][0] == board[2][2]) ||
                (board[0][0] == board[1][0] && board[0][0] == board[2][0]) ||
                (board[2][0] == board[2][1] && board[2][0] == board[2][2]) ||
                (board[2][0] == board[1][1] && board[0][0] == board[0][2]) ||
                (board[0][2] == board[1][2] && board[0][2] == board[2][2]) ||
                (board[0][1] == board[1][1] && board[0][1] == board[2][1]) ||
                (board[1][0] == board[1][1] && board[1][0] == board[1][2]);
    }

}
