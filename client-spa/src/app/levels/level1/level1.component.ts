import { Component, OnInit } from '@angular/core';
import {LevelsService} from '../../services/levels.service';
import {TaskItem} from '../../models/taskitem';

@Component({
  selector: 'app-level1',
  templateUrl: './level1.component.html',
  styleUrls: ['./level1.component.css']
})
export class Level1Component implements OnInit {

  generateTask = true;
  currentTask: TaskItem;
  showNext = false;

  private tasks: TaskItem[];
  private currentIndex = 0;

  constructor(private  levelService: LevelsService) { }

  ngOnInit() {
  }

  onGenerateTask() {

    this.levelService.createTaskLevel1().then(result => {
      if (result != null) {
        this.currentIndex = 0;
        this.generateTask = false;
        this.tasks = result;
        this.currentTask = this.tasks[this.currentIndex];
      }
    });
  }

  onSelected(isCorrect: boolean) {
    this.showNext = true;
    if (isCorrect) {
      // TODO: update word level
    }
  }

  onNext() {
    this.currentIndex++;
    if (this.currentIndex < this.tasks.length) {
      this.currentTask = this.tasks[this.currentIndex];
      this.showNext = false;
    } else {
      this.currentTask = new TaskItem();
      this.tasks = null ;
      this.generateTask = true ;
    }
  }

}
