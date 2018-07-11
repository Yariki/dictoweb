import { Component, OnInit } from '@angular/core';
import {Word} from '../../models/word';
import {WordService} from '../../services/wordservice';

@Component({
  selector: 'app-word-list',
  templateUrl: './word-list.component.html',
  styleUrls: ['./word-list.component.css']
})
export class WordListComponent implements OnInit {

  words: Word[];
  letters: string[] = [];

  constructor( private wordService: WordService ) {
  }

  ngOnInit() {
    const temp = 'abcdefghijklmnopqrstuvwxyz'.split( '');
    this.letters.push('');
    temp.forEach(l => this.letters.push(l));
  }


}
