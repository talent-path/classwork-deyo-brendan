import com.sun.jdi.Value;

import java.util.HashMap;
import java.util.Map;

public class PokerHand {
    //field variables
    //we'll "compose" a poker hand from multiple sub-objects that we pull into a collection
    private Card[] cards;
    int value = 0;
    int max = 0;

    public Map<FaceValue, Integer> valueCounts;
    public Map<Suit, Integer> suitCounts;
    public Map<FaceValue, Integer> handValue;

    //need a constructor to make sure every hand is built with all the cards needed

    public PokerHand()
    {


    }

    public PokerHand(Card[] cards) {
        //for now we'll cross our fingers and hope its always 5
//        if( cards.length < 5 ){
//            //TODO: create a specific exception for this
//            throw new Exception("Invalid number of cards.");
//        }


        this.cards = cards;
        this.valueCounts = countFaceValues();
        this.suitCounts = countSuits();

        sortCards();
    }

    private void sortCards() {

        //bubble sort
        boolean sorted = false;

        while (!sorted) {

            sorted = true;
            for (int i = 0; i < cards.length - 1; i++) {
                //does the element at i need to be flipped with the element at i + 1?
                if ((cards[i].getCardValue().value < cards[i + 1].getCardValue().value) ||

                        (cards[i].getCardValue().value == cards[i + 1].getCardValue().value
                                && cards[i].getCardSuit().value < cards[i + 1].getCardSuit().value
                        )
                ) {
                    //we need to swap elements at i and i + 1
                    //it also means we found elements out of order
                    sorted = false;
                    Card temp = cards[i + 1];
                    cards[i + 1] = cards[i];
                    cards[i] = temp;
                }
            }

        }

    }

    public Card[] getCards() {
        return cards;
    }

    public Map<FaceValue, Integer> countFaceValues() {

        Map<FaceValue, Integer> count = new HashMap<>();

        for (Card toCount : cards) {
            if (!count.containsKey(toCount.getCardValue())) {
                count.put(toCount.getCardValue(), 0);
            }

            Integer currentCount = count.get(toCount.getCardValue());

            count.put(toCount.getCardValue(),
                    1 + currentCount);

        }

        return count;
    }

    public Map<Suit, Integer> countSuits() {

        Map<Suit, Integer> count = new HashMap<>();

        for (Card toCount : cards) {
            if (!count.containsKey(toCount.getCardSuit())) {
                count.put(toCount.getCardSuit(), 0);
            }

            Integer currentCount = count.get(toCount.getCardSuit());

            count.put(toCount.getCardSuit(),
                    1 + currentCount);

        }

        return count;
    }


    public FaceValue isRoyalFlush() {

        boolean isFlush = false;
        int counter = 0;
        FaceValue max = FaceValue.TWO;
        FaceValue temp = null;

        for (Suit key : suitCounts.keySet()) {
            if (suitCounts.get(key) == 5) {
                isFlush = true;
            }
        }

        for (FaceValue key : valueCounts.keySet()) {
            if (key.value > max.value) {
                max = key;
            }
            if (temp != null && key.value == temp.value - 1)
                counter++;
        }

        if (counter == 4 && isFlush && max.value == FaceValue.ACE.value) {
            this.value = 10;
            return max;
        }

        return null;
    }

    public FaceValue isStraightFlush() {

        if (isRoyalFlush() != null) {
            return isRoyalFlush();
        }

        boolean isFlush = false;
        boolean isStraight = false;
        int counter = 0;
        FaceValue temp = null;

        FaceValue max = FaceValue.TWO;

        for (Suit key : suitCounts.keySet()) {
            if (suitCounts.get(key) == 5) {
                isFlush = true;
            }
        }

        for (int i = 4; i > 0; i--)
        {
            if(cards[i].getCardValue().value == cards[i - 1].getCardValue().value - 1)
            {
                counter++;
            }
        }

        if (counter == 4) {
            isStraight = true;
        }

        if (isFlush && isStraight) {
            this.value = 9;
            return max;
        }

        return null;
    }

    //if not 4 of a kind, return null
    public FaceValue fourOfAKindValue() {

        FaceValue max = FaceValue.TWO;

        if (isStraightFlush() != null) {
            return isStraightFlush();
        }

        for (FaceValue key : valueCounts.keySet()) {
            if (valueCounts.get(key) == 4) {
                this.value = 8;
                return key;
            }
        }
        return null;
    }

    public FaceValue isFullHouse() {

        if (fourOfAKindValue() != null) {
            return fourOfAKindValue();
        }

        int threeCounter = 0;
        int pairCounter = 0;
        FaceValue max = FaceValue.TWO;

        for (FaceValue key : valueCounts.keySet()) {
            if (key.value > max.value) {
                max = key;
            }
            if (valueCounts.get(key) == 3) {
                threeCounter = 1;
            }
            if (valueCounts.get(key) == 2) {
                pairCounter = 1;
            }
        }

        if (threeCounter == 1 && pairCounter == 1) {
            this.value = 7;
            return max;
        }

        return null;
    }

    public FaceValue isFlush() {

        if (isFullHouse() != null) {
            return isFullHouse();
        }

        FaceValue max = FaceValue.TWO;

        for (Suit key : suitCounts.keySet()) {
            if (suitCounts.get(key) == 5) {
                for (FaceValue faceKey : valueCounts.keySet()) {
                    max = faceKey;
                    if (key.value > max.value) {
                        max = faceKey;
                    }
                }
                this.value = 6;
                return max;
            }
        }

        return null;
    }

    //if no straight, return a null
    public FaceValue straightHighCardValue() {
        int counter = 0;
        FaceValue temp = null;
        FaceValue max = FaceValue.TWO;
        int previous = -1;


        if (isFlush() != null) {
            return isFlush();
        }


        for (int i = 4; i > 0; i--)
        {
            if(cards[i].getCardValue().value == cards[i - 1].getCardValue().value - 1)
            {
                counter++;
            }
        }

//        for (FaceValue key : valueCounts.keySet()) {
//            if (key.value > max.value) {
//                max = key;
//            }
//            if (temp != null && key.value == temp.value - 1) {
//                counter++;
//            }
//            temp = key;
//        }

        if (counter == 4) {
            this.value = 5;
            return max;
        }

        return null;

    }

    //should return null if there are really 4
    public FaceValue threeOfAKindValue() {
        int threeOfAKind = 0;
        FaceValue temp = null;
        int onePair = 0;

        FaceValue max = FaceValue.TWO;

        if (straightHighCardValue() != null) {
            return straightHighCardValue();

        }

        for (FaceValue key : valueCounts.keySet()) {
            if (valueCounts.get(key) == 3) {
                this.value = 4;
                return key;
            }
        }

        return null;
    }

    //should return null if there are really 3 (or more of the same card)
    public FaceValue twoPair() {

        FaceValue max = FaceValue.TWO;

        if (threeOfAKindValue() != null) {
            return threeOfAKindValue();
        }

        FaceValue temp = null;
        int pairCounter = 0;

        for (int i = 3; i > 0; i--) {
            if (cards[i].getCardValue() == cards[i + 1].getCardValue() && cards[i].getCardValue() != cards[i - 1].getCardValue()
                    || cards[i].getCardValue() == cards[i - 1].getCardValue() && cards[i].getCardValue() != cards[i + 1].getCardValue()) {
                if (pairCounter == 1) {
                    this.value = 3;
                    this.max = cards[0].getCardValue().value;
                    return temp;
                }
                pairCounter++;
                temp = cards[i].getCardValue();
            }
        }

        return null;
    }

    //should return null when there is only one pair
    public FaceValue onePair() {

        FaceValue max = FaceValue.TWO;

        if (twoPair() != null) {
            return twoPair();
        }
        for (FaceValue key : valueCounts.keySet()) {
            if (key.value > max.value) {
                max = key;
            }
            if (valueCounts.get(key) == 2) {
                this.value = 2;
                this.max = max.value;
                return key;
            }
        }

        return null;
    }

    public FaceValue highCard() {
        if (onePair() != null) {
            return onePair();
        }
        FaceValue max = FaceValue.TWO;

        for (FaceValue key : valueCounts.keySet()) {
            if (key.value > max.value) {
                max = key;
            }
        }

        this.value = 1;
        this.max = max.value;
        return max;
    }


    public int[] evaluateHand()
    {
        int[] arr = new int[2];

        this.highCard();

        arr[0] = this.value;
        arr[1] = cards[0].getCardValue().value;

        return arr;
    }

    //return 0 if "this" ties with "that"
    //return negative number if "this" wins over "that"
    //return positive number if "this" loses to "that"
    public int compareTo(PokerHand that) {

        this.highCard();
        that.highCard();
        System.out.println(this.value);
        System.out.println(that.value);
        if (this.value == that.value) {
            return this.highCard().value - that.highCard().value;
        } else if (this.value < that.value) {
            return -1;
        } else {
            return 1;
        }

    }

    //in general compareTo() sematics are
    // - means "this before that"
    // 0 means "they're equal"
    // + means "that before this"


    public int getValue() {
        return value;
    }

    public void setValue(int value) {
        this.value = value;
    }

    public Map<FaceValue, Integer> getValueCounts() {
        return valueCounts;
    }

    public void setValueCounts(Map<FaceValue, Integer> valueCounts) {
        this.valueCounts = valueCounts;
    }

    public Map<Suit, Integer> getSuitCounts() {
        return suitCounts;
    }

    public void setSuitCounts(Map<Suit, Integer> suitCounts) {
        this.suitCounts = suitCounts;
    }


}