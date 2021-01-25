package com.tp.rpg.weapons;

public class BroadSword implements Weapon{

    private String weaponName;
    private int generateDamage;

    public BroadSword()
    {
        this.weaponName = "Broad Sword";
        this.generateDamage = 15;
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
