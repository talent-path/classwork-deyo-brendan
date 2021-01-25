package com.tp.rpg.armors;
public interface Armor {

    //takes in an amount of damage dealt
    //outputs the amount of damage to actually take
    int damageReduction( int startingDamage );

    int baseArmor();

    String getName();

    int movementSpeed();



}