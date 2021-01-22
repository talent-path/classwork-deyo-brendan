package com.tp.rpg;

import com.tp.rpg.armors.Armor;
import com.tp.rpg.armors.BlackIronSet;
import com.tp.rpg.weapons.BroadSword;
import com.tp.rpg.weapons.Weapon;

public class KnightArtorias extends PlayerCharacter{

    private Armor armorSet;
    private Weapon weaponChoice;
    private String playerName;

    // constructor

    public KnightArtorias()
    {
        super();
        this.armorSet = new BlackIronSet();
        this.weaponChoice = new BroadSword();
        playerName = "Knight Artorias";
    }

    @Override
    public String makeChoice() {
        return "attack";
    }

//    public String getArmorName() {
//        return this.armorName;
//    }

//    public String getWeaponName()
//    {
//        return weaponChoice.getName();
//    }

    public String getPlayerName()
    {
        return this.playerName;
    }

}