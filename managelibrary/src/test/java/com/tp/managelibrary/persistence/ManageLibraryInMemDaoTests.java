package com.tp.managelibrary.persistence;

import com.tp.managelibrary.exceptions.InvalidAuthorException;
import com.tp.managelibrary.exceptions.InvalidBookIDException;
import com.tp.managelibrary.exceptions.InvalidPublicationYearException;
import com.tp.managelibrary.exceptions.InvalidTitleException;
import com.tp.managelibrary.models.Book;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import java.util.List;

import static org.junit.jupiter.api.Assertions.fail;

@SpringBootTest
public class ManageLibraryInMemDaoTests {

    @Autowired
    ManageLibraryInMemDao toTest;

    @BeforeEach
    public void setup() throws InvalidBookIDException, InvalidTitleException,
            InvalidPublicationYearException, InvalidAuthorException
    {
        List<Book> allBooks = toTest.getAllBooks();
        for (Book toDelete : allBooks)
        {
            toTest.deleteBook(toDelete.getBookID());
        }

        // ID: 1
        String[] authors = {"Edgar Allan Poe"};
        int pub = 1845;
        String title = "The Raven";
        toTest.addBook(authors, pub, title);

        // ID: 2
        authors = new String[]{"Stephen King"};
        pub = 1986;
        title = "IT";
        toTest.addBook(authors, pub, title);

        // ID: 3
        authors = new String[]{null};
        pub = 2002;
        title = "The Giver";
        toTest.addBook(authors, pub, title);

        // ID: 4
        authors = new String[]{"Brendan Deyo", "Rick Riordan", "Elon Musk"};
        pub = 2021;
        title = "Best Book Ever";
        toTest.addBook(authors, pub, title);

    }

    @Test
    public void testGetBookInvalidBookID()
    {
        try
        {
            toTest.getBookByID(100);
        } catch (InvalidBookIDException ex)
        {
            fail();
        }
    }

    @Test
    public void testGetBookInvalidNullAuthor()
    {
        try
        {
            String[] authors = {null};
            int pub = 1299;
            String title = "Best Breakfast in MD";
            Book toEdit = new Book(123, authors, pub, title);
            toTest.getBookByAuthors(null);
        } catch (InvalidAuthorException ex)
        {
            fail();
        }

    }

    @Test
    public void testGetBookInvalidNumberOfAuthors()
    {
        try
        {
            String[] authors = {"Bob Evans", "1", "2", "3", "4",
                "5", "6", "7" , "8" , "9" , "10"};
            int pub = 1299;
            String title = "Best Breakfast in MD";
            Book toEdit = new Book(123, authors, pub, title);
            toTest.getBookByAuthors("Bob Evans");
        } catch (InvalidAuthorException ex)
        {
            fail();
        }
    }

    @Test
    public void testGetBookNullPubYear()
    {
        try
        {
            Book newBook = new Book(100, new String[] {"It's a me, Mario"}, null,
                    "The Best Book");
            toTest.getBookByYear(null);
        } catch (InvalidPublicationYearException ex)
        {
            fail();
        }
    }

    @Test
    public void testGetBookInvalidPubYear()
    {
        try
        {
            String[] authors = {"Bob Evans"};
            int pub = 1299;
            String title = "Best Breakfast in MD";
            Book toEdit = new Book(123, authors, pub, title);
            toTest.getBookByYear(1299);
        } catch (InvalidPublicationYearException ex)
        {
            fail();
        }

    }

    @Test
    public void testGetBookNullBookTitle()
    {
        try
        {
            String[] authors = {"Bob Evans"};
            int pub = 1299;
            String title = null;
            Book toEdit = new Book(123, authors, pub, title);
            toTest.getBookByTitle(null);
        } catch (InvalidTitleException ex)
        {
            fail();
        }
    }

    @Test
    public void testGetBookInvalidBookTitle()
    {
        try
        {
            String[] authors = {"Bob Evans"};
            int pub = 1299;
            String title = "XY";
            Book toEdit = new Book(123, authors, pub, title);
            toTest.getBookByTitle("XY");
        } catch (InvalidTitleException ex)
        {
            fail();
        }
    }


}
