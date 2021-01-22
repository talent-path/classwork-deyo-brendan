package com.tp.rpg;

//TODO:
//      add a concept of hitpoints
//      add a concept of armor (or maybe multiple pieces of armor)
//      add a concept of a weapon (or maybe multiple weapons)
//Stretch goals:
//      add a potion class/interface that the character can drink instead of attacking
//      let the character "disarm" the opponent instead of attacking
//          base this on the weapons used?
//      let the character choose to "block" or "defend"
//          could stun the opponent if they attack?
//          could give us TWO attacks on the next round?
public abstract class Character {

    //TODO: add fields for armor(s) and weapon(s)

    public void attack( Character defender ){

        throw new UnsupportedOperationException();
    }

    public void takeDamage( int damage ){

        throw new UnsupportedOperationException();
    }

    public boolean isAlive(){

        throw new UnsupportedOperationException();
    }

    public String makeChoice() {

        throw new UnsupportedOperationException();
    }


}