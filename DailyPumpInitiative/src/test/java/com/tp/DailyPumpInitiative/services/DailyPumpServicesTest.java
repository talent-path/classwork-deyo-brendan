package com.tp.DailyPumpInitiative.services;

import com.tp.DailyPumpInitiative.exceptions.InvalidInputException;
import com.tp.DailyPumpInitiative.exceptions.NullExerciseException;
import com.tp.DailyPumpInitiative.exceptions.NullIntensityException;
import com.tp.DailyPumpInitiative.exceptions.NullWorkoutException;
import com.tp.DailyPumpInitiative.models.Exercise;
import com.tp.DailyPumpInitiative.models.Intensity;
import com.tp.DailyPumpInitiative.models.Workout;
import org.junit.jupiter.api.BeforeEach;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.ActiveProfiles;

import java.util.ArrayList;
import java.util.List;

@SpringBootTest
@ActiveProfiles("serviceTesting")
public class DailyPumpServicesTest {


    @Autowired
    DailyPumpServices toTest;

    private List<Intensity> intensityList = new ArrayList<>();
    private List<Workout> workoutList = new ArrayList<>();
    private List<Exercise> exerciseList = new ArrayList<>();

    private Intensity newIntensity = new Intensity();
    private Workout newWorkout = new Workout();
    private Exercise newExercise = new Exercise();

    @BeforeEach
    public void setup() throws InvalidInputException, NullWorkoutException,
            NullExerciseException, NullIntensityException
    {

        // configure intensities + variables
        newIntensity = new Intensity(1, "Light", "20 Minutes", "Desc1");
        intensityList.add(newIntensity);

        newIntensity = new Intensity(2, "Moderate", "40 Minutes", "Desc2");
        intensityList.add(newIntensity);

        newIntensity = new Intensity(3, "Heavy", "60 Minutes", "Desc3");
        intensityList.add(newIntensity);

        // configure workouts
        newWorkout = new Workout(1, 1, "HIIT Circuit",
                "AMRAP");
        workoutList.add(newWorkout);

        newWorkout = new Workout(2, 2, "Upper Body Push",
                "Chest & Shoulders");
        workoutList.add(newWorkout);

        newWorkout = new Workout(3, 3, "Full Lower Body",
                "Pump the legs!");
        workoutList.add(newWorkout);

        // configure exercises
        newExercise = new Exercise("Front Squats", 150, "5 - 7", 3, false
                , false, 1, "Desc1", 5);
        exerciseList.add(newExercise);

        newExercise = new Exercise("Back Squats", 160, "5 - 7", 3, false
                , true, 2, "Desc2", 4);
        exerciseList.add(newExercise);

        newExercise = new Exercise("Lunges", 120, "6 - 7", 3, false
                , false, 3, "Desc3", 5);
        exerciseList.add(newExercise);

    }



}
