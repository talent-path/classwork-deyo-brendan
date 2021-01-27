package com.tp.rpg;

import com.tp.rpg.armors.Armor;
import com.tp.rpg.weapons.Weapon;

public abstract class PlayerCharacter {
    //use scanner here to get something from the user

    private String playerName;
    private Armor armorSet;
    private Weapon weaponChoice;
    private int getMovement;


    public PlayerCharacter(String name, Armor armor, Weapon weapon)
    {
        playerName = name;
        armorSet = armor;
        weaponChoice = weapon;
    }

    public String getPlayerName()
    {
        return this.playerName;
    }

    public Armor getArmorSet() {

        return this.armorSet;
    }

    public boolean isAlive(int num)
    {
        if (num <= 0)
            return false;
        else
            return true;
    }

    public Weapon getWeaponChoice() {
        return this.weaponChoice;
    }


}