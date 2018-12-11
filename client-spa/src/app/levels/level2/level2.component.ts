import { Component, OnInit } from '@angular/core';
import {TaskItem} from '../../models/taskitem';
import {LevelsService} from '../../services/levels.service';
import {WordService} from '../../services/wordservice';
import {LevelType} from '../../models/word';
import {LevelBase} from '../../core/LabelBase';

@Component({
  selector: 'app-level2',
  templateUrl: './level2.component.html',
  styleUrls: ['./level2.component.css']
})
export class Level2Component extends LevelBase {


  constructor( levelService: LevelsService, wordService: WordService) {
    super(levelService, wordService);
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

  getCurrentLevel(): LevelType {
    return LevelType.Second;
  }

  getNextLevel(): LevelType {
    return LevelType.Third;
  }

  getName(): string {
    return 'Level 2';
  }

}
