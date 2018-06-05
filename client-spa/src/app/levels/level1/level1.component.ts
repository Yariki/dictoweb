import { Component, OnInit } from '@angular/core';
import {LevelsService} from '../../services/levels.service';
import {TaskItem} from '../../models/taskitem';
import {WordService} from '../../services/wordservice';
import {LevelType } from '../../models/word';


@Component({
  selector: 'app-level1',
  templateUrl: './level1.component.html',
  styleUrls: ['./level1.component.css']
})
export class Level1Component implements OnInit {

  generateTask = true;
  currentTask: TaskItem;
  showNext = false;
  preview: boolean;

  private tasks: TaskItem[];
  private currentIndex = 0;

  constructor(private  levelService: LevelsService, private wordService: WordService) { }

  ngOnInit() {
  }

  onGenerateTask() {

    this.levelService.createTaskLevel1().then(result => {
      if (result != null) {
        this.currentIndex = 0;
        this.generateTask = false;
        this.tasks = result;
        this.preview = false;
        this.currentTask = this.tasks[this.currentIndex];
      }
    });
  }

  onSelected(isCorrect: boolean) {
    this.showNext = true;
    if (isCorrect) {
      this.currentTask.word.level = LevelType.Second;
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
