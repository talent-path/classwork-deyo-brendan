package com.tp.rpg.armors;

public class ClothArmorSet implements Armor{

    @Override
    public String getName()
    {
        return "Cloth Armor Set";
    }

    @Override
    public int getArmorNum()
    {
        return 50;
    }

    @Override
    public int reduceDamage(int startingDamage)
    {
        startingDamage = -10;
        return startingDamage;
    }

    @Override
    public int getWeight()
    {
        return 4;
    }

    @Override
    public int optionNumber()
    {
        return 2;
    }
}
