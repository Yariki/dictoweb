import { Component, OnInit } from '@angular/core';
import {Word} from '../../models/word';
import {WordService} from '../../services/wordservice';
import {WordPagination} from '../../models/wordpagination';
import {ActivatedRoute, Router} from '@angular/router';
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {DeleteMessage} from '../../shared/messages/delete.message';

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
  word: Word;

  private DefaultPageSize: number = 10;
  private currentLetter: string;

  constructor( private wordService: WordService, private router: Router, private activeRoute: ActivatedRoute, private modalService: NgbModal ) {
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

  onDetails(content: any, id: number) {

    this.wordService.getWord(id).then(value => {
      this.word = value;
      this.modalService.open(content,{size: 'lg'}).result.then((res) => {

        },
        (reason) => {

        });
    });
  }

  onDelete(id: number) {
    this.modalService.open(DeleteMessage).result.then(value => {
      console.log(value + ' ' + id);
      this.wordService.deleteWord(id).then(result => {
        this.onRefresh();
      });
    },
      reason => {
        console.log(reason);
      }
      );
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
