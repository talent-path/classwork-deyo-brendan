package com.tp.DailyPumpInitiative.persistence;

import com.tp.DailyPumpInitiative.models.Intensity;
import com.tp.DailyPumpInitiative.models.Workout;

import java.util.List;

public interface IntensityDao {

    Intensity getIntensityByID(Integer intensityID);

    List<Workout> getWorkoutList(Integer intensityID);

    List<Intensity> getIntensityList();

}
