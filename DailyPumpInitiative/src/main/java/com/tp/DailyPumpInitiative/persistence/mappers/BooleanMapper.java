package com.tp.DailyPumpInitiative.persistence.mappers;

import org.springframework.jdbc.core.RowMapper;

import java.sql.ResultSet;
import java.sql.SQLException;

public class BooleanMapper implements RowMapper<Boolean> {

        @Override
        public Boolean mapRow(ResultSet resultSet, int i) throws SQLException {

            Boolean toReturn = resultSet.getBoolean("completed");

            return toReturn;

        }
}
