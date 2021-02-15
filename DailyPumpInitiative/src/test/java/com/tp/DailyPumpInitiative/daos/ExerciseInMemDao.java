package com.tp.DailyPumpInitiative.daos;


import com.tp.DailyPumpInitiative.models.Exercise;
import com.tp.DailyPumpInitiative.models.Intensity;
import com.tp.DailyPumpInitiative.models.Workout;
import com.tp.DailyPumpInitiative.persistence.ExerciseDao;
import com.tp.DailyPumpInitiative.persistence.WorkoutDao;
import org.springframework.context.annotation.Profile;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

@Component
@Profile("serviceTest")
public class ExerciseInMemDao implements ExerciseDao {

    private List<Exercise> exerciseList = new ArrayList<>();
    private List<Workout> workoutList = new ArrayList<>();

    private Exercise newExercise = new Exercise();
    private Workout newWorkout = new Workout();

    public void initializeVariables()
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
    public Exercise getExerciseByID(Integer exerciseID) {
        initializeVariables();
        Exercise toReturn = null;

        for (Exercise toCopy : exerciseList)
        {
            if (toCopy.getExerciseID().equals(exerciseID))
            {
                toReturn = new Exercise(toCopy);
            }
        }

        if (toReturn.getExerciseID() == null)
        {
            throw new NullPointerException();
        }

        return toReturn;
    }

    @Override
    public boolean isCompleted(Integer exerciseID) {
        initializeVariables();
        Boolean toReturn = false;

        for (int i = 0; i < exerciseList.size(); i++)
        {
            if (exerciseList.get(i).isComplete())
            {
                toReturn = true;
            }
        }
        return toReturn;
    }

}
