package com.tp.rpg;

import com.tp.rpg.armors.Armor;
import com.tp.rpg.armors.SmoughsSet;
import com.tp.rpg.weapons.BroadSword;
import com.tp.rpg.weapons.Weapon;

public class KnightSolaire extends NonPlayerCharacter {

    // properties

    // constructor

    public KnightSolaire()
    {
        super("Knight Solaire", new SmoughsSet(), new BroadSword());
    }

    // methods

    @Override
    public String makeChoice() {
        return "attack";
    }


}
