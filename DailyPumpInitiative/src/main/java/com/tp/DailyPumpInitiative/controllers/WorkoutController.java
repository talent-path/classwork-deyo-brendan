package com.tp.DailyPumpInitiative.controllers;


import com.tp.DailyPumpInitiative.exceptions.InvalidInputException;
import com.tp.DailyPumpInitiative.exceptions.NullExerciseException;
import com.tp.DailyPumpInitiative.exceptions.NullIntensityException;
import com.tp.DailyPumpInitiative.exceptions.NullWorkoutException;
import com.tp.DailyPumpInitiative.models.Exercise;
import com.tp.DailyPumpInitiative.models.Workout;
import com.tp.DailyPumpInitiative.services.DailyPumpServices;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api")
@CrossOrigin("http://localhost:4200")
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

    @DeleteMapping("deleteWorkout/{workoutID")
    public void deleteWorkoutByID(@PathVariable Integer workoutID)
    {
        try {
            service.deleteWorkoutByID(workoutID);
        } catch (NullWorkoutException e) {
            e.getMessage();
        } catch (InvalidInputException e) {
            e.getMessage();
        }
    }

    @PostMapping("addWorkout")
    public ResponseEntity addWorkoutToList(Workout toAdd)
    {
        Workout toReturn = null;
        try {
            toReturn = service.addWorkoutToList(toAdd);
        } catch (NullWorkoutException e) {
            e.getMessage();
        } catch (InvalidInputException e) {
            e.getMessage();
        }

        return ResponseEntity.ok(toReturn);
    }


}
