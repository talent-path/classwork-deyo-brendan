package com.tp.DailyPumpInitiative.persistence;


import com.tp.DailyPumpInitiative.models.Exercise;
import com.tp.DailyPumpInitiative.models.Workout;
import com.tp.DailyPumpInitiative.persistence.mappers.ExerciseMapper;
import com.tp.DailyPumpInitiative.persistence.mappers.IntegerMapper;
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
        List<Workout> toReturn = template.query("SELECT \"workoutID\", \"intensityID\", \"name\", \"description\", \"completed\" \n" +
                "FROM \"Workout\"\n" +
                "WHERE (\"workoutID\" = '" + workoutID + "');", new WorkoutMapper() );

        if (toReturn == null)
            return null;

        return toReturn.get(0);
    }

    @Override
    public List<Exercise> getExerciseList(Integer workoutID)
    {
        List<Exercise> toReturn = template.query("SELECT *\n" +
                "FROM \"Exercise\"\n" +
                "INNER JOIN \"Workout\" ON \"Exercise\".\"workoutID\" = \"Workout\".\"workoutID\"\n" +
                "WHERE \"Exercise\".\"workoutID\" = '" + workoutID + "';", new ExerciseMapper());

        if(toReturn.isEmpty())
            return null;

        return toReturn;

    }

    @Override
    public void deleteWorkoutByID(Integer workoutID) {
        template.execute("DELETE from \"Workout\" where \"workoutID\" = " + workoutID + ";");
    }

    @Override
    public Workout addWorkoutToList(Workout toAdd) {
        Integer workoutID = template.queryForObject("INSERT into \"Workout\" (\"intensityID\", \"name\", \"description\", \"completed\")\n" +
                        "VALUES (?, ?, ?, ?);", new IntegerMapper("workoutID"),
                toAdd.getIntensityID(),
                toAdd.getWorkoutName(),
                toAdd.getWorkoutDescription(),
                toAdd.isComplete());

        toAdd.setWorkoutID(workoutID);

        return toAdd;

    }

}
