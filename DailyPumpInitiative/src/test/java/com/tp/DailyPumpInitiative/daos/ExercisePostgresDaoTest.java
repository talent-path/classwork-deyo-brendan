package com.tp.DailyPumpInitiative.daos;


import com.tp.DailyPumpInitiative.persistence.ExercisePostgresDao;
import org.junit.jupiter.api.BeforeEach;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.test.context.ActiveProfiles;

@SpringBootTest
@ActiveProfiles("daoTesting")
public class ExercisePostgresDaoTest {

    @Autowired
    ExercisePostgresDao exerciseDao;

    @Autowired
    JdbcTemplate template;

    @BeforeEach
    public void setup()
    {
        template.update("TRUNCATE \"Intensity\", \"Workout\", \"Exercise\" RESTART IDENTITY;");
    }
}
