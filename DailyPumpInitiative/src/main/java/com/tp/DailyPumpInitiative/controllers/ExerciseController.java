package com.tp.DailyPumpInitiative.controllers;

import com.tp.DailyPumpInitiative.exceptions.InvalidInputException;
import com.tp.DailyPumpInitiative.exceptions.NullExerciseException;
import com.tp.DailyPumpInitiative.exceptions.NullWorkoutException;
import com.tp.DailyPumpInitiative.models.Exercise;
import com.tp.DailyPumpInitiative.services.DailyPumpServices;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api")
@CrossOrigin("http://localhost:4200")
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

    @GetMapping("/getExercise/{exerciseID}")
    public ResponseEntity getExerciseByID(@PathVariable Integer exerciseID)
    {
        try {
            return ResponseEntity.ok(service.getExerciseByID(exerciseID));
        } catch (NullExerciseException | InvalidInputException ex)
        {
            return ResponseEntity.badRequest().body(ex.getMessage());
        }
    }

    @DeleteMapping("/deleteExercise/{exerciseID}")
    public void deleteExerciseByID(@PathVariable Integer exerciseID)
    {
        try {
            service.deleteExerciseByID(exerciseID);
        } catch (NullExerciseException e) {
            e.getMessage();
        } catch (InvalidInputException e) {
            e.getMessage();
        }

    }

    @PostMapping("/addExercise")
    public ResponseEntity addExerciseToList(@RequestBody Exercise toAdd)
    {
        Exercise toReturn = null;
        try {
            toReturn = service.addExerciseToList(toAdd);
        } catch (NullExerciseException e) {
            e.getMessage();
        } catch (InvalidInputException e) {
            e.getMessage();
        }

        return ResponseEntity.ok(toReturn);
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
