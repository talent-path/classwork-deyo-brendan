package com.tp.DailyPumpInitiative.persistence.mappers;
import com.tp.DailyPumpInitiative.models.Intensity;
import org.springframework.jdbc.core.RowMapper;

import java.sql.ResultSet;
import java.sql.SQLException;

public class IntensityMapper implements RowMapper<Intensity> {

    @Override
    public Intensity mapRow(ResultSet resultSet, int i) throws SQLException {

        Intensity toReturn = new Intensity();

        toReturn.setIntensityID(resultSet.getInt("intensityID"));
        toReturn.setIntensityName(resultSet.getString("name"));
        toReturn.setIntensityDuration(resultSet.getString("time"));
        toReturn.setIntensityDescription(resultSet.getString("description"));

        return toReturn;
    }

}
