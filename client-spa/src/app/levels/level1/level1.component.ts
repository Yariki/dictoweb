import {Component, OnInit} from '@angular/core';
import {LevelsService} from '../../services/levels.service';
import {TaskItem} from '../../models/taskitem';
import {WordService} from '../../services/wordservice';
import {LevelType} from '../../models/word';
import {LevelBase} from '../../core/LabelBase';


@Component({
  selector: 'app-level1',
  templateUrl: './level1.component.html',
  styleUrls: ['./level1.component.css']
})
export class Level1Component extends LevelBase {


  constructor(levelService: LevelsService, wordService: WordService) {
    super(levelService, wordService);
  }

  onGenerateTask() {

    this.levelService.createTaskLevel1().then(result => {
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
    return LevelType.First;
  }

  getNextLevel(): LevelType {
    return LevelType.Second;
  }

  getName(): string {
    return 'Level 1';
  }

}
