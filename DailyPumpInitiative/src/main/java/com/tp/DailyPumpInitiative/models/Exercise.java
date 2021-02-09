package com.tp.DailyPumpInitiative.models;

public class Exercise {

    private String exerciseName;
    private boolean bodyweight;
    private boolean isComplete;
    private Integer exerciseWeight;
    private Integer exerciseReps;
    private Integer workoutID;

    public Exercise()
    {

    }

    public Exercise (String exerciseName, Integer exerciseWeight, Integer exerciseReps, Integer workoutID
        , boolean bodyweight, boolean isComplete)
    {
        this.bodyweight = bodyweight;
        this.isComplete = isComplete;
        this.exerciseName = exerciseName;
        this.exerciseWeight = exerciseWeight;
        this.exerciseReps = exerciseReps;
        this.workoutID = workoutID;
    }

    public Exercise (Exercise that)
    {
        this.isComplete = that.isComplete;
        this.bodyweight = that.bodyweight;
        this.exerciseName = that.exerciseName;
        this.exerciseWeight = that.exerciseWeight;
        this.exerciseReps = that.exerciseReps;
    }

    public String getExerciseName() {
        return exerciseName;
    }

    public void setExerciseName(String exerciseName) {
        this.exerciseName = exerciseName;
    }

    public Integer getExerciseWeight() {
        return exerciseWeight;
    }

    public void setExerciseWeight(Integer exerciseWeight) {
        this.exerciseWeight = exerciseWeight;
    }

    public Integer getExerciseReps() {
        return exerciseReps;
    }

    public void setExerciseReps(Integer exerciseReps) {
        this.exerciseReps = exerciseReps;
    }

    public Integer getWorkoutID() {
        return workoutID;
    }

    public void setWorkoutID(Integer workoutID) {
        this.workoutID = workoutID;
    }

    public boolean isBodyweight() {
        return bodyweight;
    }

    public void setBodyweight(boolean bodyweight) {
        this.bodyweight = bodyweight;
    }

    public boolean isComplete() {
        return isComplete;
    }

    public void setComplete(boolean complete) {
        isComplete = complete;
    }
}
