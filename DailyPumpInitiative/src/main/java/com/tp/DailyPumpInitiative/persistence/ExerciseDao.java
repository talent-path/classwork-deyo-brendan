package com.tp.DailyPumpInitiative.persistence;

import com.tp.DailyPumpInitiative.models.Exercise;

import java.util.List;

public interface ExerciseDao {

    Exercise getExerciseByID(Integer exerciseID);

    boolean isCompleted(Integer exerciseID);

}
