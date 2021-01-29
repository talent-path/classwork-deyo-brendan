package com.tp.managelibrary.exceptions;

public class NullLibraryException extends Exception{

    public NullLibraryException(String message)
    {
        super(message);
    }

    public NullLibraryException(String message, Throwable innerException)
    {
        super(message, innerException);
    }

}
