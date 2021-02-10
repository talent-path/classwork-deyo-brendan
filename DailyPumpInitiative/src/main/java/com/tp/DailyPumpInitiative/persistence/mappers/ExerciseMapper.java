package com.tp.DailyPumpInitiative.persistence.mappers;

import com.tp.DailyPumpInitiative.models.Exercise;
import org.springframework.jdbc.core.RowMapper;

import java.sql.ResultSet;
import java.sql.SQLException;

public class ExerciseMapper implements RowMapper<Exercise> {

    @Override
    public Exercise mapRow(ResultSet resultSet, int i) throws SQLException {

        Exercise toReturn = new Exercise();

        toReturn.setWorkoutID(resultSet.getInt("workoutID"));
        toReturn.setExerciseID(resultSet.getInt("exerciseID"));
        toReturn.setExerciseName(resultSet.getString("name"));
        toReturn.setExerciseDesc(resultSet.getString("description"));
        toReturn.setBodyweight(resultSet.getBoolean("bodyweight"));
        toReturn.setExerciseWeight(resultSet.getInt("weight"));
        toReturn.setExerciseReps(resultSet.getString("reps"));
        toReturn.setComplete(resultSet.getBoolean("completed"));

        return toReturn;
    }

}
