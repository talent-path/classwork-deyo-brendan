package com.tp.rpg.weapons;

public class StoneGreatsword implements Weapon{

    private String weaponName;
    private int generateDamage;
    private int movement;

    public StoneGreatsword()
    {
        this.weaponName = "Stone Greatsword";
        this.generateDamage = 20;
        this.movement = 5;
    }

    @Override
    public int movement()
    {
        return this.movement;
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
