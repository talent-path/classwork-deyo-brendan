package com.tp.DailyPumpInitiative.exceptions;

public class NullExerciseException extends Exception{

    public NullExerciseException(String message)
    {
        super(message);
    }

    public NullExerciseException(String message, Throwable innerException)
    {
        super(message, innerException);
    }
}
