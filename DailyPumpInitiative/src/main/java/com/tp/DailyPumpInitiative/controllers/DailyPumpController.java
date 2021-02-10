package com.tp.DailyPumpInitiative.controllers;


import com.tp.DailyPumpInitiative.models.Exercise;
import com.tp.DailyPumpInitiative.models.Workout;
import com.tp.DailyPumpInitiative.services.DailyPumpServices;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/api")
public class DailyPumpController {


    @Autowired
    DailyPumpServices service;

    @PostMapping("/intensity/{intensityID}")
    public ResponseEntity selectIntensity(Integer intensityID) {
        try {
            return ResponseEntity.ok(service.setWorkoutList(intensityID));
        } catch (NullPointerException ex) {
            return ResponseEntity.badRequest().body(ex.getMessage());
        }
    }

    @PostMapping("/workout/{workoutID}")
    public ResponseEntity selectWorkout(Integer workoutID) {
        try {
            return ResponseEntity.ok(service.setExerciseList(workoutID));
        } catch (NullPointerException ex) {
            return ResponseEntity.badRequest().body(ex.getMessage());
        }
    }

    @GetMapping("/workouts")
    public ResponseEntity getWorkoutList(Integer intensityID) {
        try {
            return ResponseEntity.ok(service.getWorkoutList(intensityID));
        } catch (NullPointerException ex) {
            return ResponseEntity.badRequest().body(ex.getMessage());
        }
    }

    @GetMapping("/exercises")
    public ResponseEntity getExerciseList(Integer workoutID) {
        try {
            return ResponseEntity.ok(service.getExerciseList(workoutID));
        } catch (NullPointerException ex) {
            return ResponseEntity.badRequest().body(ex.getMessage());
        }
    }

    @PostMapping("/exercise/{exerciseID}")
    public ResponseEntity isCompleted(Integer exerciseID) {
        try {
            return ResponseEntity.ok(service.getCompleted(exerciseID));
        } catch (NullPointerException ex) {
            return ResponseEntity.badRequest().body(ex.getMessage());
        }
    }

}
