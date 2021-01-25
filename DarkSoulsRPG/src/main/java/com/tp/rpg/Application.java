package com.tp.rpg;

public class Application {

    public static void main(String[] args) {

        PlayerCharacter pc = setUpPlayer();
        NonPlayerCharacter npc = setUpEnemy();
        int winner = 0;

        System.out.println("Player chooses: " + pc.getPlayerName().toUpperCase());
        System.out.println("Armor Set : " + pc.getArmorSet().getName() + " | " + "Weapon Choice: "
                + pc.getWeaponChoice().getName());
        System.out.println();
        System.out.println("Computer chooses: " + npc.getPlayerName().toUpperCase());
        System.out.println("Armor Set : " + npc.getArmorSet().getName() + " | " + "Weapon Choice: "
                + npc.getWeaponChoice().getName());
        System.out.println();

        battle(pc, npc, winner);

        gameOverScreen(pc, npc, winner);

    }

    //walk the user through setting up their character
    private static PlayerCharacter setUpPlayer()
    {
        PlayerCharacter knight = null;
        int optionNumber;

        System.out.println("(1) Knight Artorias | Armor: Black Iron Set | Weapon: Broadsword |");
        System.out.println("(2) Hawkwood | Armor: Cloth Armor Set | Weapon : Dual Daggers |");
        System.out.println("(3) Siegward of Catarina | Armor: Smough's Set | Weapon: Stone Greatsword |");
        optionNumber = Console.readInt("--- *** Choose your knight *** --- : ");
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
    private static void battle(PlayerCharacter a, NonPlayerCharacter b, int winner) {
        PlayerCharacter attacker = a;
        NonPlayerCharacter defender = b;

        int playerHP = attacker.getArmorSet().baseArmor();
        int computerHP = defender.getArmorSet().baseArmor();

        while (a.isAlive(playerHP) && b.isAlive(computerHP)) {
//
            if(a.getArmorSet().movementSpeed() > b.getArmorSet().movementSpeed())
            {
                computerHP -= attacker.getWeaponChoice().generateDamage();
                if (a.getArmorSet().movementSpeed() / 3 == b.getArmorSet().movementSpeed())
                {
                    computerHP -= attacker.getWeaponChoice().generateDamage();
                }
                playerHP -= defender.getWeaponChoice().generateDamage();
            }
            else if (b.getArmorSet().movementSpeed() > a.getArmorSet().movementSpeed())
            {
                playerHP -= defender.getWeaponChoice().generateDamage();
                if (b.getArmorSet().movementSpeed() / 3 == a.getArmorSet().movementSpeed())
                {
                    playerHP -= defender.getWeaponChoice().generateDamage();
                }
                computerHP -= attacker.getWeaponChoice().generateDamage();
            }
//
            System.out.println(a.getPlayerName().toUpperCase() + " HP = " + playerHP);
            System.out.println(b.getPlayerName().toUpperCase() + " HP = " + computerHP);

//
//
//            if (a.makeChoice().equals("Attack")) {
//                attacker.attack(defender);
//            } else {
//                //TODO: consider other actions
//                throw new UnsupportedOperationException();
//            }

//            Character temp = a;
//            a = b;
//            b = temp;

            //TODO: display HP status?
        }

        if(playerHP <= 0)
            winner = 0;
        else
            winner = 1;

    }

    //display some message
    private static void gameOverScreen(PlayerCharacter a, NonPlayerCharacter b, int whoDied) {

        System.out.println("--- *** GAME OVER *** --- ");
        if (whoDied == 1)
        {
            System.out.println("--- *** " + a.getPlayerName().toUpperCase() + " WINS! *** ---");
        }
        else
            System.out.println("--- *** " + b.getPlayerName().toUpperCase() + " WINS! *** ---");

    }
}