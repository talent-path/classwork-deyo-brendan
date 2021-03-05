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

    /* INTENSITY SERVICES */

    public List<Intensity> getIntensityList() throws NullIntensityException,
            InvalidInputException
    {
        return intensityDao.getIntensityList();
    }


    /* WORKOUT SERVICES */

    public List<Workout> getWorkoutList(Integer intensityID) throws NullIntensityException,
            NullWorkoutException, InvalidInputException
    {
        return intensityDao.getWorkoutList(intensityID);
    }

    public void deleteWorkoutByID(Integer workoutID) throws NullWorkoutException,
            InvalidInputException
    {
        workoutDao.deleteWorkoutByID(workoutID);
    }

    public Workout addWorkoutToList(Workout toAdd) throws NullWorkoutException,
            InvalidInputException
    {
        return workoutDao.addWorkoutToList(toAdd);
    }

    /* EXERCISE SERVICES */

    public boolean getCompleted(Integer exerciseID) throws NullExerciseException,
            InvalidInputException
    {
        return exerciseDao.isCompleted(exerciseID);
    }

    public List<Exercise> getExerciseList(Integer workoutID) throws NullExerciseException,
            NullWorkoutException, InvalidInputException
    {
        return workoutDao.getExerciseList(workoutID);
    }

    public Exercise getExerciseByID(Integer exerciseID) throws NullExerciseException,
            InvalidInputException
    {
        return exerciseDao.getExerciseByID(exerciseID);
    }

    public void deleteExerciseByID(Integer exerciseID) throws NullExerciseException,
            InvalidInputException
    {
        exerciseDao.deleteExerciseByID(exerciseID);
    }

    public Exercise addExerciseToList(Exercise toAdd) throws NullExerciseException,
            InvalidInputException
    {
        return exerciseDao.addExerciseToList(toAdd);
    }

}
