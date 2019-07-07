import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {MemoryService} from '../../services/memory.service';
import {Params} from '@angular/router/src/shared';
import {Memoryinfo} from '../../models/memoryinfo';
import {Memoryrepeating} from '../../models/memoryrepeating';
import {RepeatingsettingsService} from '../../services/repeatingsettings.service';
import {Word} from '../../models/word';

@Component({
  selector: 'app-smrepeating',
  templateUrl: './smrepeating.component.html',
  styleUrls: ['./smrepeating.component.css']
})
export class SmrepeatingComponent implements OnInit {

  private repeatingTask: Memoryrepeating;

  againCount: number;
  newCount: number;
  todayCount: number;
  currentRepeatingWord: Word;
  showAnswer: boolean;

  private againCollection: Word[];
  private currentAgainCollection: Word[];
  private wordUpdateRepeating: Word[];

  constructor(private memoryService: MemoryService, private router: Router, private route: ActivatedRoute,
              private repeatingsettingsService: RepeatingsettingsService) { }

  ngOnInit() {
    this.againCount = 0;
    this.newCount = 0;
    this.todayCount = 0;
    this.initRepeating();
  }


  private initRepeating() {
    this.memoryService.getRepetition(
      {newwords: this.repeatingsettingsService.newwords, minutes: this.repeatingsettingsService.minutes}).then(value => {
      this.repeatingTask = value;
      if (this.repeatingTask != null && this.repeatingTask.newwords.length > 0) {
        this.currentRepeatingWord = this.repeatingTask.newwords[0];
      }
    });
  }

  onShowAnswer() {

  }

  onAgain() {

  }

  onHard() {

  }

  onGood() {

  }

  onEasy() {

  }





}
