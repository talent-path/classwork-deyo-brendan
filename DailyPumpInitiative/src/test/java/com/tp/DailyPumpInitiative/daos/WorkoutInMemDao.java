package com.tp.DailyPumpInitiative.daos;

import com.tp.DailyPumpInitiative.models.Exercise;
import com.tp.DailyPumpInitiative.models.Intensity;
import com.tp.DailyPumpInitiative.models.Workout;
import com.tp.DailyPumpInitiative.persistence.WorkoutDao;
import org.springframework.context.annotation.Profile;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

@Component
@Profile("serviceTest")
public class WorkoutInMemDao implements WorkoutDao {

    private List<Workout> workoutList = new ArrayList<>();
    private List<Exercise> exerciseList = new ArrayList<>();

    private Workout newWorkout = new Workout();
    private Exercise newExercise = new Exercise();

    public void initalizeVariables()
    {
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

    @Override
    public Workout getWorkoutByID(Integer workoutID) {
        initalizeVariables();
        Workout toReturn = null;

        for (Workout toCopy : workoutList)
        {
            if (toCopy.getWorkoutID().equals(workoutID))
            {
                toReturn = new Workout(toCopy);
            }
        }

        if (toReturn.getWorkoutID() == null)
        {
            throw new NullPointerException();
        }

        return toReturn;
    }

    @Override
    public List<Exercise> getExerciseList(Integer workoutID) {
        initalizeVariables();
        List<Exercise> newList = new ArrayList<>();

        for (Exercise toCopy : exerciseList)
        {
            if (toCopy.getWorkoutID().equals(workoutID))
                newList.add(new Exercise(toCopy));
        }
        return newList;

    }
}
