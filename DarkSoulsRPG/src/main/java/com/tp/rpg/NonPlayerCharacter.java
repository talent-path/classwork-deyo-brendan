package com.tp.rpg;

import com.tp.rpg.armors.Armor;
import com.tp.rpg.weapons.Weapon;

public class NonPlayerCharacter {


    private String nonPlayerName;
    private Armor armorSet;
    private Weapon weaponChoice;

    public NonPlayerCharacter(String name, Armor armor, Weapon weapon) {

        nonPlayerName = name;
        armorSet = armor;
        weaponChoice = weapon;
    }

    public String makeChoice() {

        throw new UnsupportedOperationException();
    }

    public String getPlayerName() {
        return this.nonPlayerName;
    }

    public void attack(PlayerCharacter defender) {

        throw new UnsupportedOperationException();
    }

    public Armor getArmorSet() {

        return this.armorSet;
    }

    public Weapon getWeaponChoice() {
        return this.weaponChoice;
    }

    public boolean isAlive(int hp) {

        if (hp <= 0)
            return false;
        else
            return true;

    }

}