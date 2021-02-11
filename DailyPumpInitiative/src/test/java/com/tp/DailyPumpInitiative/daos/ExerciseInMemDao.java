package com.tp.DailyPumpInitiative.daos;


import com.tp.DailyPumpInitiative.models.Exercise;
import com.tp.DailyPumpInitiative.persistence.ExerciseDao;
import com.tp.DailyPumpInitiative.persistence.WorkoutDao;
import org.springframework.context.annotation.Profile;
import org.springframework.stereotype.Component;

import java.util.List;

@Component
@Profile("serviceTest")
public class ExerciseInMemDao implements ExerciseDao {


    @Override
    public Exercise getExerciseByID(Integer exerciseID) {
        throw new UnsupportedOperationException();
    }

    @Override
    public boolean isCompleted(Integer exerciseID) {
        return false;
    }
}
