package com.tp.rpg.armors;

public class BlackIronSet implements Armor{

    private String armorName;

    public BlackIronSet()
    {
        this.armorName = "Black Iron Set";
    }

    @Override
    public String getName()
    {
        return this.armorName;
    }

    @Override
    public int getArmorNum()
    {
        return 150;
    }

    @Override
    public int reduceDamage(int startingDamage)
    {
        startingDamage = -30;
        return startingDamage;
    }

    @Override
    public int getWeight()
    {
        return 12;
    }


    @Override
    public int optionNumber()
    {
        return 1;
    }



}
