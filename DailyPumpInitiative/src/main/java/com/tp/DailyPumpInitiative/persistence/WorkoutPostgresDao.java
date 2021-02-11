package com.tp.DailyPumpInitiative.persistence;


import com.tp.DailyPumpInitiative.models.Exercise;
import com.tp.DailyPumpInitiative.models.Workout;
import com.tp.DailyPumpInitiative.persistence.mappers.ExerciseMapper;
import com.tp.DailyPumpInitiative.persistence.mappers.WorkoutMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Profile;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

@Component
@Profile({"production", "daoTesting"})
public class WorkoutPostgresDao implements WorkoutDao {


    @Autowired
    private JdbcTemplate template;

    @Override
    public Workout getWorkoutByID(Integer workoutID)
    {
        List<Workout> toReturn = template.query("SELECT \"" + workoutID + "\", \"intensityID\", \"name\", \"description\", " +
                "\"completed\" FROM \"Workout\";", new WorkoutMapper() );

        if (toReturn == null)
            return null;

        return toReturn.get(0);
    }

    @Override
    public List<Exercise> getExerciseList(Integer workoutID)
    {
        List<Exercise> toReturn = template.query("SELECT wk.\"" + workoutID + "\", ex.\"exerciseID\", wk.\"name\", " +
                "ex.\"name\" FROM \"Workout\" wk, \"Exercise\" ex WHERE " +
                "(wk.\"" + workoutID + "\" = ex.\"" + workoutID + "\");", new ExerciseMapper());

        if(toReturn.isEmpty())
            return null;

        return toReturn;

    }

}
