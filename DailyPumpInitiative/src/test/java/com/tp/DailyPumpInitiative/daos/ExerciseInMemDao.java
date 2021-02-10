package com.tp.DailyPumpInitiative.daos;


import com.tp.DailyPumpInitiative.models.Exercise;
import com.tp.DailyPumpInitiative.persistence.WorkoutDao;
import org.springframework.context.annotation.Profile;
import org.springframework.stereotype.Component;

@Component
@Profile("serviceTest")
public class ExerciseInMemDao implements WorkoutDao {

    @Override
    public Exercise getExerciseByID(Integer exerciseID)
    {
        throw new UnsupportedOperationException();
    }


}
