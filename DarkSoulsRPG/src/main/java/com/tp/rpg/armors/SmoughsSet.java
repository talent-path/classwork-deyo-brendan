package com.tp.rpg.armors;

public class SmoughsSet implements Armor{

    private String armorName;
    private int damageReduction;
    private int baseArmor;
    private int movementSpeed;

    public SmoughsSet()
    {
        this.armorName = "Smough's Set";
        this.damageReduction = -20;
        this.baseArmor = 100;
        this.movementSpeed = 6;
    }

    @Override
    public int damageReduction(int startingDamage) {
        startingDamage = startingDamage + this.damageReduction;
        return startingDamage;
    }

    @Override
    public int baseArmor() {
        return this.baseArmor;
    }

    @Override
    public String getName()
    {
        return this.armorName;
    }

    @Override
    public int movementSpeed() {
        return this.movementSpeed;
    }


}
