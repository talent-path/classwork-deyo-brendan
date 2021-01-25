package com.tp.rpg.armors;

public class BlackIronSet implements Armor{

    private String armorName;
    private int damageReduction;
    private int baseArmor;
    private int movementSpeed;

    public BlackIronSet()
    {
        this.armorName = "Black Iron Set";
        this.damageReduction = -30;
        this.baseArmor = 150;
        this.movementSpeed = 3;
    }

    @Override
    public int damageReduction(int startingDamage) {
        startingDamage = startingDamage + this.damageReduction;
        return startingDamage;
    }

    @Override
    public int baseArmor() {
        return 150;
    }

    @Override
    public String getName()
    {
        return this.armorName;
    }

    @Override
    public int movementSpeed() {
        return 3;
    }






}
