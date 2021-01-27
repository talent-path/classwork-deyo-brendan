package com.tp.rpg.weapons;

public class DualDaggers implements Weapon{

    private String weaponName;
    private int generateDamage;
    private int movement;

    public DualDaggers()
    {
        this.weaponName = "Dual Daggers";
        this.generateDamage = 10;
        this.movement = 20;
    }

    @Override
    public int movement() {
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
