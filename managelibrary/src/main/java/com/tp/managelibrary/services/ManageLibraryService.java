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

    public Book getBookByID(Integer bookID) {
        Book book = null;
        try {
            book = dao.getBookByID(bookID);
        } catch (InvalidBookIDException e) {
            e.printStackTrace();
        }
        return book;
    }

    public Book getBookByAuthor(String[] bookAuthors) {
        Book book = null;
        try {
            book = dao.getBookByAuthors(bookAuthors);
        } catch (InvalidAuthorException e) {
        }
        return book;
    }

    public Book getBookByYear(Integer publicationYear) {
        Book book = null;
        try {
            book = dao.getBookByYear(publicationYear);
        } catch (InvalidPublicationYearException e) {

        }
        return book;
    }

    public Book getBookByTitle(String bookTitle) {
        Book book = null;
        try {
            book = dao.getBookByTitle(bookTitle);
        } catch (InvalidTitleException e) {
        }
        return book;
    }

    public Book addBook(String[] bookAuthors, Integer publicationYear, String bookTitle) {

        Book newBook = null;

        try {
            newBook = dao.addBook(bookAuthors, publicationYear, bookTitle);
        } catch (InvalidBookIDException | InvalidAuthorException | InvalidPublicationYearException
                | InvalidTitleException e) {
        }

        return newBook;
    }

    public Book editBook(Book editedBook) {
        return dao.editBook(editedBook);
    }

    public void deleteBook(Integer bookID) {
        try {
            dao.deleteBook(bookID);
        } catch (InvalidBookIDException e) {
        }
    }

}
