package com.tp.DailyPumpInitiative.daos;

import com.tp.DailyPumpInitiative.models.Exercise;
import com.tp.DailyPumpInitiative.persistence.ExercisePostgresDao;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.test.context.ActiveProfiles;

import static org.junit.jupiter.api.Assertions.*;

import java.util.ArrayList;
import java.util.List;

@SpringBootTest
@ActiveProfiles("daoTesting")
public class ExercisePostgresDaoTest {

    @Autowired
    ExercisePostgresDao exerciseDao;

    @Autowired
    JdbcTemplate template;

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
    public void getExerciseByExerciseIDGoldenPath()
    {

        assertEquals(1, newList.get(0).getExerciseID());
        assertEquals(2, newList.get(1).getExerciseID());
        assertEquals(3, newList.get(2).getExerciseID());

    }

    @Test
    public void getIsExerciseCompletedByExerciseIDGoldenPath()
    {
        assertFalse(newList.get(0).isComplete());
        assertTrue(newList.get(1).isComplete());
        assertFalse(newList.get(2).isComplete());
    }

}
