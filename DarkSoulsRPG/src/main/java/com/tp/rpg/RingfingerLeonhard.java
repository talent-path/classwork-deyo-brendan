package com.tp.rpg;

import com.tp.rpg.armors.Armor;
import com.tp.rpg.armors.ClothArmorSet;
import com.tp.rpg.weapons.StoneGreatsword;
import com.tp.rpg.weapons.Weapon;

public class RingfingerLeonhard extends NonPlayerCharacter{


    // constructor

    public RingfingerLeonhard()
    {
        super("Ringfinger Leonhard", new ClothArmorSet(), new StoneGreatsword());

    }

    @Override
    public String makeChoice() {
        return "attack";
    }

    public int optionNumber()
    {
        return 3;
    }


}
