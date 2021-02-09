package com.tp.DailyPumpInitiative.controllers;


import com.tp.DailyPumpInitiative.models.Workout;
import com.tp.DailyPumpInitiative.services.DailyPumpServices;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/api")
public class DailyPumpController {


    @Autowired
    DailyPumpServices service;

    @PostMapping("/intensity/{intensityID")
    public ResponseEntity selectIntensity(Integer intensityID)
    {
        return service.getIntensity();
    }

    @GetMapping("/workoutPlan")
    public ResponseEntity getWorkout(Workout workoutPlan)
    {
        return service.getWorkout();
    }

    @PostMapping("/completed")
    public ResponseEntity isCompleted(boolean completeWorkout)
    {
        return service.getCompleted();
    }


}
