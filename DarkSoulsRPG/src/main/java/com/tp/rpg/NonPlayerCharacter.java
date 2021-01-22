package com.tp.rpg;

public class NonPlayerCharacter {


    private String nonPlayerName;
    private String armorSet;
    private String weaponChoice;

    public NonPlayerCharacter() {

        super();

    }

    public String makeChoice() {

        throw new UnsupportedOperationException();
    }

    public String getPlayerName() {
        return this.nonPlayerName;
    }

    public String getArmorSet()
    {
        return this.armorSet;
    }

    public String getWeaponChoice() {
        return this.weaponChoice;
    }

    public void attack(PlayerCharacter defender) {

        throw new UnsupportedOperationException();
    }

    public boolean isAlive() {

        throw new UnsupportedOperationException();
    }

}