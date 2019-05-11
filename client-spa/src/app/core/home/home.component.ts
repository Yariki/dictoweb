import { Component, OnInit } from '@angular/core';
import {WordService} from '../../services/wordservice';
import {UserWordsInfo} from '../../models/userwordsinfo';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  info: UserWordsInfo;

  constructor( private  wordService: WordService) { }

  ngOnInit() {
    this.wordService.getWordsInfo().then(result => this.info = result);
  }


}
