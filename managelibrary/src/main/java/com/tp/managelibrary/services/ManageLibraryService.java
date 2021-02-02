package com.tp.managelibrary.services;

import com.tp.managelibrary.exceptions.InvalidAuthorException;
import com.tp.managelibrary.exceptions.InvalidBookIDException;
import com.tp.managelibrary.exceptions.InvalidPublicationYearException;
import com.tp.managelibrary.exceptions.InvalidTitleException;
import com.tp.managelibrary.models.Book;
import com.tp.managelibrary.persistence.ManageLibraryDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

@Component
public class ManageLibraryService {

    @Autowired
    ManageLibraryDao dao;

    public List<Book> getAllBooks() {
        List<Book> allBooks = dao.getAllBooks();
        List<Book> converted = new ArrayList<>();

        for (Book toConvert : allBooks) {
            converted.add((toConvert));
        }
        return converted;
    }

    public Book getBookByID(Integer bookID) throws InvalidBookIDException {
        Book book = null;
        book = dao.getBookByID(bookID);
        return book;
    }

    public Book getBookByAuthor(String bookAuthors) throws InvalidAuthorException {
        Book book = null;
        book = dao.getBookByAuthors(bookAuthors);
        return book;
    }

    public Book getBookByYear(Integer publicationYear) throws InvalidPublicationYearException {
        Book book = null;
        try {
            book = dao.getBookByYear(publicationYear);
        } catch (InvalidPublicationYearException e) {

        }
        return book;
    }

    public Book getBookByTitle(String bookTitle) throws InvalidTitleException {
        Book book = null;
        try {
            book = dao.getBookByTitle(bookTitle);
        } catch (InvalidTitleException e) {
        }
        return book;
    }

    public Book addBook(String[] bookAuthors, Integer publicationYear, String bookTitle) throws InvalidBookIDException,
            InvalidAuthorException, InvalidPublicationYearException, InvalidTitleException {

        Book newBook = null;
        newBook = dao.addBook(bookAuthors, publicationYear, bookTitle);
        return newBook;
    }

    public Book editBook(Book editedBook) throws InvalidBookIDException, InvalidAuthorException,
            InvalidPublicationYearException, InvalidTitleException {
        return dao.editBook(editedBook);
    }

    public void deleteBook(Integer bookID) throws InvalidBookIDException {
        dao.deleteBook(bookID);
    }

}
