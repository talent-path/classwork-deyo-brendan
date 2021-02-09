package com.tp.DailyPumpInitiative.models;

public class WorkoutModel {

    private Integer repNum;
    private Integer weightNum;
    private String[] exerciseNames;
    private String workoutTitle;
    private Integer workoutID;

    public WorkoutModel()
    {

    }

    public WorkoutModel(Integer workoutID, String workoutTitle, String[] exerciseNames)
    {
        this.workoutID = workoutID;
        this.workoutTitle = workoutTitle;
        this.exerciseNames = exerciseNames;
    }

    public WorkoutModel(WorkoutModel that)
    {
        this.workoutID = that.workoutID;
        this.workoutTitle = that.workoutTitle;
        this.exerciseNames = new String[exerciseNames.length];
        for (int i = 0; i < exerciseNames.length; i++)
        {
            this.exerciseNames[i] = that.exerciseNames[i];
        }
    }

    public Integer getRepNum() {
        return repNum;
    }

    public void setRepNum(Integer repNum) {
        this.repNum = repNum;
    }

    public Integer getWeightNum() {
        return weightNum;
    }

    public void setWeightNum(Integer weightNum) {
        this.weightNum = weightNum;
    }

    public String[] getExerciseNames() {
        return exerciseNames;
    }

    public void setExerciseNames(String[] exerciseNames) {
        this.exerciseNames = exerciseNames;
    }

    public String getWorkoutTitle() {
        return workoutTitle;
    }

    public void setWorkoutTitle(String workoutTitle) {
        this.workoutTitle = workoutTitle;
    }

    public Integer getWorkoutID() {
        return workoutID;
    }

    public void setWorkoutID(Integer workoutID) {
        this.workoutID = workoutID;
    }
}
