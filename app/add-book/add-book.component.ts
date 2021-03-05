import { Component, Input, OnInit } from '@angular/core';
import { BookComponent } from '../book/book.component';
import {LibraryService} from '../library.service';
import {Book} from '../Book';
import {Router} from '@angular/router';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.css']
})
export class AddBookComponent implements OnInit {

  title : string;
  year : number;

  constructor(private service : LibraryService, private router : Router) {}

  ngOnInit(): void {
  }

  addBook() {
    let authors : string[] = ["Author"];
    let toAdd : Book = {title: this.title, year: this.year, authors: authors}
    this.service.addBook(toAdd).subscribe((_) => {this.router.navigate([""])});
  }

}
