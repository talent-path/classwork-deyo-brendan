package com.tp.rpg;

import com.tp.rpg.armors.Armor;
import com.tp.rpg.armors.SmoughsSet;
import com.tp.rpg.weapons.StoneGreatsword;
import com.tp.rpg.weapons.Weapon;

public class SiegwardofCatarina extends PlayerCharacter{

    private Armor armorSet;
    private Weapon weaponChoice;
    private String playerName;

    // constructor

    public SiegwardofCatarina()
    {
        super();
        this.armorSet = new SmoughsSet();
        this.weaponChoice = new StoneGreatsword();
        this.playerName = "Siegward of Catarina";
    }

    @Override
    public String makeChoice() {
        return "attack";
    }

    public String getArmorName()
    {
        return armorSet.getName();
    }

    public String getWeaponName()
    {
        return weaponChoice.getName();
    }

    public String getPlayerName()
    {
        return this.playerName;
    }

}