package com.tp.rpg.weapons;

public class BroadSword implements Weapon{

    private int swordDurability;
    private int swordSpeed;
    private int swordDamage;
    private String weaponName;

    public BroadSword()
    {
        this.swordDamage = 66;
        this.swordDurability = 15;
        this.swordSpeed = 66;
        this.weaponName = "Broad Sword";
    }

    @Override
    public String getName()
    {
        return this.weaponName;
    }

    @Override
    public int getAttackSpeed()
    {
        return swordSpeed;
    }

    @Override
    public int generateDamage()
    {
        return swordDamage;
    }

    @Override
    public int getDurability()
    {
        return 15;
    }

    @Override
    public int optionNumber()
    {
        return 1;
    }
}
