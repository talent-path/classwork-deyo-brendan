package com.tp.managelibrary.controllers;


import com.tp.managelibrary.exceptions.InvalidAuthorException;
import com.tp.managelibrary.exceptions.InvalidBookIDException;
import com.tp.managelibrary.exceptions.InvalidPublicationYearException;
import com.tp.managelibrary.exceptions.InvalidTitleException;
import com.tp.managelibrary.models.Book;
import com.tp.managelibrary.services.ManageLibraryService;
import org.springframework.beans.factory.annotation.Autowired;
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
    public Book getBookByID(@PathVariable Integer bookID) {
        return service.getBookByID(bookID);
    }

    @GetMapping("/get/author/{bookAuthors}")
    public Book getBookByAuthor(@PathVariable String[] bookAuthors) {
        return service.getBookByAuthor(bookAuthors);
    }

    @GetMapping("/get/year/{publicationYear}")
    public Book getBookByYear(@PathVariable Integer publicationYear) {
        return service.getBookByYear(publicationYear);
    }

    @GetMapping("get/title/{bookTitle}")
    public Book getBookByTitle(@PathVariable String bookTitle) {
        return service.getBookByTitle(bookTitle);
    }

    @PostMapping("/add")
    public Book addBook(@RequestBody AddBookRequest request) {
        return service.addBook(request.getBookAuthors(), request.getPublicationYear(), request.getBookTitle());
    }

    @DeleteMapping("/delete/{bookID}")
    public void deleteBook(@PathVariable Integer bookID) {
        service.deleteBook(bookID);

        System.out.println("Deleted book with ID" + bookID);

    }

    @PutMapping("/edit")
    public Book editBook(@RequestBody Book bookObject) {

        return service.editBook(bookObject);

//        HangmanViewModel toReturn = null;
//
//        try{
//            toReturn = service.makeGuess( request.getGameId(), request.getGuess() );
//        } catch( NullGuessException | InvalidGuessException | InvalidGameIdException ex ){
//
//            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(ex.getMessage());
//        }
//
//        return ResponseEntity.ok(toReturn);


    }

}
