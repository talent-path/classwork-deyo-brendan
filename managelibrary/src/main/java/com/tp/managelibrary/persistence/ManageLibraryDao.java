package com.tp.managelibrary.persistence;

import com.tp.managelibrary.exceptions.InvalidAuthorException;
import com.tp.managelibrary.exceptions.InvalidBookIDException;
import com.tp.managelibrary.exceptions.InvalidPublicationYearException;
import com.tp.managelibrary.exceptions.InvalidTitleException;
import com.tp.managelibrary.models.Book;

import java.util.List;

public interface ManageLibraryDao {

    Book getBookByID(Integer bookID) throws InvalidBookIDException;

    Book getBookByAuthors(String[] bookAuthors) throws InvalidAuthorException;

    Book getBookByYear(Integer publicationYear) throws InvalidPublicationYearException;

    Book getBookByTitle(String bookTitle) throws InvalidTitleException;

    List<Book> getAllBooks();

    Book editBook(Book bookObject);

    Book addBook(String[] bookAuthors, Integer publicationYear, String bookTitle)
            throws InvalidBookIDException, InvalidAuthorException, InvalidPublicationYearException, InvalidTitleException;

    void deleteBook(Integer bookID) throws InvalidBookIDException;

}
