package com.tp.DailyPumpInitiative.daos;

import com.tp.DailyPumpInitiative.exceptions.NullIntensityException;
import com.tp.DailyPumpInitiative.models.Intensity;
import com.tp.DailyPumpInitiative.models.Workout;
import com.tp.DailyPumpInitiative.persistence.IntensityDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Profile;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;


@Component
@Profile("serviceTest")
public class IntensityInMemDao implements IntensityDao {

    private List<Intensity> intensityList = new ArrayList<>();
    private List<Workout> workoutList = new ArrayList<>();

    private Intensity newIntensity = new Intensity();
    private Workout newWorkout = new Workout();

    // configure intensities + variables
    public void initializeValues()
    {
        newIntensity = new Intensity(1, "Light", "20 Minutes", "Desc1");
        intensityList.add(newIntensity);

        newIntensity = new Intensity(2, "Moderate", "40 Minutes", "Desc2");
        intensityList.add(newIntensity);

        newIntensity = new Intensity(3, "Heavy", "60 Minutes", "Desc3");
        intensityList.add(newIntensity);

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

    }

    @Override
    public Intensity getIntensityByID(Integer intensityID) {
        initializeValues();
        Intensity toReturn = null;

        for (Intensity toCopy : intensityList)
        {
            if (toCopy.getIntensityID().equals(intensityID))
            {
                toReturn = new Intensity(toCopy);
            }
        }

        if (toReturn.getIntensityID() == null)
        {
            throw new NullPointerException();
        }

        return toReturn;

    }

    @Override
    public List<Workout> getWorkoutList(Integer intensityID) {
        initializeValues();
        List<Workout> newList = new ArrayList<>();

        for (Workout toCopy : workoutList)
        {
            if (toCopy.getWorkoutID().equals(intensityID))
                newList.add(new Workout(toCopy));
        }

        return newList;
    }

    @Override
    public List<Intensity> getIntensityList() {
        initializeValues();
        List<Intensity> newList = new ArrayList<>();

        for (Intensity toCopy : intensityList)
        {
            newList.add(new Intensity(toCopy));
        }
        return newList;
    }


}
