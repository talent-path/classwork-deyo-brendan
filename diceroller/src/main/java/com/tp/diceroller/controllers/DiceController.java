package com.tp.diceroller.controllers;

import com.tp.diceroller.services.RNG;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class DiceController {

    @GetMapping("/helloWorld")
    public String helloWorld()
    {
        return "Hello World";
    }

    @GetMapping("/sixSides")
    public int sixSides()
    {
        return RNG.rollDice(6);
    }

    @GetMapping("/twentySides")
    public int twentySides()
    {
        return RNG.rollDice(20);
    }

    @GetMapping("/nSides")
    public int nSides(Integer num)
    {
        return RNG.rollDice(num);
    }

    @GetMapping("/nSides/{num}")
    public int nSidesPathVariable(@PathVariable Integer num) {
        return RNG.rollDice(num);
    }

}
