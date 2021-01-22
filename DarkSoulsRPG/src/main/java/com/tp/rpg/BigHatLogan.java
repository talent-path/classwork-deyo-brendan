package com.tp.rpg;

import com.tp.rpg.armors.Armor;
import com.tp.rpg.armors.BlackIronSet;
import com.tp.rpg.weapons.DualDaggers;
import com.tp.rpg.weapons.Weapon;

public class BigHatLogan extends NonPlayerCharacter{

    private Armor armorSet;
    private Weapon weaponChoice;
    private String npcName;

    // constructor

    public BigHatLogan()
    {
        super();
        this.armorSet = new BlackIronSet();
        this.weaponChoice = new DualDaggers();
        this.npcName = "Big Hat Logan";
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

    public String getPlayerName() {
        return npcName;
    }

}

