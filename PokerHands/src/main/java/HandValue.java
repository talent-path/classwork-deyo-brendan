public enum HandValue {

    HIGHCARD(1),
    ONEPAIR(2),
    TWOPAIR(3),
    THREEOFAKIND(4),
    STRAIGHT(5),
    FLUSH(6),
    FULLHOUSE(7),
    FOUROFAKIND(8),
    STRAIGHTFLUSH(9),
    ROYALFLUSH(10);

    public int value = -1;

    HandValue( int value ){
        this.value = value;
    }

    public static HandValue returnValue(int arr)
    {
        if(arr == 1)
            return HIGHCARD;
        else if(arr == 2)
            return ONEPAIR;
        else if(arr == 3)
            return TWOPAIR;
        else if(arr == 4)
            return THREEOFAKIND;
        else if(arr == 5)
            return STRAIGHT;
        else if(arr == 6)
            return FLUSH;
        else if(arr == 7)
            return FULLHOUSE;
        else if(arr == 8)
            return FOUROFAKIND;
        else if(arr == 9)
            return STRAIGHTFLUSH;
        else if(arr == 10)
            return ROYALFLUSH;
        else
            return null;
    }
}
