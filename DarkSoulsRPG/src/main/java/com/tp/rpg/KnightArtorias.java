package com.tp.rpg;

import com.tp.rpg.armors.Armor;
import com.tp.rpg.armors.BlackIronSet;
import com.tp.rpg.weapons.BroadSword;
import com.tp.rpg.weapons.Weapon;

public class KnightArtorias extends PlayerCharacter{

//    private Armor armorSet;
//    private Weapon weaponChoice;
//    private String playerName;

    // constructor

    public KnightArtorias()
    {
        super("Knight Artorias", new BlackIronSet(), new BroadSword());
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


}