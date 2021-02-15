package com.tp.DailyPumpInitiative.controllers;


import com.tp.DailyPumpInitiative.exceptions.InvalidInputException;
import com.tp.DailyPumpInitiative.exceptions.NullIntensityException;
import com.tp.DailyPumpInitiative.exceptions.NullWorkoutException;
import com.tp.DailyPumpInitiative.services.DailyPumpServices;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api")
public class IntensityController {

    @Autowired
    DailyPumpServices service;

    @GetMapping("/list")
    public ResponseEntity getIntensityList()
    {
        try {
            return ResponseEntity.ok(service.getIntensityList());
        } catch (NullIntensityException | InvalidInputException ex) {
            return ResponseEntity.badRequest().body(ex.getMessage());
        }
    }

    @GetMapping("/intensity/{intensityID}")
    public ResponseEntity selectIntensity(@PathVariable Integer intensityID) {
        try {
            return ResponseEntity.ok(service.getWorkoutList(intensityID));
        } catch (NullIntensityException | NullWorkoutException | InvalidInputException ex) {
            return ResponseEntity.badRequest().body(ex.getMessage());
        }
    }

}
