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
public class ExerciseController {

    @Autowired
    DailyPumpServices service;

    @GetMapping("/exercises/{workoutID}")
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
