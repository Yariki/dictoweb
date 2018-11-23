import { Component, OnInit } from '@angular/core';
import {WordService} from '../../services/wordservice';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {Word} from '../../models/word';

@Component({
  selector: 'app-word-detail',
  templateUrl: './word-detail.component.html',
  styleUrls: ['./word-detail.component.css']
})
export class WordDetailComponent implements OnInit {

  word: Word;

  constructor(private wordService: WordService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe((qP: Params) => {
      const id = +qP['id'];
      console.log(id);
      this.wordService.getWord(id).then(value => {
        this.word = value;
        console.log(this.word);
      });
    });
  }

}
