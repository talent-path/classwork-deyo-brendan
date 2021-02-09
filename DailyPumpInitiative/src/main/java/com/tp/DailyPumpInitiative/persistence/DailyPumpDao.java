package com.tp.DailyPumpInitiative.persistence;

import com.tp.DailyPumpInitiative.models.Exercise;
import com.tp.DailyPumpInitiative.models.Workout;

import java.util.List;

public interface DailyPumpDao {

    Workout getWorkoutByID(Integer workoutID);

    Workout getExerciseList(List<Exercise> exerciseList);

}
