package com.tp.rpg;

import com.tp.rpg.armors.Armor;
import com.tp.rpg.armors.ClothArmorSet;
import com.tp.rpg.weapons.DualDaggers;
import com.tp.rpg.weapons.StoneGreatsword;
import com.tp.rpg.weapons.Weapon;

public class Hawkwood extends PlayerCharacter{

//    private Armor armorSet;
//    private Weapon weaponChoice;
//    private String playerName;

    // constructor

    public Hawkwood()
    {
        super("Hawkwood", new ClothArmorSet(), new DualDaggers());
    }


//    public String getArmorName()
//    {
//        return armorSet.getName();
//    }
//
//    public String getWeaponName()
//    {
//        return weaponChoice.getName();
//    }
//
//    public String getPlayerName()
//    {
//        return this.playerName;
//    }

}