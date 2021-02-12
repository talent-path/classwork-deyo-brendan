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

    private Workout newWorkout = new Workout(1, 3, "Upper Body Pull",
            "Back & Arms");

    private List<Exercise> newList = new ArrayList<>();

    private Exercise newExercise = new Exercise();

    @BeforeEach
    public void setup()
    {
        template.update("TRUNCATE \"Intensity\", \"Workout\", \"Exercise\" RESTART IDENTITY;");

        newExercise = new Exercise("Front Squats", 150, "5 - 7", 3, false
                , false, 1, "Desc1", 5);

        newList.add(newExercise);

        newExercise = new Exercise("Back Squats", 160, "5 - 7", 3, false
                , true, 2, "Desc2", 4);

        newList.add(newExercise);

        newExercise = new Exercise("Lunges", 120, "6 - 7", 3, false
                , false, 3, "Desc3", 5);

        newList.add(newExercise);
    }

    @Test
    public void getWorkoutByWorkoutIDGoldenPath()
    {
        assertEquals(3, newWorkout.getWorkoutID());
        assertEquals(1, newWorkout.getIntensityID());
        assertEquals("Upper Body Pull", newWorkout.getWorkoutName());
        assertEquals("Back & Arms", newWorkout.getWorkoutDescription());
    }

    @Test
    public void getExerciseListByWorkoutIDGoldenPath()
    {
        newWorkout.setExerciseList(newList);

        int workoutID = newWorkout.getExerciseList().get(0).getWorkoutID();
        int size = newWorkout.getExerciseList().size();

        assertEquals(3, workoutID);
        assertEquals(3, size);

    }
}
