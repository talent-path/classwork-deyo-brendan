package com.tp.DailyPumpInitiative.persistence;


import com.tp.DailyPumpInitiative.models.Intensity;
import com.tp.DailyPumpInitiative.models.Workout;
import com.tp.DailyPumpInitiative.persistence.mappers.IntensityMapper;
import com.tp.DailyPumpInitiative.persistence.mappers.WorkoutMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Profile;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

@Component
@Profile({"production", "daoTesting"})
public class IntensityPostgresDao implements IntensityDao {

    @Autowired
    private JdbcTemplate template;

    @Override
    public Intensity getIntensityByID(Integer intensityID)
    {
        List<Intensity> toReturn = template.query("SELECT \"intensityID\", \"name\", \"time\", \"description\" \n" +
                "FROM \"Intensity\"\n" +
                "WHERE \"intensityID\" = '" + intensityID + "';", new IntensityMapper() );

        if (toReturn.isEmpty())
            return null;

        return toReturn.get(0);
    }

    @Override
    public List<Intensity> getIntensityList()
    {
        List<Intensity> toReturn = template.query("SELECT * FROM \"Intensity\";", new IntensityMapper());

        return toReturn;
    }

    @Override
    public List<Workout> getWorkoutList(Integer intensityID)
    {
        List<Workout> toReturn = template.query("SELECT *\n" +
                "FROM \"Workout\"\n" +
                "INNER JOIN \"Intensity\" ON \"Workout\".\"intensityID\" = \"Workout\".\"intensityID\"\n" +
                "WHERE \"Workout\".\"intensityID\" = '" + intensityID + "';", new WorkoutMapper() );

        if (toReturn.isEmpty())
            return null;

        return toReturn;
    }

}
