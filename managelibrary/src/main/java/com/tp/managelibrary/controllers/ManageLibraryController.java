package com.tp.managelibrary.controllers;


import com.tp.managelibrary.models.ManageLibraryViewModel;
import com.tp.managelibrary.services.ManageLibraryService;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class ManageLibraryController {

    ManageLibraryService service;

    @GetMapping("/library")
    public List<ManageLibraryViewModel> getAllBooks()
    {
        throw new UnsupportedOperationException();
    }

    @GetMapping("/library/{getBookID")
    public ManageLibraryViewModel  getBook(@PathVariable Integer bookID)
    {
        throw new UnsupportedOperationException();
    }

    @PutMapping("/edit")
    public ManageLibraryViewModel addBook(@RequestBody AddBookRequest request)
    {
        throw new UnsupportedOperationException();
    }

    @DeleteMapping("/delete/{bookID}")
    public ManageLibraryViewModel deleteBook(@PathVariable Integer bookID)
    {
        throw new UnsupportedOperationException();
    }

    @PutMapping("/edit/{bookID}")
    public ManageLibraryViewModel editBook(@PathVariable UpdateBookRequest request, Integer bookID)
    {
        throw new UnsupportedOperationException();
    }

}
