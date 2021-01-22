package com.tp.rpg.weapons;

public class DualDaggers implements Weapon{

    @Override
    public String getName()
    {
        return "Dual Daggers";
    }

    @Override
    public int getAttackSpeed()
    {
        return 100;
    }

    @Override
    public int generateDamage()
    {
        return 33;
    }

    @Override
    public int getDurability()
    {
        return 10;
    }

    @Override
    public int optionNumber()
    {
        return 2;
    }

}
