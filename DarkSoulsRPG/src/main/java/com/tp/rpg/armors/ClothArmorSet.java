package com.tp.rpg.armors;

public class ClothArmorSet implements Armor{

    private String armorName;
    private int damageReduction;
    private int baseArmor;
    private int movementSpeed;

    public ClothArmorSet()
    {
        this.armorName = "Cloth Armor Set";
        this.damageReduction = -10;
        this.baseArmor = 100;
        this.movementSpeed = 30;
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
