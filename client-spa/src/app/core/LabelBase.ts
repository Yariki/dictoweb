import {OnInit} from '@angular/core';
import {LevelsService} from '../services/levels.service';
import {WordService} from '../services/wordservice';
import {TaskItem} from '../models/taskitem';
import {LevelType} from '../models/word';

export class LevelBase implements  OnInit {

  level: string;
  generateTask = true;
  currentTask: TaskItem;
  showNext = false;
  preview: boolean;
  wordsCount: number;

  currentIndex = 0;
  countOfTasks = 0;

  protected tasks: TaskItem[];



  constructor(protected levelService: LevelsService, protected  wordService: WordService) {

  }

  ngOnInit(): void {
    this.level = this.getName();
    this.currentTask = new TaskItem();
    this.updateWordCount();
  }

  onGenerateTask() {

  }

  onSelected(isCorrect: boolean) {
    this.showNext = true;
    if (isCorrect) {
      this.currentTask.word.level = this.getNextLevel();
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
    this.levelService.getLevelCount(this.getCurrentLevel()).then(value => this.wordsCount = value);
  }

  getCurrentLevel(): LevelType {
    return LevelType.None;
  }

  getNextLevel(): LevelType {
    return LevelType.None;
  }

  getName(): string {
    return 'Level Base';
  }

}
