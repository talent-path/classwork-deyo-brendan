package com.tp.DailyPumpInitiative.persistence;

import com.tp.DailyPumpInitiative.models.Exercise;
import com.tp.DailyPumpInitiative.persistence.mappers.ExerciseMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Profile;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

@Component
@Profile({"production", "daoTesting"})
public class ExercisePostgresDao implements ExerciseDao {

    @Autowired
    private JdbcTemplate template;

    @Override
    public Exercise getExerciseByID(Integer exerciseID)
    {
        Exercise toReturn = new Exercise();

        toReturn = template.queryForObject("SELECT \"" + exerciseID + "\", \"name\", \"description\", " +
                "\"bodyweight\", \"weight\", \"reps\", \"completed\", \"sets\" from \"Exercise\";"
                    , new ExerciseMapper() );

        return toReturn;
    }

    @Override
    public List<Exercise> getExerciseList(Integer workoutID)
    {
        List<Exercise> toReturn = new ArrayList<>();

        toReturn.add(template.queryForObject("SELECT wk.\"" + workoutID + "\", ex.\"exerciseID\", wk.\"name\", " +
                "ex.\"name\" FROM \"Workout\" wk, \"Exercise\" ex WHERE " +
                "(wk.\"workoutID\" = ex.\"workoutID\");", new ExerciseMapper()) );

        return toReturn;

    }




}
