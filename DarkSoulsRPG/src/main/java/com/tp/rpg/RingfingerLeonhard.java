package com.tp.rpg;

import com.tp.rpg.armors.Armor;
import com.tp.rpg.armors.ClothArmorSet;
import com.tp.rpg.weapons.StoneGreatsword;
import com.tp.rpg.weapons.Weapon;

public class RingfingerLeonhard extends NonPlayerCharacter{

    private Armor armorSet;
    private Weapon weaponChoice;
    private String npcName;

    // constructor

    public RingfingerLeonhard()
    {
        super();
        this.armorSet = new ClothArmorSet();
        this.weaponChoice = new StoneGreatsword();
        this.npcName = "Ringfinger Leonhard";
    }

    @Override
    public String makeChoice() {
        return "attack";
    }

    public int optionNumber()
    {
        return 3;
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
