package com.tp.diceroller.services;

import java.util.Random;

public class RNG {

    static Random RNG = new Random();

    public static int rollDice(int numOfSides){
        return RNG.nextInt(numOfSides) + 1;
    }

}
