package com.tp.DailyPumpInitiative.persistence;

import com.tp.DailyPumpInitiative.models.Exercise;
import com.tp.DailyPumpInitiative.models.Workout;
import com.tp.DailyPumpInitiative.persistence.mappers.ExerciseMapper;
import com.tp.DailyPumpInitiative.persistence.mappers.WorkoutMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.RowMapper;
import org.springframework.stereotype.Component;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.List;

@Component
public class PostgresDao implements WorkoutDao, ExerciseDao {

    @Autowired
    JdbcTemplate template;

    @Override
    public Workout getWorkoutByID(Integer workoutID, Integer intensityID)
    {
        Workout thisWorkout = template.queryForObject("SELECT \"workoutID\", \"intensityID\", \"name\", " +
                "\"completed\" from public.\"Workout\";", new WorkoutMapper() );

        return thisWorkout;
    }

    @Override
    public List<Exercise> getExerciseList()
    {


        List<Exercise> newList = template.query("SELECT ex.\"exerciseID\", ex.\"name\" FROM \"Exercise\" ex, " +
                "\"Workout\" w WHERE ex.\"workoutID\" = w.\"workoutID\";", new ExerciseMapper() );


        return newList;
    }

    @Override
    public boolean getCompleted()
    {
        boolean isComplete = template.query()
    }

}
