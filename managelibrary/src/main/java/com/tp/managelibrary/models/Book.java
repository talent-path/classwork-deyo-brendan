package com.tp.managelibrary.models;

public class Book {

    private Integer bookID;
    private String[] bookAuthors;
    private Integer publicationYear;
    private String bookTitle;

    public Book()
    {

    }

    public Book(Integer bookID, String[] bookAuthors, Integer publicationYear, String bookTitle) {
        this.bookID = bookID;
        this.bookAuthors = bookAuthors;
        this.publicationYear = publicationYear;
        this.bookTitle = bookTitle;
    }

    public Book(Book that) {
        this.bookID = that.bookID;
        this.bookAuthors = new String[that.bookAuthors.length];
        for (int i = 0; i < this.bookAuthors.length; i++) {
            this.bookAuthors[i] = that.bookAuthors[i];
        }
        this.publicationYear = that.publicationYear;
        this.bookTitle = that.bookTitle;

    }

    public Integer getBookID() {
        return bookID;
    }

    public void setBookID(Integer bookID) {
        this.bookID = bookID;
    }

    public String[] getBookAuthors() {
        return bookAuthors;
    }

    public void setBookAuthors(String[] bookAuthor) {
        this.bookAuthors = bookAuthor;
    }

    public Integer getPublicationYear() {
        return publicationYear;
    }

    public void setPublicationYear(Integer publicationYear) {
        this.publicationYear = publicationYear;
    }

    public String getBookTitle() {
        return bookTitle;
    }

    public void setBookTitle(String bookTitle) {
        this.bookTitle = bookTitle;
    }
}
