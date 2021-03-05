package com.tp.DailyPumpInitiative.persistence;

import com.tp.DailyPumpInitiative.models.Exercise;
import com.tp.DailyPumpInitiative.persistence.mappers.BooleanMapper;
import com.tp.DailyPumpInitiative.persistence.mappers.ExerciseMapper;
import com.tp.DailyPumpInitiative.persistence.mappers.IntegerMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Profile;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Component;

import java.util.List;

@Component
@Profile({"production", "daoTesting"})
public class ExercisePostgresDao implements ExerciseDao {

    @Autowired
    private JdbcTemplate template;

    @Override
    public Exercise getExerciseByID(Integer exerciseID)
    {
        List<Exercise> toReturn = template.query("SELECT \"workoutID\", \"exerciseID\", \"name\", \"description\", \"bodyweight\", \"weight\", \"reps\", \"completed\", \"sets\"\n" +
                        "FROM \"Exercise\"\n" +
                        "WHERE (\"exerciseID\" = '" + exerciseID + "')"
                    , new ExerciseMapper() );

        if (toReturn.isEmpty())
            return null;

        return toReturn.get(0);
    }

    @Override
    public boolean isCompleted(Integer exerciseID)
    {
        List<Boolean> toReturn = template.query("SELECT \"workoutID\", \"exerciseID\", \"name\", \"description\", \"bodyweight\", \"weight\", \"reps\", \"completed\", \"sets\"\n" +
                "FROM \"Exercise\"\n" +
                "WHERE (\"exerciseID\" = '" + exerciseID + "')", new BooleanMapper());

        if (toReturn.isEmpty())
            return false;

        return toReturn.get(0);
    }

    @Override
    public void deleteExerciseByID(Integer exerciseID)
    {
        template.execute("DELETE from \"Exercise\" where \"exerciseID\" = " + exerciseID + ";");
    }

    @Override
    public Exercise addExerciseToList(Exercise toAdd)
    {
        Integer exerciseID = template.queryForObject("INSERT into \"Exercise\" (\"exerciseID\"," +
                " \"workoutID\", \"name\", \"description\", \"bodyweight\", \"weight\", \"reps\", \"completed\", \"sets\")\n" +
                "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?);",
                new IntegerMapper("exerciseID"),
                toAdd.getWorkoutID(),
                toAdd.getExerciseName(),
                toAdd.getExerciseDesc(),
                toAdd.isBodyweight(),
                toAdd.getExerciseWeight(),
                toAdd.getExerciseReps(),
                toAdd.isComplete(),
                toAdd.getExerciseSets());

        toAdd.setExerciseID(exerciseID);

        return toAdd;
    }

}
