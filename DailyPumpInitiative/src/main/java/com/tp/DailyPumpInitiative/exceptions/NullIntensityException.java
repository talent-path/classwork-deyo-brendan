package com.tp.DailyPumpInitiative.exceptions;

public class NullIntensityException extends Exception{

    public NullIntensityException(String message)
    {
        super(message);
    }

    public NullIntensityException(String message, Throwable innerException)
    {
        super(message, innerException);
    }

}
