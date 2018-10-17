import { Component, OnInit } from '@angular/core';
import {LetterItem} from '../../models/letteritem';
import {LevelsService} from '../../services/levels.service';
import {WordService} from '../../services/wordservice';
import {Pazzleitem} from '../../models/pazzleitem';
import {LevelType} from '../../models/word';

@Component({
  selector: 'app-level3',
  templateUrl: './level3.component.html',
  styleUrls: ['./level3.component.css']
})
export class Level3Component implements OnInit {

  level = 'Level 3';
  generateTask = true;
  showNext = false;

  pazzle: Pazzleitem;

  currentPazzleIndex = 0;
  countOfPazzles = 0;

  private tasks: Pazzleitem[];


  constructor(private levelService: LevelsService, private wordService: WordService) {

  }

  ngOnInit() {
  }


  onItemClick(obj: any, index: number) {
    const item = this.pazzle.pazzle[index];
    const ind = item.order.indexOf(this.pazzle.current);
    if (ind > -1) {
      item.show = false;
      this.pazzle.original[this.pazzle.current - 1].show = true;
      this.pazzle.current++;
      let correct = false;
      for (let i = 0; i < this.pazzle.original.length; i++) {
        correct = this.pazzle.original[i].show;
      }
      if (correct) {
        this.showNext = true;
        this.wordService.updateLevel(this.pazzle.wordid, LevelType.Compleate);
      }
    } else {
      this.pazzle.pazzle.forEach(p => {
        p.iserror = true;
      });
      this.pazzle.original.forEach(o => {
        o.iserror = o.show = true;
      });
      this.showNext = true;
    }
  }

  onGenerate() {
    this.levelService.createTaskLevel3().then(result => {
      this.tasks = result;
      this.generateTask = false;
      if (this.tasks.length > 0) {
        this.currentPazzleIndex = 0;
        this.pazzle = this.tasks[this.currentPazzleIndex];
        this.countOfPazzles = this.tasks.length;
      }
    });
  }

  onNext() {
    this.currentPazzleIndex++;
    if (this.currentPazzleIndex < this.tasks.length) {
      this.pazzle = this.tasks[this.currentPazzleIndex];
    } else {
      this.generateTask = true;
    }
    this.showNext = false;
  }

  dontKnow() {
    this.pazzle.original.forEach(o => {
      o.iserror = true;
      o.show = true;
    });
    this.showNext = true;
  }

}
