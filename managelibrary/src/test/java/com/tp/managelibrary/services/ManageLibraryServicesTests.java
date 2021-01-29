package com.tp.managelibrary.services;


import com.tp.managelibrary.exceptions.InvalidAuthorException;
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
    public void setup() {

        List<Book> allBooks = service.getAllBooks();

        for (int i = 0; i < allBooks.size(); i++)
        {
            int id = allBooks.get(i).getBookID();
            service.deleteBook(id);
        }

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

    }

    @Test
    public void testAddBookGoldenPath() {
        String[] authors = {"Edgar"};
        int pub = 1301;
        String title = "Book";

        Book testBook = service.addBook(authors, pub, title);

        assertEquals(service.getAllBooks().size(), 5);

    }

    @Test
    public void testGetAllBooksGoldenPath() {


    }

    @Test
    public void testDeleteBookGoldenPath() {
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

        int bookToDelete = 3;
        for (int i = 0; i < allBooks.size(); i++)
        {
            if(allBooks.get(i).getBookID() == bookToDelete)
            {
                service.deleteBook(bookToDelete);
            }
        }

        allBooks.size();

        int x = 1;

    }

    @Test
    public void testEditBookGoldenPath()
    {
        Book editBook = new Book();



       // service.editBook()

    }

}
