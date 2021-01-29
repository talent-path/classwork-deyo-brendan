package com.tp.managelibrary.persistence;


import com.tp.managelibrary.exceptions.InvalidAuthorException;
import com.tp.managelibrary.exceptions.InvalidBookIDException;
import com.tp.managelibrary.exceptions.InvalidPublicationYearException;
import com.tp.managelibrary.exceptions.InvalidTitleException;
import com.tp.managelibrary.models.Book;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

@Component
public class ManageLibraryInMemDao implements ManageLibraryDao {

    private List<Book> allBooks = new ArrayList<>();

    public List<Book> getAllBooks() {
        List<Book> newBookList = new ArrayList<>();
        for (Book toCopy : allBooks) {
            newBookList.add(new Book(toCopy));
        }

        return newBookList;

    }

    public Book getBookByID(Integer bookID) throws InvalidBookIDException {
        Book toReturn = null;

        for (Book toCheck : allBooks) {
            if (toCheck.getBookID().equals(bookID)) {
                toReturn = new Book(toCheck);
                break;
            }
        }

        if (toReturn.getBookID() == null) {
            throw new InvalidBookIDException("Book ID does not exist.");
        }

        return toReturn;
    }

    public Book getBookByAuthors(String[] bookAuthors) throws InvalidAuthorException {
        Book toReturn = null;

        for (Book toCheck : allBooks) {
            if (toCheck.getBookAuthors().equals(bookAuthors)) {
                toReturn = new Book(toCheck);
                break;
            }
        }

        if (toReturn.getBookAuthors() == null || toReturn.getBookAuthors().length == 0) {
            throw new InvalidAuthorException("There must be at least one author.");
        }

        return toReturn;
    }

    public Book getBookByYear(Integer publicationYear) throws InvalidPublicationYearException {
        Book toReturn = null;

        for (Book toCheck : allBooks) {
            if (toCheck.getPublicationYear().equals(publicationYear)) {
                toReturn = new Book(toCheck);
                break;
            }
        }

        if (toReturn.getPublicationYear() == null || (toReturn.getPublicationYear() < 1300 &&
                toReturn.getPublicationYear() > 2022)) {
            throw new InvalidPublicationYearException("Publication year does not exist.");
        }

        return toReturn;
    }

    public Book getBookByTitle(String bookTitle) throws InvalidTitleException {
        Book toReturn = null;

        for (Book toCheck : allBooks) {
            if (toCheck.getBookTitle().equals(bookTitle)) {
                toReturn = new Book(toCheck);
                break;
            }
        }

        if (toReturn.getBookTitle() == null || (toReturn.getBookTitle().length() < 3 &&
                toReturn.getBookTitle().length() > 100)) {
            throw new InvalidTitleException("Title is either to short or too long.");
        }

        return toReturn;
    }

    public Book addBook(String[] bookAuthors, Integer publicationYear, String bookTitle) throws
            InvalidBookIDException, InvalidAuthorException, InvalidPublicationYearException, InvalidTitleException {

        Book newBook = new Book();

        int id = 0;

        for (int i = 0; i < allBooks.size(); i++) {
            if (id < allBooks.get(i).getBookID()) {
                id = allBooks.get(i).getBookID();
            }
        }

        id++;

        newBook.setBookID(id);
        newBook.setBookAuthors(bookAuthors);
        newBook.setPublicationYear(publicationYear);
        newBook.setBookTitle(bookTitle);

        if (newBook.getBookID() == null) {
            throw new InvalidBookIDException("Book ID does not exist.");
        }

        if (newBook.getBookAuthors() == null || newBook.getBookAuthors().length < 1) {
            throw new InvalidAuthorException("There must be at least one author.");
        }

        if (newBook.getPublicationYear() == null || (newBook.getPublicationYear() < 1300 &&
                newBook.getPublicationYear() > 2022)) {
            throw new InvalidPublicationYearException("Publication year does not exist.");
        }

        if (newBook.getBookTitle() == null || (newBook.getBookTitle().length() < 3 &&
                newBook.getBookTitle().length() > 100)) {
            throw new InvalidTitleException("Title is either to short or too long.");
        }

        allBooks.add(newBook);

        return newBook;
    }

    public Book editBook(Book editedBook) {

        Book newBook = new Book();

        for (int i = 0; i < allBooks.size(); i++) {
            if (allBooks.get(i).getBookID().equals(editedBook.getBookID())) {
                newBook = allBooks.set(i, new Book(editedBook));
            }
        }

        return newBook;
    }

    public void deleteBook(Integer bookID) throws InvalidBookIDException {
        int removeIndex = -1;

        for( int i = 0; i < allBooks.size(); i++ ){
            if( allBooks.get(i).getBookID().equals(bookID)){
                removeIndex = i;
                break;
            }
        }
        if( removeIndex != -1 ){
            allBooks.remove(removeIndex);
        } else {
            throw new InvalidBookIDException("Could not find book with id " + bookID + "to delete.");
        }

    }
}
