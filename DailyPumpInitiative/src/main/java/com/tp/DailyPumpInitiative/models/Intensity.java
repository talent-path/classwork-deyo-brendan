package com.tp.DailyPumpInitiative.models;

import java.util.List;

public class Intensity {

    private Integer intensityID;
    private String intensityName;
    private List<Workout> workoutList;
    private String intensityDuration;
    private String intensityDescription;

    public Intensity()
    {

    }

    public Intensity(Integer intensityID, String intensityName,
                     String intensityDuration, String intensityDescription)
    {
        this.intensityID = intensityID;
        this.intensityName = intensityName;
        this.intensityDuration = intensityDuration;
        this.intensityDescription = intensityDescription;
    }

    public Intensity(Intensity that)
    {
        this.intensityID = that.intensityID;
        this.intensityName = that.intensityName;
        this.intensityDuration = that.intensityDuration;
        this.intensityDescription = that.intensityDuration;

    }

    public Integer getIntensityID() {
        return intensityID;
    }

    public void setIntensityID(Integer intensityID) {
        this.intensityID = intensityID;
    }

    public String getIntensityName() {
        return intensityName;
    }

    public void setIntensityName(String intensityName) {
        this.intensityName = intensityName;
    }

    public List<Workout> getWorkoutList() {
        return workoutList;
    }

    public void setWorkoutList(List<Workout> workoutList) {
        this.workoutList = workoutList;
    }

    public String getIntensityDuration() {
        return intensityDuration;
    }

    public void setIntensityDuration(String intensityDuration) {
        this.intensityDuration = intensityDuration;
    }

    public String getIntensityDescription() {
        return intensityDescription;
    }

    public void setIntensityDescription(String intensityDescription) {
        this.intensityDescription = intensityDescription;
    }
}
