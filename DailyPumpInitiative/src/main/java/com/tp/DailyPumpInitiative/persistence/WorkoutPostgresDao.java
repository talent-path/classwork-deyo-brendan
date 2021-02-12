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
        List<Exercise> toReturn = template.query("SELECT \"Exercise\".\"exerciseID\", \"Exercise\".\"name\", \"Exercise\".\"description\", \"Exercise\".\"bodyweight\",\n" +
                "\"Exercise\".\"weight\", \"Exercise\".\"reps\", \"Exercise\".\"completed\", \"Exercise\".\"sets\"\n" +
                "FROM \"Exercise\"\n" +
                "INNER JOIN \"Workout\" ON \"Exercise\".\"workoutID\" = \"Workout\".\"workoutID\"\n" +
                "WHERE (\"Exercise\".\"workoutID\" = '" + workoutID + "');", new ExerciseMapper());

        if(toReturn.isEmpty())
            return null;

        return toReturn;

    }

}
