package com.tp.DailyPumpInitiative.controllers;


import com.tp.DailyPumpInitiative.services.DailyPumpServices;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/api")
public class WorkoutController {

    @Autowired
    DailyPumpServices service;

    @PostMapping("/workout/{workoutID}")
    public ResponseEntity selectWorkout(Integer workoutID) {
        try {
            return ResponseEntity.ok(service.getExerciseList(workoutID));
        } catch (NullPointerException ex) {
            return ResponseEntity.badRequest().body(ex.getMessage());
        }
    }

    @GetMapping("/workouts/{intensityID}")
    public ResponseEntity getWorkoutList(Integer intensityID) {
        try {
            return ResponseEntity.ok(service.getWorkoutList(intensityID));
        } catch (NullPointerException ex) {
            return ResponseEntity.badRequest().body(ex.getMessage());
        }
    }


}
