package com.tp.rpg;

import com.tp.rpg.armors.Armor;
import com.tp.rpg.armors.BlackIronSet;
import com.tp.rpg.weapons.DualDaggers;
import com.tp.rpg.weapons.Weapon;

public class BigHatLogan extends NonPlayerCharacter{

    // constructor

    public BigHatLogan()
    {
        super("Big Hat Logan", new BlackIronSet(), new DualDaggers());
    }

    @Override
    public String makeChoice() {
        return "attack";
    }


}

