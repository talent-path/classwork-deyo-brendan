package com.tp.DailyPumpInitiative.daos;

import com.tp.DailyPumpInitiative.models.Intensity;
import com.tp.DailyPumpInitiative.models.Workout;
import com.tp.DailyPumpInitiative.persistence.IntensityDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Profile;
import org.springframework.stereotype.Component;

import java.util.List;


@Component
@Profile("serviceTest")
public class IntensityInMemDao implements IntensityDao {

    @Override
    public Intensity getIntensityByID(Integer intensityID) {
        throw new UnsupportedOperationException();
    }

    @Override
    public List<Workout> getWorkoutList(Integer intensityID) {
        throw new UnsupportedOperationException();
    }
}
