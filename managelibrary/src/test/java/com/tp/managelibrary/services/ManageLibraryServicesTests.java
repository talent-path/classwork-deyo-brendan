package com.tp.managelibrary.services;


import com.tp.managelibrary.exceptions.InvalidAuthorException;
import com.tp.managelibrary.exceptions.InvalidBookIDException;
import com.tp.managelibrary.exceptions.InvalidPublicationYearException;
import com.tp.managelibrary.exceptions.InvalidTitleException;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import com.tp.managelibrary.models.Book;

import static org.junit.jupiter.api.Assertions.*;

import java.util.ArrayList;
import java.util.List;


@SpringBootTest
public class ManageLibraryServicesTests {


    @Autowired
    ManageLibraryService service;

    @BeforeEach
    public void setup() throws InvalidPublicationYearException, InvalidAuthorException,
            InvalidTitleException, InvalidBookIDException {

        List<Book> allBooks = service.getAllBooks();

        for (int i = 0; i < allBooks.size(); i++)
        {
            int id = allBooks.get(i).getBookID();
            service.deleteBook(id);
        }

        String[] authors = {"Edgar Allan Poe"};
        int pub = 1845;
        String title = "The Raven";
        service.addBook(authors, pub, title);

        authors = new String[]{"Stephen King"};
        pub = 1986;
        title = "IT";
        service.addBook(authors, pub, title);

        authors = new String[]{"Lois Lowry"};
        pub = 2002;
        title = "The Giver";
        service.addBook(authors, pub, title);

        authors = new String[]{"Brendan Deyo", "Rick Riordan", "Elon Musk"};
        pub = 2021;
        title = "Best Book Ever";
        service.addBook(authors, pub, title);

    }

    @Test
    public void testAddBookGoldenPath() throws InvalidPublicationYearException, InvalidAuthorException,
            InvalidTitleException, InvalidBookIDException {

        String[] authors = {"John Doe"};
        int pub = 1299;
        String title = "Chronicles of the Mysterious John Doe";

        Book testBook = service.addBook(authors, pub, title);

        assertEquals(service.getAllBooks().size(), 5);

    }

    @Test
    public void testGetAllBooksGoldenPath() throws InvalidBookIDException {
        service.deleteBook(1);
        service.deleteBook(2);
        service.getAllBooks();
        assertEquals(service.getAllBooks().size(), 2);
    }

    @Test
    public void testDeleteBookGoldenPath() throws InvalidBookIDException, InvalidTitleException,
            InvalidPublicationYearException, InvalidAuthorException {
        String[] authors = {"Edgar"};
        int pub = 1301;
        String title = "Book";
        service.addBook(authors, pub, title);

        authors = new String[]{"Stephen"};
        pub = 1900;
        title = "Book2";
        service.addBook(authors, pub, title);

        authors = new String[]{"Brooke"};
        pub = 2001;
        title = "Book3";
        service.addBook(authors, pub, title);

        authors = new String[]{"Steve"};
        pub = 1902;
        title = "Book4";
        service.addBook(authors, pub, title);

        List<Book> allBooks = service.getAllBooks();

        service.deleteBook(5);

        try
        {
            service.getBookByID(5);
        } catch (InvalidBookIDException ex)
        {
            fail();
        }

    }

    @Test
    public void testEditBookGoldenPath() throws InvalidPublicationYearException, InvalidAuthorException,
            InvalidTitleException, InvalidBookIDException {

        Book toEdit = service.getBookByID(1);

        service.editBook(toEdit);

        assertEquals(service.getBookByID(123), 123);
        assertEquals(service.getBookByAuthor("Edited Author"), "Edited Author");
        assertEquals(service.getBookByYear(1999), 1999);
        assertEquals(service.getBookByTitle("Edited Book Title"), "Edited Book Title");



    }


}
