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

        getPlayerStats(pc);
        getComputerStats(npc);


        battle(pc, npc, winner);

        gameOverScreen(pc, npc, winner);

    }

    private static PlayerCharacter setUpPlayer() {
        PlayerCharacter knight = null;
        int optionNumber;

        System.out.println("(1) Knight Artorias | Armor: Black Iron Set | Weapon: Broadsword |");
        System.out.println("(2) Hawkwood | Armor: Cloth Armor Set | Weapon : Dual Daggers |");
        System.out.println("(3) Siegward of Catarina | Armor: Smough's Set | Weapon: Stone Greatsword |");
        optionNumber = Console.readInt("--- *** Choose your knight *** --- : ");
        System.out.println();

        if (optionNumber == 1) {
            knight = new KnightArtorias();
        } else if (optionNumber == 2) {
            knight = new Hawkwood();
        } else if (optionNumber == 3) {
            knight = new SiegwardofCatarina();
        }

        return knight;

    }

    private static NonPlayerCharacter setUpEnemy() {

        NonPlayerCharacter knight = null;

        int optionNumber = RNG.randInt(0, 2);
        if (optionNumber == 0) {
            knight = new BigHatLogan();
        } else if (optionNumber == 1) {
            knight = new KnightSolaire();
        } else if (optionNumber == 2) {
            knight = new RingfingerLeonhard();
        }

        return knight;
    }

    public static int drinkEstusFlask()
    {
        return 50;
    }

    private static void getPlayerStats(PlayerCharacter a)
    {
        int playerHP = a.getArmorSet().baseArmor();
        System.out.println(a.getPlayerName().toUpperCase() + " HP = " + playerHP);

        int playerDMG = a.getWeaponChoice().generateDamage();
        System.out.println(a.getPlayerName().toUpperCase() + " Damage = " + playerDMG);

        int playerMVMT = a.getArmorSet().movementSpeed() + a.getWeaponChoice().movement();
        System.out.println(a.getPlayerName().toUpperCase() + " Movement Speed = " + playerMVMT);

        System.out.println();
        System.out.println();

    }

    private static void getComputerStats(NonPlayerCharacter b)
    {
        int playerHP = b.getArmorSet().baseArmor();
        System.out.println(b.getPlayerName().toUpperCase() + " HP = " + playerHP);

        int playerDMG = b.getWeaponChoice().generateDamage();
        System.out.println(b.getPlayerName().toUpperCase() + " Damage = " + playerDMG);

        int playerMVMT = b.getArmorSet().movementSpeed() + b.getWeaponChoice().movement();
        System.out.println(b.getPlayerName().toUpperCase() + " Movement Speed = " + playerMVMT);

        System.out.println();
        System.out.println();
    }

    private static int battle(PlayerCharacter a, NonPlayerCharacter b, int winner) {

        PlayerCharacter attacker = a;
        NonPlayerCharacter defender = b;

        int turn = 0;

        int playerHP = attacker.getArmorSet().baseArmor();
        int computerHP = defender.getArmorSet().baseArmor();

        int playerDMG = attacker.getWeaponChoice().generateDamage();
        int computerDMG = defender.getWeaponChoice().generateDamage();

        int playerMVMT = attacker.getArmorSet().movementSpeed() + attacker.getWeaponChoice().movement();
        int computerMVMT = defender.getArmorSet().movementSpeed() + defender.getWeaponChoice().movement();


        while (a.isAlive(playerHP) && b.isAlive(computerHP)) {

            if (playerMVMT > computerMVMT) {
                turn = 1;
                computerHP = computerHP - playerDMG;
                if (playerMVMT > (computerMVMT * 1.5)) {
                    computerHP = computerHP - playerDMG;
                }
            } else if (computerMVMT > playerMVMT) {
                turn = 2;
                playerHP = playerHP - computerDMG;
                if (computerMVMT > (playerMVMT * 1.5)) {
                    playerHP = playerHP - computerDMG;
                }
            }
            if (turn == 1) {
                playerHP = playerHP - computerDMG;
            } else
                computerHP = computerHP - playerDMG;


            if (computerHP <= 0) {
                winner = 1;
            } else
                winner = 0;
        }

        return winner;

    }

    private static void gameOverScreen(PlayerCharacter a, NonPlayerCharacter b, int winner) {

        System.out.println("--- *** GAME OVER *** --- ");
        if (winner == 1)
        {
            System.out.println("--- *** " + a.getPlayerName().toUpperCase() + " WINS! *** ---");
        }
        else
            System.out.println("--- *** " + b.getPlayerName().toUpperCase() + " WINS! *** ---");

    }
}