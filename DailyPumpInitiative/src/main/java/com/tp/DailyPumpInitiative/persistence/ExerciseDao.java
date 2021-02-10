package com.tp.DailyPumpInitiative.persistence;

import com.tp.DailyPumpInitiative.models.Exercise;

import java.util.List;

public interface ExerciseDao {

    List<Exercise> getExerciseList(Integer workoutID);

    boolean isCompleted(Integer exerciseID);

    List<Exercise> setExerciseList(Integer workoutID);
}
