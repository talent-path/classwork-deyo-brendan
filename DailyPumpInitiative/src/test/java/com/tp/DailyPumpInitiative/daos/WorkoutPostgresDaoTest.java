package com.tp.DailyPumpInitiative.daos;


import com.tp.DailyPumpInitiative.models.Exercise;
import com.tp.DailyPumpInitiative.models.Workout;
import com.tp.DailyPumpInitiative.persistence.WorkoutPostgresDao;
import com.tp.DailyPumpInitiative.persistence.mappers.ExerciseMapper;
import com.tp.DailyPumpInitiative.persistence.mappers.WorkoutMapper;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.test.context.ActiveProfiles;

import java.util.ArrayList;
import java.util.List;

import static org.junit.jupiter.api.Assertions.assertEquals;

@SpringBootTest
@ActiveProfiles("daoTesting")
public class WorkoutPostgresDaoTest {

    @Autowired
    WorkoutPostgresDao toTest;

    @Autowired
    JdbcTemplate template;

    private List<Workout> workoutList = new ArrayList<>();

    private Workout newWorkout = new Workout();

    private List<Exercise> exerciseList = new ArrayList<>();

    private Exercise newExercise = new Exercise();

    @BeforeEach
    public void setup()
    {
        template.update("TRUNCATE \"Intensity\", \"Workout\", \"Exercise\" RESTART IDENTITY;");

        // insert intensity table
        template.update("INSERT INTO \"Intensity\" (\"name\", \"time\", \"description\")\n" +
                "VALUES ('Light', '20 Minutes', 'Desc1'),\n" +
                "('Moderate', '40 Minutes', 'Desc2'),\n" +
                "('Heavy', '60 Minutes', 'Desc 3');");

        // insert workout table
        template.update("INSERT INTO \"Workout\" (\"intensityID\", \"name\", \"description\", \"completed\")\n" +
                "VALUES ('1', 'HIIT 1', 'Desc1', 'false'),\n" +
                "('1', 'HIIT 2', 'Desc2', 'false'),\n" +
                "('1', 'HIIT 3', 'Desc3', 'true'),\n" +
                "('2', 'Moderate 1', 'Desc1', 'false'),\n" +
                "('2', 'Moderate 2', 'Desc2', 'false'),\n" +
                "('2', 'Moderate 3', 'Desc3', 'true'),\n" +
                "('3', 'Heavy 1', 'Desc1', 'false'),\n" +
                "('3', 'Heavy 2', 'Desc2', 'true'),\n" +
                "('3', 'Heavy 3', 'Desc3', 'false');");

        // insert exercise table
        template.update("INSERT INTO \"Exercise\" (\"workoutID\", \"exerciseID\", \"name\", \"description\", \"bodyweight\", \"weight\", \"reps\", \"completed\", \"sets\")\n" +
                "VALUES ('3', '1', 'Front Squat', 'Desc1', 'false', '150', 'Till Failure', 'false', '6'),\n" +
                "\t\t('3', '2', 'Back Squat', 'Desc2', 'false', '160', '5 - 8', 'true', '3'),\n" +
                "\t\t('3', '3', 'Lunges', 'Desc3', 'false', '80', '25', 'false', '5');");

//        newWorkout = new Workout(1, 1, "HIIT Circuit",
//                "AMRAP");
//        workoutList.add(newWorkout);
//
//        newWorkout = new Workout(2, 2, "Upper Body Push",
//                "Chest & Shoulders");
//        workoutList.add(newWorkout);
//
//        newWorkout = new Workout(3, 3, "Full Lower Body",
//                "Pump the legs!");
//        workoutList.add(newWorkout);
//
//        newExercise = new Exercise("Front Squats", 150, "5 - 7", 3, false
//                , false, 1, "Desc1", 5);
//        exerciseList.add(newExercise);
//
//        newExercise = new Exercise("Back Squats", 160, "5 - 7", 3, false
//                , true, 2, "Desc2", 4);
//        exerciseList.add(newExercise);
//
//        newExercise = new Exercise("Lunges", 120, "6 - 7", 3, false
//                , false, 3, "Desc3", 5);
//        exerciseList.add(newExercise);
    }

    @Test
    public void getWorkoutByWorkoutIDGoldenPath()
    {
//        // check getter and setter's
//        assertEquals(3, newWorkout.getWorkoutID());
//        assertEquals(1, newWorkout.getIntensityID());
//        assertEquals("Upper Body Pull", newWorkout.getWorkoutName());
//        assertEquals("Back & Arms", newWorkout.getWorkoutDescription());

        newWorkout = template.query("SELECT * FROM \"Workout\" WHERE (\"workoutID\" = '"+ 1 +"');",
                new WorkoutMapper() ).get(0);

        assertEquals(newWorkout.getWorkoutID(), toTest.getWorkoutByID(1).getWorkoutID());

    }

    @Test
    public void getExerciseListByWorkoutIDGoldenPath()
    {
//        newWorkout.setExerciseList(exerciseList);
//
//        int workoutID = newWorkout.getExerciseList().get(0).getWorkoutID();
//        int size = newWorkout.getExerciseList().size();
//
//        assertEquals(3, workoutID);
//        assertEquals(3, size);

        exerciseList = template.query("SELECT * FROM \"Exercise\" WHERE (\"workoutID\" = '" + 3 + "');",
                new ExerciseMapper() );
        int exerciseID = exerciseList.get(0).getWorkoutID();

        assertEquals(exerciseID, toTest.getExerciseList(3).get(0).getWorkoutID());

    }
}
