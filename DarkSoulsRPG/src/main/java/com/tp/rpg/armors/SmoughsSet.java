package com.tp.rpg.armors;

public class SmoughsSet implements Armor{
    @Override
    public String getName()
    {
        return "Smough's Set";
    }

    @Override
    public int getArmorNum()
    {
        return 100;
    }

    @Override
    public int reduceDamage(int startingDamage)
    {
        startingDamage = -20;
        return startingDamage;
    }

    @Override
    public int getWeight()
    {
        return 8;
    }

    @Override
    public int optionNumber()
    {
        return 3;
    }

}
