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
    public ResponseEntity selectIntensity(Integer intensityID)
    {
        return service.setWorkoutList(intensityID); // return list of workouts
    }

    @PostMapping("/workout/{workoutID}")
    public ResponseEntity selectWorkout(Integer workoutID)
    {
        return service.setExerciseList(workoutID); // return list of exercises
    }

    @GetMapping("/workouts")
    public ResponseEntity getWorkoutList(Integer intensityID)
    {
        return service.getWorkoutList(intensityID);
    }

    @GetMapping("/exercises")
    public ResponseEntity getExerciseList(Integer workoutID)
    {
        return service.getExerciseList(workoutID); // return list of exercises
    }

    @PostMapping("/exercise/{exerciseID}")
    public ResponseEntity isCompleted(Integer exerciseID)
    {
        return service.getCompleted(exerciseID); // return exercise completed variable as true for given exerciseID
    }

}
