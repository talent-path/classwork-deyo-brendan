package com.tp.rpg.weapons;

public class BroadSword implements Weapon{

    private String weaponName;
    private int generateDamage;
    private int movement;

    public BroadSword()
    {
        this.weaponName = "Broad Sword";
        this.generateDamage = 15;
        this.movement = 10;
    }

    @Override
    public int generateDamage()
    {
        return this.generateDamage;
    }

    @Override
    public int movement()
    {
        return this.movement;
    }

    @Override
    public String getName()
    {
        return this.weaponName;

    }
}
