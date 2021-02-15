package com.tp.DailyPumpInitiative.services;

import com.tp.DailyPumpInitiative.daos.ExerciseInMemDao;
import com.tp.DailyPumpInitiative.daos.IntensityInMemDao;
import com.tp.DailyPumpInitiative.daos.WorkoutInMemDao;
import com.tp.DailyPumpInitiative.exceptions.InvalidInputException;
import com.tp.DailyPumpInitiative.exceptions.NullExerciseException;
import com.tp.DailyPumpInitiative.exceptions.NullIntensityException;
import com.tp.DailyPumpInitiative.exceptions.NullWorkoutException;
import com.tp.DailyPumpInitiative.models.Exercise;
import com.tp.DailyPumpInitiative.models.Intensity;
import com.tp.DailyPumpInitiative.models.Workout;
import org.junit.jupiter.api.BeforeEach;
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

    @Autowired
    ExerciseInMemDao exerciseDao;

    @Autowired
    IntensityInMemDao intensityDao;

    @Autowired
    WorkoutInMemDao workoutDao;


    private List<Intensity> intensityList = new ArrayList<>();
    private List<Workout> workoutList = new ArrayList<>();
    private List<Exercise> exerciseList = new ArrayList<>();

    private Intensity newIntensity = new Intensity();
    private Workout newWorkout = new Workout();
    private Exercise newExercise = new Exercise();

    @Test
    public void getIntensityByIDGoldenPath()
    {
        String intensityName = intensityDao.getIntensityByID(1).getIntensityName();
        int intensityID = intensityDao.getIntensityList().get(0).getIntensityID();

        assertEquals("Light", intensityName);
        assertEquals(1, intensityID);
    }

    @Test
    public void getWorkoutListGoldenPath()
    {
        List<Workout> newList = new ArrayList<>();
        newList = intensityDao.getWorkoutList(3);
        String workoutTitle = newList.get(2).getWorkoutName();

        assertEquals("Full Lower Body", workoutTitle);

    }

    @Test
    public void getIntensityListGoldenPath()
    {

    }

    @Test
    public void getWorkoutByIDGoldenPath()
    {

    }

    @Test
    public void getExerciseListGoldenPath()
    {

    }

    @Test
    public void getExerciseByIDGoldenPath()
    {

    }

    @Test
    public void getIsExerciseCompleteGoldenPath()
    {

    }





}
