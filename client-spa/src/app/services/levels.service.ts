import {Injectable} from '@angular/core';
import {HttpService} from './http.service';
import {TaskItem} from '../models/taskitem';
import {Pazzleitem} from '../models/pazzleitem';
import {LevelType} from '../models/word';

@Injectable()
export class LevelsService {


  constructor(private httpService: HttpService) {
  }

  createTaskLevel1(): Promise<TaskItem[]> {

    const promise = new Promise<TaskItem[]>( resolve => {
      this.httpService.get<TaskItem[]>('level/level1',null).then(result => {
        resolve(result);
      });
    });

    return promise;
  }


  createTaskLevel2(): Promise<TaskItem[]> {
    const promise = new Promise<TaskItem[]>( resolve => {
      this.httpService.get<TaskItem[]>('level/level2',null).then(result => {
        resolve(result);
      });
    });

    return promise;
  }

  createTaskLevel3(): Promise<Pazzleitem[]> {
    const promise = new Promise<Pazzleitem[]>(resolve => {
      this.httpService.get<Pazzleitem[]>('level/level3', null).then( result => {
        resolve(result);
      });
    });
    return promise;
  }

  getLevelCount(level: LevelType): Promise<number> {
    const promise = new Promise<number>(resolve => {
      this.httpService.get<number>('level/levelcount', {level: level}).then(result => {
        resolve(result);
      });
    });

    return promise;
  }


}
