package com.tp.DailyPumpInitiative.persistence;

import com.tp.DailyPumpInitiative.models.Exercise;
import com.tp.DailyPumpInitiative.models.Workout;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.RowMapper;
import org.springframework.stereotype.Component;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.List;

@Component
public class PostgresDao implements DailyPumpDao {

    @Autowired
    JdbcTemplate template;

    @Override
    public Workout getWorkoutByID(Integer workoutID)
    {
        Workout thisWorkout = template.queryForObject("SELECT \"workoutID\", \"intensityID\", \"name\", " +
                "\"completed\" from public.\"Workout\";", new WorkoutMapper() );

        return thisWorkout;
    }

    @Override
    public Workout getExerciseList(List<Exercise> exerciseList)
    {
        List<Exercise> newList = template.query("")
    }

    class WorkoutMapper implements RowMapper<Workout>
    {

        @Override
        public Workout mapRow(ResultSet resultSet, int i) throws SQLException {
            Workout toReturn = new Workout();
            toReturn.setWorkoutID(resultSet.getInt("workoutID"));
            toReturn.setIntensityID(resultSet.getInt("intensityID"));
            toReturn.setWorkoutName(resultSet.getString("name"));
            toReturn.setComplete(resultSet.getBoolean("completed"));

            return toReturn;
        }
    }


}
