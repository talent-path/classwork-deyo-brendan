package com.tp.managelibrary.exceptions;

public class InvalidBookIDException extends Exception{

    public InvalidBookIDException(String message)
    {
        super(message);
    }

    public InvalidBookIDException(String message, Throwable innerException)
    {
        super(message, innerException);
    }


}
