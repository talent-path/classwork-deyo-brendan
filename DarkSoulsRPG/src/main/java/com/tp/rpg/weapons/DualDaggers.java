package com.tp.rpg.weapons;

public class DualDaggers implements Weapon{

    private String weaponName;
    private int generateDamage;

    public DualDaggers()
    {
        this.weaponName = "Dual Daggers";
        this.generateDamage = 10;
    }

    @Override
    public int generateDamage()
    {
        return this.generateDamage;
    }

    @Override
    public String getName()
    {
        return this.weaponName;

    }
}
