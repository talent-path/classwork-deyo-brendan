package com.tp.rpg.weapons;

public class StoneGreatsword implements Weapon{

    private String weaponName;
    private int generateDamage;

    public StoneGreatsword()
    {
        this.weaponName = "Stone Greatsword";
        this.generateDamage = 20;
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
