import { Component, OnInit } from '@angular/core';
import {Word} from '../../models/word';
import {WordService} from '../../services/wordservice';
import {WordPagination} from '../../models/wordpagination';

@Component({
  selector: 'app-word-list',
  templateUrl: './word-list.component.html',
  styleUrls: ['./word-list.component.css']
})
export class WordListComponent implements OnInit {

  words: Word[];
  letters: string[] = [];
  pages: number[] = [];
  currentPage: number;

  private DefaultPageSize: number = 10;
  private currentLetter: string;

  constructor( private wordService: WordService ) {
  }

  ngOnInit() {
    const temp = 'abcdefghijklmnopqrstuvwxyz'.split( '');
    this.letters.push('');
    temp.forEach(l => this.letters.push(l));
    const dto = new WordPagination();
    dto.letter = '';
    this.currentPage = dto.page = 1;
    dto.pagesize = this.DefaultPageSize;
    this.getPage(dto);
  }

  onChange(index: number) {
    if (index > this.letters.length || index === 0) {
      return;
    }
    this.currentLetter = this.letters[index];
    const dto = new WordPagination();
    dto.letter = this.currentLetter;
    this.currentPage = dto.page = 1;
    dto.pagesize = this.DefaultPageSize;
    this.getPage(dto);
  }

  onPageClick(index: number) {
    const dto = new WordPagination();
    dto.letter = this.currentLetter;
    this.currentPage = dto.page = index;
    dto.pagesize = this.DefaultPageSize;
    this.getPage(dto);
  }

  onRefresh() {
    const dto = new WordPagination();
    dto.letter = '';
    this.currentPage = dto.page = 1;
    dto.pagesize = this.DefaultPageSize;
    this.getPage(dto);
  }

  onDetails(id: number) {

  }

  onDelete(id: number) {

  }

  private getPage(dto: WordPagination) {
    this.wordService.getPage(dto).then(result => {
      this.words = result.words;
      this.updatePages(result.pagescount);
    });
  }


  private updatePages(count: number) {
    this.pages = [];
    for (let i = 0; i < count; i++) {
      this.pages.push(i + 1);
    }
  }


}
