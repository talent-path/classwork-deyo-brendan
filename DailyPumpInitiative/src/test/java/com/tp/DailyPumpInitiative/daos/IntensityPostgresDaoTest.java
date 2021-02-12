package com.tp.DailyPumpInitiative.daos;

import com.tp.DailyPumpInitiative.models.Exercise;
import com.tp.DailyPumpInitiative.models.Intensity;
import com.tp.DailyPumpInitiative.models.Workout;
import com.tp.DailyPumpInitiative.persistence.IntensityPostgresDao;
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
    }

    @Test
    public void getIntensityValuesByIntensityIDGoldenPath()
    {
        throw new UnsupportedOperationException();
    }

    @Test
    public void addWorkoutByIntensityGoldenPath()
    {
        Intensity newIntensity = new Intensity();
        newIntensity.setIntensityID(3);
        newIntensity.setIntensityName("Heavy");
        newIntensity.setIntensityDuration("60 Minutes");
        newIntensity.setIntensityDescription("Stuff");

        Workout newWorkout = new Workout();

        newWorkout.setWorkoutID(1);
        newWorkout.setIntensityID(3);
        newWorkout.setWorkoutName("Upper Body Push (Chest / Shoulders)");
        newWorkout.setWorkoutDescription("Description");

        List<Workout> newList = new ArrayList<>();

        newList.add(newWorkout);

        toTest.getWorkoutList(newIntensity.getIntensityID());

        assertEquals(3, newIntensity.getIntensityID());
        assertEquals("Heavy", newIntensity.getIntensityName());
        assertEquals("60 Minutes", newIntensity.getIntensityDuration());
        assertEquals("Stuff", newIntensity.getIntensityDescription());

        assertEquals(1, newWorkout.getWorkoutID());
        assertEquals(3, newWorkout.getIntensityID());

    }


}
