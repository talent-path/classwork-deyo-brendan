package com.tp.managelibrary.persistence;

import com.tp.managelibrary.exceptions.InvalidAuthorException;
import com.tp.managelibrary.exceptions.InvalidBookIDException;
import com.tp.managelibrary.exceptions.InvalidPublicationYearException;
import com.tp.managelibrary.exceptions.InvalidTitleException;
import com.tp.managelibrary.models.Book;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.RowMapper;
import org.springframework.stereotype.Component;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

@Component
public class PostgresLibraryDao implements ManageLibraryDao {

    @Autowired
    JdbcTemplate template;

    @Override
    public Book getBookByID(Integer bookID) throws InvalidBookIDException {
        return null;
    }

    @Override
    public Book getBookByAuthors(String bookAuthors) throws InvalidAuthorException {
        return null;
    }

    @Override
    public Book getBookByYear(Integer publicationYear) throws InvalidPublicationYearException {
        return null;
    }

    @Override
    public Book getBookByTitle(String bookTitle) throws InvalidTitleException {
        return null;
    }

    @Override
    public List<Book> getAllBooks() {
        return null;
    }

    @Override
    public Book editBook(Book bookObject) throws InvalidBookIDException, InvalidAuthorException, InvalidPublicationYearException, InvalidTitleException {
        return null;
    }

    private Integer addAuthor(String author)
    {
        
        return template.query("INSERT into public.\"Authors\" (\"authorName\")\n" +
                "VALUES ('"+ author +"')\n" +
                "RETURNING \"authorID\";\n" +
                "\n", new IdMapper()).get(0);
    }

    @Override
    public Book addBook(String[] bookAuthors, Integer publicationYear, String bookTitle) throws InvalidBookIDException, InvalidAuthorException, InvalidPublicationYearException, InvalidTitleException {
        
        List<Integer> authorList = new ArrayList<>();
        
        for (String author : bookAuthors)
        {
            Integer authorID = addOrRetrieve(author);
            authorList.add(authorID);
        }

        return null;
    }

    private Integer addOrRetrieve(String author) {

        Integer authorID = getAuthorID(author);

        if (authorID == null)
        {
            authorID = addAuthor(author);
        }


        return authorID;
    }

    private Integer getAuthorID(String author) {

        List<Integer> id = template.query("SELECT \"authorID\" from \"Authors\" WHERE " +
                "\"authorName\" = '"+ author +"'; ", new IdMapper());

        if (id.isEmpty())
            return null;

        return id.get(0);
    }

    @Override
    public void deleteBook(Integer bookID) throws InvalidBookIDException {

    }

    private class IdMapper implements RowMapper<Integer>
    {
        @Override
        public Integer mapRow(ResultSet resultSet, int i) throws SQLException
        {
            return resultSet.getInt("authorID");
        }
    }
}
