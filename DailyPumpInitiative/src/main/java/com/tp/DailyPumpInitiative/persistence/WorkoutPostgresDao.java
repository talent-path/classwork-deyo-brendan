package com.tp.DailyPumpInitiative.persistence;


import com.tp.DailyPumpInitiative.models.Workout;
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
        Workout toReturn = new Workout();

        toReturn = template.queryForObject("SELECT \"" + workoutID + "\", \"intensityID\", \"name\", \"description\", " +
                "\"completed\" FROM \"Workout\";", new WorkoutMapper() );

        return toReturn;
    }

    @Override
    public List<Workout> getWorkoutList(Integer intensityID)
    {
        List<Workout> toReturn = new ArrayList<>();

        toReturn.add(template.queryForObject("SELECT int.\"intensityID\", " +
                "int.\"name\", wk.\"name\" FROM \"Intensity\" int, \"Workout\" wk WHERE (int.\"intensityID\" " +
                "= wk.\"" + intensityID + "\"); ", new WorkoutMapper()) );

        return toReturn;
    }






}
