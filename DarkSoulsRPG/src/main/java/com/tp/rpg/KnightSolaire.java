package com.tp.rpg;

import com.tp.rpg.armors.Armor;
import com.tp.rpg.armors.SmoughsSet;
import com.tp.rpg.weapons.BroadSword;
import com.tp.rpg.weapons.Weapon;

public class KnightSolaire extends NonPlayerCharacter {

    // properties

    private Armor armorSet;
    private Weapon weaponChoice;
    private String npcName;

    // constructor

    public KnightSolaire()
    {
        super();
        this.armorSet = new SmoughsSet();
        this.weaponChoice = new BroadSword();
        this.npcName = "Knight Solaire";
    }

    // methods

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
        return this.npcName;
    }

}
