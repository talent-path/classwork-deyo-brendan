package com.tp.DailyPumpInitiative.daos;

import com.tp.DailyPumpInitiative.models.Exercise;
import com.tp.DailyPumpInitiative.persistence.ExercisePostgresDao;
import com.tp.DailyPumpInitiative.persistence.mappers.BooleanMapper;
import com.tp.DailyPumpInitiative.persistence.mappers.ExerciseMapper;
import com.tp.DailyPumpInitiative.persistence.mappers.WorkoutMapper;
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
    ExercisePostgresDao toTest;

    @Autowired
    JdbcTemplate template;

    private List<Exercise> newList = new ArrayList<>();
    private Exercise newExercise = new Exercise();

    @BeforeEach
    public void setup()
    {
        template.update("TRUNCATE \"Intensity\", \"Workout\", \"Exercise\" RESTART IDENTITY;");

        // insert intensity table
        template.update("INSERT INTO \"Intensity\" (\"name\", \"time\", \"description\")\n" +
                "VALUES ('Light', '20 Minutes', 'Desc1'),\n" +
                "('Moderate', '40 Minutes', 'Desc2'),\n" +
                "('Heavy', '60 Minutes', 'Desc 3');");

        // insert workout table
        template.update("INSERT INTO \"Workout\" (\"intensityID\", \"name\", \"description\", \"completed\")\n" +
                "VALUES ('1', 'HIIT 1', 'Desc1', 'false'),\n" +
                "('1', 'HIIT 2', 'Desc2', 'false'),\n" +
                "('1', 'HIIT 3', 'Desc3', 'true'),\n" +
                "('2', 'Moderate 1', 'Desc1', 'false'),\n" +
                "('2', 'Moderate 2', 'Desc2', 'false'),\n" +
                "('2', 'Moderate 3', 'Desc3', 'true'),\n" +
                "('3', 'Heavy 1', 'Desc1', 'false'),\n" +
                "('3', 'Heavy 2', 'Desc2', 'true'),\n" +
                "('3', 'Heavy 3', 'Desc3', 'false');");

        // insert exercise table
        template.update("INSERT INTO \"Exercise\" (\"workoutID\", \"exerciseID\", \"name\", \"description\", \"bodyweight\", \"weight\", \"reps\", \"completed\", \"sets\")\n" +
                "VALUES ('3', '1', 'Front Squat', 'Desc1', 'false', '150', 'Till Failure', 'false', '6'),\n" +
                "\t\t('3', '2', 'Back Squat', 'Desc2', 'false', '160', '5 - 8', 'true', '3'),\n" +
                "\t\t('3', '3', 'Lunges', 'Desc3', 'false', '80', '25', 'false', '5');");

//        newExercise = new Exercise("Front Squats", 150, "5 - 7", 3, false
//                , false, 1, "Desc1", 5);
//
//        newList.add(newExercise);
//
//        newExercise = new Exercise("Back Squats", 160, "5 - 7", 3, false
//                , true, 2, "Desc2", 4);
//
//        newList.add(newExercise);
//
//        newExercise = new Exercise("Lunges", 120, "6 - 7", 3, false
//                , false, 3, "Desc3", 5);
//
//        newList.add(newExercise);

    }

    @Test
    public void getExerciseByExerciseIDGoldenPath()
    {

        newExercise = template.query("SELECT * FROM \"Exercise\" WHERE (\"exerciseID\" = '"+ 1 +"');",
                new ExerciseMapper() ).get(0);

        assertEquals(newExercise.getExerciseID(), toTest.getExerciseByID(1).getExerciseID());

//        assertEquals(1, newList.get(0).getExerciseID());
//        assertEquals(2, newList.get(1).getExerciseID());
//        assertEquals(3, newList.get(2).getExerciseID());

    }

    @Test
    public void getIsExerciseCompletedByExerciseIDGoldenPath()
    {

        assertFalse(toTest.isCompleted(3));
        assertTrue(toTest.isCompleted(2));
        assertFalse(toTest.isCompleted(1));

//        assertFalse(newList.get(0).isComplete());
//        assertTrue(newList.get(1).isComplete());
//        assertFalse(newList.get(2).isComplete());
    }

}
