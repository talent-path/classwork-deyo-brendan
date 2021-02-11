package com.tp.DailyPumpInitiative.services;

import com.tp.DailyPumpInitiative.models.Exercise;
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

    public Workout selectWorkout(Integer workoutID)
    {
        return workoutDao.getWorkoutByID(workoutID);
    }

    public Exercise selectExercise(Integer exerciseID)
    {
        return exerciseDao.getExerciseByID(exerciseID);
    }

//    public List<Exercise> setExerciseList(Integer workoutID)
//    {
//        return exerciseDao.setExerciseList(workoutID);
//    }

    public List<Exercise> getExerciseList(Integer workoutID)
    {
        return workoutDao.getExerciseList(workoutID);
    }

    public List<Workout> getWorkoutList(Integer intensityID)
    {
        return intensityDao.getWorkoutList(intensityID);
    }

    public boolean getCompleted(Integer exerciseID)
    {
        return exerciseDao.isCompleted(exerciseID);
    }

}
