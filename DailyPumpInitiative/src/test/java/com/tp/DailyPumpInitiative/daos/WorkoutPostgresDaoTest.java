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

@SpringBootTest
@ActiveProfiles("daoTesting")
public class WorkoutPostgresDaoTest {

    @Autowired
    WorkoutPostgresDao workoutDao;

    @Autowired
    JdbcTemplate template;


    @BeforeEach
    public void setup()
    {
        template.update("TRUNCATE \"Intensity\", \"Workout\", \"Exercise\" RESTART IDENTITY;");
    }

    @Test
    public void getExerciseListByWorkoutIDGoldenPath()
    {
        Workout newWorkout = new Workout(1, 3, "Upper Body Pull",
                "Back & Arms");

        
    }
}
