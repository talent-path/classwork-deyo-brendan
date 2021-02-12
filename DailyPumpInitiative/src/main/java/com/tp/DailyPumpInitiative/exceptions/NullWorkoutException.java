package com.tp.DailyPumpInitiative.exceptions;

public class NullWorkoutException extends Exception{

    public NullWorkoutException(String message)
    {
        super(message);
    }

    public NullWorkoutException(String message, Throwable innerException)
    {
        super(message, innerException);
    }

}
