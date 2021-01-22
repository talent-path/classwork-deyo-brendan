package com.tp.rpg;

import java.util.Random;

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

}