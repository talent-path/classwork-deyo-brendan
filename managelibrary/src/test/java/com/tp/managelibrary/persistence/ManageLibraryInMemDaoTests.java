package com.tp.managelibrary.persistence;

import com.tp.managelibrary.exceptions.InvalidAuthorException;
import com.tp.managelibrary.exceptions.InvalidBookIDException;
import com.tp.managelibrary.exceptions.InvalidPublicationYearException;
import com.tp.managelibrary.exceptions.InvalidTitleException;
import com.tp.managelibrary.models.Book;
import org.junit.jupiter.api.BeforeEach;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import java.util.List;

@SpringBootTest
public class ManageLibraryInMemDaoTests {

    @Autowired
    ManageLibraryInMemDao toTest;

    @BeforeEach
    public void setup() throws InvalidBookIDException
    {
        List<Book> allBooks = toTest.getAllBooks();
        for (Book toDelete : allBooks)
        {
            toTest.deleteBook(toDelete.getBookID());
        }
    }

    public void addBookTestGoldenPath()
    {

    }


}
