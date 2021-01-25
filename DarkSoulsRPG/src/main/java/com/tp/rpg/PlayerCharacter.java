package com.tp.rpg;

import com.tp.rpg.armors.Armor;
import com.tp.rpg.weapons.Weapon;

public abstract class PlayerCharacter {
    //use scanner here to get something from the user

    private String playerName;
    private Armor armorSet;
    private Weapon weaponChoice;


    public PlayerCharacter(String name, Armor armor, Weapon weapon)
    {
        playerName = name;
        armorSet = armor;
        weaponChoice = weapon;
    }

    public String makeChoice() {
        throw new UnsupportedOperationException();
    }


    public String getPlayerName()
    {
        return this.playerName;
    }

    public Armor getArmorSet() {

        return this.armorSet;
    }

    public Weapon getWeaponChoice() {
        return this.weaponChoice;
    }


    public void attack( NonPlayerCharacter defender ){

        throw new UnsupportedOperationException();
    }

    public boolean isAlive(int hp){

        if (hp <= 0)
            return false;
        else
            return true;

    }


}