package com.tp.rpg;

import com.tp.rpg.armors.Armor;
import com.tp.rpg.armors.SmoughsSet;
import com.tp.rpg.weapons.StoneGreatsword;
import com.tp.rpg.weapons.Weapon;

public class SiegwardofCatarina extends PlayerCharacter{

//    private Armor armorSet;
//    private Weapon weaponChoice;
//    private String playerName;

    // constructor

    public SiegwardofCatarina()
    {
        super("Siegward of Catarina", new SmoughsSet(), new StoneGreatsword());
    }

    @Override
    public String makeChoice() {
        return "attack";
    }

//    public String getArmorName()
//    {ss
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