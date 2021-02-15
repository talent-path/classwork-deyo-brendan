package com.tp.DailyPumpInitiative.services;

import com.tp.DailyPumpInitiative.models.Exercise;
import com.tp.DailyPumpInitiative.models.Intensity;
import com.tp.DailyPumpInitiative.models.Workout;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.ActiveProfiles;

import static org.junit.jupiter.api.Assertions.*;
import java.util.ArrayList;
import java.util.List;

@SpringBootTest
@ActiveProfiles("serviceTest")
public class DailyPumpServicesTest {


    @Autowired
    DailyPumpServices toTest;

//    private List<Intensity> intensityList = new ArrayList<>();
//    private List<Workout> workoutList = new ArrayList<>();
//    private List<Exercise> exerciseList = new ArrayList<>();
//
//    private Intensity newIntensity = new Intensity();
//    private Workout newWorkout = new Workout();
//    private Exercise newExercise = new Exercise();

    @Test
    public void getIntensityByIDGoldenPath()
    {
        String intensityName = toTest.intensityDao.getIntensityByID(1).getIntensityName();
        int intensityID = toTest.intensityDao.getIntensityList().get(0).getIntensityID();

        assertEquals("Light", intensityName);
        assertEquals(1, intensityID);

    }

    @Test
    public void getWorkoutListGoldenPath()
    {
        List<Workout> newList = toTest.intensityDao.getWorkoutList(3);
        String workoutTitle = newList.get(0).getWorkoutName();

        assertEquals("Full Lower Body", workoutTitle);
        assertEquals(3, newList.get(0).getWorkoutID());

        newList = toTest.intensityDao.getWorkoutList(1);
        workoutTitle = newList.get(0).getWorkoutName();

        assertEquals("HIIT Circuit", workoutTitle);
        assertEquals(1, newList.get(0).getWorkoutID());

    }

    @Test
    public void getIntensityListGoldenPath()
    {
        assertEquals(1, toTest.intensityDao.getIntensityList().get(0).getIntensityID());
        assertEquals(2, toTest.intensityDao.getIntensityList().get(1).getIntensityID());
        assertEquals(3, toTest.intensityDao.getIntensityList().get(2).getIntensityID());

        assertEquals("Light", toTest.intensityDao.getIntensityList().get(0).getIntensityName());
        assertEquals("Moderate", toTest.intensityDao.getIntensityList().get(1).getIntensityName());
        assertEquals("Heavy", toTest.intensityDao.getIntensityList().get(2).getIntensityName());
    }

    @Test
    public void getWorkoutByIDGoldenPath()
    {
        String workoutName = toTest.workoutDao.getWorkoutByID(1).getWorkoutName();
        int workoutID = toTest.workoutDao.getWorkoutByID(3).getWorkoutID();
        String workoutDesc = toTest.workoutDao.getWorkoutByID(2).getWorkoutDescription();
        int intensityID = toTest.workoutDao.getWorkoutByID(1).getIntensityID();

        assertEquals("HIIT Circuit", workoutName);
        assertEquals(3, workoutID);
        assertEquals("Chest & Shoulders", workoutDesc);
        assertEquals(1, intensityID);
    }

    @Test
    public void getExerciseListGoldenPath() {
        List<Exercise> exerciseList = toTest.workoutDao.getExerciseList(3);
        int size = exerciseList.size();
        assertEquals(3, size);

        int exerciseID = exerciseList.get(0).getExerciseID();
        String exerciseName = exerciseList.get(1).getExerciseName();
        String exerciseDesc = exerciseList.get(2).getExerciseDesc();
        int exerciseSets = exerciseList.get(0).getExerciseSets();

        assertEquals(1, exerciseID);
        assertEquals("Back Squats", exerciseName);
        assertEquals("Desc3", exerciseDesc);
        assertEquals(5, exerciseSets);

        assertEquals(0, toTest.workoutDao.getExerciseList(1).size());

    }

    @Test
    public void getExerciseByIDGoldenPath()
    {
        assertEquals("Front Squats", toTest.exerciseDao.getExerciseByID(1).getExerciseName());
        assertEquals(2, toTest.exerciseDao.getExerciseByID(2).getExerciseID());
        assertEquals(150, toTest.exerciseDao.getExerciseByID(1).getExerciseWeight());
        assertEquals("Desc3", toTest.exerciseDao.getExerciseByID(3).getExerciseDesc());
        assertEquals("6 - 7", toTest.exerciseDao.getExerciseByID(3).getExerciseReps());
        assertEquals(5, toTest.exerciseDao.getExerciseByID(3).getExerciseSets());
    }

    @Test
    public void getIsExerciseCompleteGoldenPath()
    {
        List<Workout> workoutList = toTest.intensityDao.getWorkoutList(3);
        List<Exercise> exerciseList = toTest.workoutDao.getExerciseList(workoutList.get(0).getWorkoutID());
        assertEquals(3, exerciseList.size());

        boolean completed = exerciseList.get(0).isComplete();
        assertFalse(completed);

        completed = exerciseList.get(1).isComplete();
        assertTrue(completed);

        completed = exerciseList.get(2).isComplete();
        assertFalse(completed);
    }





}
