import {Component, OnInit} from '@angular/core';
import {LevelsService} from '../../services/levels.service';
import {TaskItem} from '../../models/taskitem';
import {WordService} from '../../services/wordservice';
import {LevelType} from '../../models/word';


@Component({
  selector: 'app-level1',
  templateUrl: './level1.component.html',
  styleUrls: ['./level1.component.css']
})
export class Level1Component implements OnInit {

  level: string;
  generateTask = true;
  currentTask: TaskItem;
  showNext = false;
  preview: boolean;
  wordsCount: number;


  currentIndex = 0;
  countOfTasks = 0;

  private tasks: TaskItem[];

  constructor(private  levelService: LevelsService, private wordService: WordService) { }

  ngOnInit() {
    this.level = 'Level 1';
    this.currentTask = new TaskItem();
    this.updateWordCount();
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
      this.updateWordCount();

    }
  }

  dontKnow() {
    this.preview = true ;
    this.showNext = true;
  }

  private updateWordCount() {
    this.levelService.getLevelCount(LevelType.First).then(value => this.wordsCount = value);
  }

}
