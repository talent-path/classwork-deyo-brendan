package com.tp.rpg;

public class Application {

    public static void main(String[] args) {

        PlayerCharacter pc = setUpPlayer();
        NonPlayerCharacter npc = setUpEnemy();

        System.out.println("Player chooses: " + pc.getPlayerName().toUpperCase());
        System.out.println("Armor Set : " + pc.getArmorSet() + " | " + "Weapon Choice: " + pc.getWeaponChoice());
        System.out.println();
        System.out.println("Computer chooses: " + npc.getPlayerName().toUpperCase());
        System.out.println("Armor Set : " + npc.getArmorSet() + " | " + "Weapon Choice: " + npc.getWeaponChoice());
        System.out.println();



//        while (pc.isAlive()) {
//
//            battle(pc, npc);
//
//
//        }
//
//        gameOverScreen();

    }

    //walk the user through setting up their character
    private static PlayerCharacter setUpPlayer()
    {
        PlayerCharacter knight = null;
        int optionNumber;

        System.out.println("(1) Knight Artorias | Armor: Black Iron Set | Weapon: Broadsword |");
        System.out.println("(2) Hawkwood | Armor: Cloth Armor Set | Weapon : Dual Daggers |");
        System.out.println("(3) Siegward of Catarina | Armor: Smough's Set | Weapon: Stone Greatsword |");
        optionNumber = Console.readInt("--- *** Choose your knight *** ---");
        System.out.println();

        if (optionNumber == 1)
        {
            knight = new KnightArtorias();
        }
        else if (optionNumber == 2)
        {
            knight = new Hawkwood();
        }
        else if (optionNumber == 3)
        {
            knight = new SiegwardofCatarina();
        }

//        System.out.println("(1) Black Iron Set");
//        System.out.println("(2) Smough's Set");
//        System.out.println("(3) Cloth Armor Set");
//        optionNumber = Console.readInt("--- *** Choose your armor *** ---");
//        System.out.println();
//
//        System.out.println("(1) Broadsword");
//        System.out.println("(2) Double Daggers");
//        System.out.println("(3) Stone Greatsword");
//        optionNumber = Console.readInt("--- *** Choose your weapon *** ---");
//        System.out.println();

        return knight;

    }

    //

    //create some NPC object (with armor & weapons?)
    private static NonPlayerCharacter setUpEnemy() {

        NonPlayerCharacter knight = null;

        int optionNumber = RNG.randInt(0, 2);
        if (optionNumber == 0)
        {
            knight = new BigHatLogan();
        }
        else if (optionNumber == 1)
        {
            knight = new KnightSolaire();
        }
        else if (optionNumber == 2)
        {
            knight = new RingfingerLeonhard();
        }

        return knight;
    }

    //a and b battle until one is dead
    private static void battle(PlayerCharacter a, NonPlayerCharacter b) {
        PlayerCharacter attacker = a;
        NonPlayerCharacter defender = b;

        while (a.isAlive() && b.isAlive()) {
            if (a.makeChoice().equals("Attack")) {
                attacker.attack(defender);
            } else {
                //TODO: consider other actions
                throw new UnsupportedOperationException();
            }

//            Character temp = a;
//            a = b;
//            b = temp;

            //TODO: display HP status?
        }
    }

    //display some message
    private static void gameOverScreen() {
    }
}