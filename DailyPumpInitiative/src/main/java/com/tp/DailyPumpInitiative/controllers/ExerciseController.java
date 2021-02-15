package com.tp.DailyPumpInitiative.controllers;

import com.tp.DailyPumpInitiative.exceptions.InvalidInputException;
import com.tp.DailyPumpInitiative.exceptions.NullExerciseException;
import com.tp.DailyPumpInitiative.exceptions.NullWorkoutException;
import com.tp.DailyPumpInitiative.services.DailyPumpServices;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api")
public class ExerciseController {

    @Autowired
    DailyPumpServices service;

    @GetMapping("/exercises/{workoutID}")
    public ResponseEntity getExerciseList(@PathVariable Integer workoutID) {
        try {
            return ResponseEntity.ok(service.getExerciseList(workoutID));
        } catch (NullExerciseException | NullWorkoutException | InvalidInputException ex) {
            return ResponseEntity.badRequest().body(ex.getMessage());
        }
    }

    @PostMapping("/exercise/{exerciseID}")
    public ResponseEntity isCompleted(@PathVariable Integer exerciseID) {
        try {
            return ResponseEntity.ok(service.getCompleted(exerciseID));
        } catch (NullExerciseException | InvalidInputException ex) {
            return ResponseEntity.badRequest().body(ex.getMessage());
        }
    }

}
