package com.tp.DailyPumpInitiative.daos;

import com.tp.DailyPumpInitiative.models.Exercise;
import com.tp.DailyPumpInitiative.models.Intensity;
import com.tp.DailyPumpInitiative.models.Workout;
import com.tp.DailyPumpInitiative.persistence.IntensityPostgresDao;
import com.tp.DailyPumpInitiative.persistence.mappers.IntensityMapper;
import com.tp.DailyPumpInitiative.persistence.mappers.WorkoutMapper;
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
public class IntensityPostgresDaoTest {

    @Autowired
    IntensityPostgresDao toTest;

    @Autowired
    JdbcTemplate template;

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

    }

    @Test
    public void getIntensityValuesByIntensityIDGoldenPath()
    {
        Intensity newIntensity = template.query("SELECT * from \"Intensity\" WHERE \"intensityID\" " +
                        "= '"+ 1 +"';", new IntensityMapper ()).get(0);

        assertEquals(newIntensity.getIntensityID(), toTest.getIntensityByID(1).getIntensityID());
    }

    @Test
    public void getIntensityListGoldenPath()
    {

        assertEquals(1, toTest.getIntensityList().get(0).getIntensityID());
        assertEquals(2, toTest.getIntensityList().get(1).getIntensityID());
        assertEquals(3, toTest.getIntensityList().get(2).getIntensityID());
    }

    @Test
    public void getWorkoutByIntensityIDGoldenPath()
    {

        Workout newWorkout = template.query("SELECT * from \"Workout\" WHERE (\"intensityID\" = " + 1 + ");"
        , new WorkoutMapper ()).get(0);

        assertEquals(newWorkout.getIntensityID(), toTest.getWorkoutList(1).get(0).getIntensityID());

//        Intensity newIntensity = new Intensity();
//        newIntensity.setIntensityID(3);
//        newIntensity.setIntensityName("Heavy");
//        newIntensity.setIntensityDuration("60 Minutes");
//        newIntensity.setIntensityDescription("Stuff");
//
//        Workout newWorkout = new Workout();
//
//        newWorkout.setWorkoutID(1);
//        newWorkout.setIntensityID(3);
//        newWorkout.setWorkoutName("Upper Body Push (Chest / Shoulders)");
//        newWorkout.setWorkoutDescription("Description");
//
//        List<Workout> newList = new ArrayList<>();
//
//        newList.add(newWorkout);
//
//        toTest.getWorkoutList(newIntensity.getIntensityID());
//
//        assertEquals(3, newIntensity.getIntensityID());
//        assertEquals("Heavy", newIntensity.getIntensityName());
//        assertEquals("60 Minutes", newIntensity.getIntensityDuration());
//        assertEquals("Stuff", newIntensity.getIntensityDescription());
//
//        assertEquals(1, newWorkout.getWorkoutID());
//        assertEquals(3, newWorkout.getIntensityID());

    }


}
