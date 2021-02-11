package com.tp.DailyPumpInitiative.persistence;

import com.tp.DailyPumpInitiative.models.Exercise;
import com.tp.DailyPumpInitiative.models.Workout;

import java.util.List;

public interface WorkoutDao {

    Workout getWorkoutByID(Integer workoutID);

    List<Exercise> getExerciseList(Integer workoutID);

}
