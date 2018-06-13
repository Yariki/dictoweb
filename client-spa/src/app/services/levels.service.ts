import {Injectable} from '@angular/core';
import {HttpService} from './http.service';
import {TaskItem} from '../models/taskitem';

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


}
