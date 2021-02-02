package com.tp.managelibrary.controllers;


import com.tp.managelibrary.exceptions.InvalidAuthorException;
import com.tp.managelibrary.exceptions.InvalidBookIDException;
import com.tp.managelibrary.exceptions.InvalidPublicationYearException;
import com.tp.managelibrary.exceptions.InvalidTitleException;
import com.tp.managelibrary.models.Book;
import com.tp.managelibrary.services.ManageLibraryService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class ManageLibraryController {

    @Autowired
    ManageLibraryService service;

    @GetMapping("/library")
    public List<Book> getAllBooks() {
        return service.getAllBooks();
    }

    @GetMapping("/get/ID/{bookID}")
    public ResponseEntity getBookByID(@PathVariable Integer bookID) {
        try
        {
            return ResponseEntity.ok(service.getBookByID(bookID));
        } catch (InvalidBookIDException ex)
        {
            return ResponseEntity.badRequest().body(ex.getMessage());
        }
    }

    @GetMapping("/get/author/{bookAuthors}")
    public ResponseEntity getBookByAuthor(@PathVariable String bookAuthors) {
        try
        {
            return ResponseEntity.ok(service.getBookByAuthor(bookAuthors));
        } catch (InvalidAuthorException ex)
        {
            return ResponseEntity.badRequest().body(ex.getMessage());
        }

    }

    @GetMapping("/get/year/{publicationYear}")
    public ResponseEntity getBookByYear(@PathVariable Integer publicationYear) {
        try
        {
            return ResponseEntity.ok(service.getBookByYear(publicationYear));
        } catch (InvalidPublicationYearException ex)
        {
            return ResponseEntity.badRequest().body(ex.getMessage());
        }

    }

    @GetMapping("get/title/{bookTitle}")
    public ResponseEntity getBookByTitle(@PathVariable String bookTitle) {
        try
        {
            return ResponseEntity.ok(service.getBookByTitle(bookTitle));
        } catch (InvalidTitleException ex)
        {
            return ResponseEntity.badRequest().body(ex.getMessage());
        }
    }

    @PostMapping("/add")
    public ResponseEntity addBook(@RequestBody AddBookRequest request) {
        try
        {
            return ResponseEntity.ok(service.addBook(request.getBookAuthors(), request.getPublicationYear(),
                    request.getBookTitle()));
        } catch (InvalidBookIDException | InvalidAuthorException | InvalidPublicationYearException
            | InvalidTitleException ex)
        {
            return ResponseEntity.badRequest().body(ex.getMessage());
        }
    }

    @DeleteMapping("/delete/{bookID}")
    public void deleteBook(@PathVariable Integer bookID) {
        try
        {
            service.deleteBook(bookID);
        } catch (InvalidBookIDException ex)
        {
            ex.getMessage();
        }

    }

    @PutMapping("/edit")
    public ResponseEntity editBook(@RequestBody Book bookObject) {

        try
        {
            return ResponseEntity.ok(service.editBook(bookObject));
        } catch (InvalidBookIDException | InvalidAuthorException | InvalidPublicationYearException
            | InvalidTitleException ex)
        {
            return ResponseEntity.badRequest().body(ex.getMessage());
        }

    }

}
