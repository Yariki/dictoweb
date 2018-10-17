import { Component, OnInit } from '@angular/core';
import {TaskItem} from '../../models/taskitem';
import {LevelsService} from '../../services/levels.service';
import {WordService} from '../../services/wordservice';
import {LevelType} from '../../models/word';

@Component({
  selector: 'app-level2',
  templateUrl: './level2.component.html',
  styleUrls: ['./level2.component.css']
})
export class Level2Component implements OnInit {

  level: string;
  generateTask = true;
  currentTask: TaskItem;
  showNext = false;
  preview: boolean;

  currentIndex = 0;
  countOfTasks = 0;

  private tasks: TaskItem[];


  constructor(private  levelService: LevelsService, private wordService: WordService) { }

  ngOnInit() {
    this.level = 'Level 2';
    this.currentTask = new TaskItem();
  }

  onGenerateTask() {

    this.levelService.createTaskLevel2().then(result => {
      if (result != null) {
        this.currentIndex = 0;
        this.generateTask = false;
        this.tasks = result;
        this.preview = false;
        this.currentTask = this.tasks[this.currentIndex];
        this.countOfTasks = this.tasks.length;
      }
    });
  }

  onSelected(isCorrect: boolean) {
    this.showNext = true;
    if (isCorrect) {
      this.currentTask.word.level = LevelType.Third;
      this.wordService.updateWord(this.currentTask.word);
    }
  }

  onNext() {
    this.currentIndex++;
    if (this.currentIndex < this.tasks.length) {
      this.currentTask = this.tasks[this.currentIndex];
      this.showNext = false;
      this.preview = false;
    } else {
      this.currentTask = new TaskItem();
      this.tasks = null ;
      this.generateTask = true ;
    }
  }

  dontKnow() {
    this.preview = true ;
    this.showNext = true;
  }

}
