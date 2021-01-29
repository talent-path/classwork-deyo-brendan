package com.tp.managelibrary.exceptions;

public class InvalidPublicationYearException extends Exception{

    public InvalidPublicationYearException(String message)
    {
        super(message);
    }

    public InvalidPublicationYearException(String message, Throwable innerException)
    {
        super(message, innerException);
    }


}
