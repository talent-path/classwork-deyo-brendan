package com.tp.DailyPumpInitiative.models;

import java.util.ArrayList;
import java.util.List;

public class Workout {

    private List<Exercise> exerciseList = new ArrayList<>();
    private List<Workout> workoutList = new ArrayList<>();
    private String workoutName;
    private Integer intensityID;
    private Integer workoutID;
    private boolean isComplete;
    private String workoutDescription;

    public Workout()
    {

    }

    public Workout(Integer intensityID, Integer workoutID, String workoutTitle,
                   List<Exercise> exerciseList, List<Workout> workoutList, boolean isComplete,
                   String workoutDescription)
    {
        this.workoutDescription = workoutDescription;
        this.workoutList = workoutList;
        this.workoutID = workoutID;
        this.intensityID = intensityID;
        this.workoutName = workoutTitle;
        this.exerciseList = exerciseList;
        this.isComplete = isComplete;
    }

//    public Workout(Workout that)
//    {
//        this.isComplete = that.isComplete;
//        this.workoutID = that.workoutID;
//        this.intensityID = that.intensityID;
//        this.workoutName = that.workoutName;
//        this.exerciseList = that.exerciseList;
//    }
    public List<Workout> getWorkoutList() {
        return workoutList;
    }

    public void setWorkoutList(List<Workout> workoutList) {
        this.workoutList = workoutList;
    }

    public List<Exercise> getExerciseList() {
        return exerciseList;
    }

    public void setExerciseList(List<Exercise> exerciseList) {
        this.exerciseList = exerciseList;
    }

    public String getWorkoutName() {
        return workoutName;
    }

    public void setWorkoutName(String workoutName) {
        this.workoutName = workoutName;
    }

    public Integer getIntensityID() {
        return intensityID;
    }

    public void setIntensityID(Integer intensityID) {
        this.intensityID = intensityID;
    }

    public Integer getWorkoutID() {
        return workoutID;
    }

    public void setWorkoutID(Integer workoutID) {
        this.workoutID = workoutID;
    }

    public boolean isComplete() {
        return isComplete;
    }

    public void setComplete(boolean complete) {
        isComplete = complete;
    }

    public String getWorkoutDescription() {
        return workoutDescription;
    }

    public void setWorkoutDescription(String workoutDescription) {
        this.workoutDescription = workoutDescription;
    }
}
