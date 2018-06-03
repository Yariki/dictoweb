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

  private tasks: TaskItem[];

  constructor(private  levelService: LevelsService) { }

  ngOnInit() {
  }

  onGenerateTask() {

    this.levelService.createTaskLevel1().then(result => {
      if (result != null) {
        this.generateTask = false;
        this.tasks = result;
        this.currentTask = this.tasks[0];
      }
    });
  }

}
