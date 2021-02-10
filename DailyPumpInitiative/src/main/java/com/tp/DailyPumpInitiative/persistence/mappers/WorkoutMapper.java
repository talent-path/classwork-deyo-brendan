package com.tp.DailyPumpInitiative.persistence.mappers;

import com.tp.DailyPumpInitiative.models.Workout;
import org.springframework.jdbc.core.RowMapper;

import java.sql.ResultSet;
import java.sql.SQLException;

public class WorkoutMapper implements RowMapper<Workout> {

    @Override
    public Workout mapRow(ResultSet resultSet, int i) throws SQLException {

        Workout toReturn = new Workout();
        toReturn.setWorkoutID(resultSet.getInt("workoutID"));
        toReturn.setIntensityID(resultSet.getInt("intensityID"));
        toReturn.setWorkoutName(resultSet.getString("name"));
        toReturn.setWorkoutDescription(resultSet.getString("description"));
        toReturn.setComplete(resultSet.getBoolean("completed"));

        return toReturn;
    }
}
