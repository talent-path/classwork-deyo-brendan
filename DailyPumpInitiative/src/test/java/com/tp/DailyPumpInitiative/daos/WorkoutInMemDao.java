package com.tp.DailyPumpInitiative.daos;

import com.tp.DailyPumpInitiative.models.Exercise;
import com.tp.DailyPumpInitiative.models.Workout;
import com.tp.DailyPumpInitiative.persistence.WorkoutDao;
import org.springframework.context.annotation.Profile;
import org.springframework.stereotype.Component;

import java.util.List;

@Component
@Profile("serviceTest")
public class WorkoutInMemDao implements WorkoutDao {

    @Override
    public Workout getWorkoutByID(Integer workoutID) {
        throw new UnsupportedOperationException();
    }

    @Override
    public List<Exercise> getExerciseList(Integer workoutID) {
        throw new UnsupportedOperationException();
    }
}