import java.util.ArrayList;
import java.util.List;

public class Combinations {

    public static void sevenChooseFive(
            Card[] possible,
            int nextIndex,
            List<Card> currentlySelected,
            List<PokerHand> allCombinations){

        int chosenNum = currentlySelected.size();
        int remainingNum = 5 - chosenNum;

        int availableCards = possible.length - nextIndex;


        //base cases
        if( currentlySelected.size() == 5 ){
            List<Card> copy = new ArrayList<>();
            int count = 0;
            for( Card toCopy : currentlySelected )
            {
                copy.add(toCopy);
                count++;
            }

            PokerHand copyHand = new PokerHand(copy.toArray(new Card[0]));

            allCombinations.add( copyHand );
            return;
        }

        //if( nextIndex >= possible.length ) return;

        if( availableCards < remainingNum )
            return;

        //iterate through each card
        //for each card, we either include or don't
        //we'll try the recursion with the card included and with
        //the card excluded


        //try with the "card" first
        currentlySelected.add( possible[nextIndex] );
        sevenChooseFive( possible, nextIndex +1, currentlySelected, allCombinations);

       currentlySelected.remove( currentlySelected.size() - 1 );

        //try without choosing the card
        sevenChooseFive( possible, nextIndex + 1, currentlySelected, allCombinations);

    }
}