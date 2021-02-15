package com.tp.DailyPumpInitiative.controllers;


import com.tp.DailyPumpInitiative.exceptions.InvalidInputException;
import com.tp.DailyPumpInitiative.exceptions.NullExerciseException;
import com.tp.DailyPumpInitiative.exceptions.NullIntensityException;
import com.tp.DailyPumpInitiative.exceptions.NullWorkoutException;
import com.tp.DailyPumpInitiative.services.DailyPumpServices;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api")
public class WorkoutController {

    @Autowired
    DailyPumpServices service;

    @GetMapping("/workout/{workoutID}")
    public ResponseEntity selectWorkout(@PathVariable Integer workoutID) {
        try {
            return ResponseEntity.ok(service.getExerciseList(workoutID));
        } catch (NullExerciseException | NullWorkoutException | InvalidInputException ex) {
            return ResponseEntity.badRequest().body(ex.getMessage());
        }
    }

    @GetMapping("/workouts/{intensityID}")
    public ResponseEntity getWorkoutList(@PathVariable Integer intensityID) {
        try {
            return ResponseEntity.ok(service.getWorkoutList(intensityID));
        } catch (NullIntensityException | NullWorkoutException | InvalidInputException ex) {
            return ResponseEntity.badRequest().body(ex.getMessage());
        }
    }


}
