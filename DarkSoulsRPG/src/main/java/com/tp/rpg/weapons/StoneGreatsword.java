package com.tp.rpg.weapons;

public class StoneGreatsword implements Weapon{

    @Override
    public String getName()
    {
        return "Stone Greatsword";
    }

    @Override
    public int getAttackSpeed()
    {
        return 33;
    }

    @Override
    public int generateDamage()
    {
        return 100;
    }

    @Override
    public int getDurability()
    {
        return 20;
    }

    @Override
    public int optionNumber()
    {
        return 3;
    }

}
