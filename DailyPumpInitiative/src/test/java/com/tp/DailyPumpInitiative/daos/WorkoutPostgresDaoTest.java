package com.tp.DailyPumpInitiative.daos;


import com.tp.DailyPumpInitiative.models.Exercise;
import com.tp.DailyPumpInitiative.models.Workout;
import com.tp.DailyPumpInitiative.persistence.WorkoutPostgresDao;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.test.context.ActiveProfiles;

import java.util.ArrayList;
import java.util.List;

import static org.junit.jupiter.api.Assertions.assertEquals;

@SpringBootTest
@ActiveProfiles("daoTesting")
public class WorkoutPostgresDaoTest {

    @Autowired
    WorkoutPostgresDao toTest;

    @Autowired
    JdbcTemplate template;


    @BeforeEach
    public void setup()
    {
        template.update("TRUNCATE \"Intensity\", \"Workout\", \"Exercise\" RESTART IDENTITY;");
    }

    @Test
    public void getWorkoutByWorkoutIDGoldenPath()
    {
        throw new UnsupportedOperationException();
    }

    @Test
    public void getExerciseListByWorkoutIDGoldenPath()
    {
        Workout newWorkout = new Workout(1, 3, "Upper Body Pull",
                "Back & Arms");

        List<Exercise> newList = new ArrayList<>();

        Exercise newExercise = new Exercise();

        newExercise.setExerciseName("Front Squats");
        newExercise.setBodyweight(false);
        newExercise.setComplete(false);
        newExercise.setExerciseWeight(150);
        newExercise.setExerciseReps("5 - 7");
        newExercise.setExerciseID(1);
        newExercise.setWorkoutID(3);
        newExercise.setExerciseDesc("Put bar in front of you resting on front delts.");
        newExercise.setExerciseSets(4);

        newList.add(newExercise);

        newExercise.setExerciseName("Back Squats");
        newExercise.setBodyweight(false);
        newExercise.setComplete(false);
        newExercise.setExerciseWeight(150);
        newExercise.setExerciseReps("5 - 7");
        newExercise.setExerciseID(2);
        newExercise.setWorkoutID(3);
        newExercise.setExerciseDesc("Put bar behind you resting on traps.");
        newExercise.setExerciseSets(4);

        newList.add(newExercise);
        newWorkout.setExerciseList(newList);

        int listSize = toTest.getExerciseList(newList.get(0).getWorkoutID()).size();

        assertEquals(2, listSize);

    }
}
