package com.tp.DailyPumpInitiative.services;

import com.tp.DailyPumpInitiative.exceptions.InvalidInputException;
import com.tp.DailyPumpInitiative.exceptions.NullExerciseException;
import com.tp.DailyPumpInitiative.exceptions.NullIntensityException;
import com.tp.DailyPumpInitiative.exceptions.NullWorkoutException;
import com.tp.DailyPumpInitiative.models.Exercise;
import com.tp.DailyPumpInitiative.models.Intensity;
import com.tp.DailyPumpInitiative.models.Workout;
import com.tp.DailyPumpInitiative.persistence.ExerciseDao;
import com.tp.DailyPumpInitiative.persistence.IntensityDao;
import com.tp.DailyPumpInitiative.persistence.WorkoutDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import org.springframework.web.bind.annotation.PathVariable;

import java.util.List;

@Component
public class DailyPumpServices {

    @Autowired
    WorkoutDao workoutDao;

    @Autowired
    ExerciseDao exerciseDao;

    @Autowired
    IntensityDao intensityDao;

//    public Workout setWorkoutList(Integer intensityID)
//    {
//        return workoutDao.getIntensityByID(intensityID);
//    }

    public List<Intensity> getIntensityList() throws NullIntensityException,
            InvalidInputException
    {
        return intensityDao.getIntensityList();
    }

    public List<Exercise> getExerciseList(Integer workoutID) throws NullExerciseException,
            NullWorkoutException, InvalidInputException
    {
        return workoutDao.getExerciseList(workoutID);
    }

    public List<Workout> getWorkoutList(Integer intensityID) throws NullIntensityException,
            NullWorkoutException, InvalidInputException
    {
        return intensityDao.getWorkoutList(intensityID);
    }

    public boolean getCompleted(Integer exerciseID) throws NullExerciseException,
            InvalidInputException
    {
        return exerciseDao.isCompleted(exerciseID);
    }

}
