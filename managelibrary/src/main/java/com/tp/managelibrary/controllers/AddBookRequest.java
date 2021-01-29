package com.tp.managelibrary.controllers;

public class AddBookRequest {

    private String[] bookAuthors;
    private Integer publicationYear;
    private String bookTitle;

    public Integer getPublicationYear() {
        return publicationYear;
    }

    public void setPublicationYear(Integer publicationYear) {
        this.publicationYear = publicationYear;
    }

    public String[] getBookAuthors() {
        return bookAuthors;
    }

    public void setBookAuthors(String[] bookAuthors) {
        this.bookAuthors = bookAuthors;
    }

    public String getBookTitle() {
        return bookTitle;
    }

    public void setBookTitle(String bookTitle) {
        this.bookTitle = bookTitle;
    }
}
