
import {Injectable} from '@angular/core';
import {HttpService} from './http.service';
import {Memoryinfo} from '../models/memoryinfo';


@Injectable()
export class MemoryService {

  constructor (private httpService: HttpService) {}

  getStatistic (): Promise<Memoryinfo> {
    const promise = new Promise<Memoryinfo>(resolve => {
      this.httpService.get<Memoryinfo>('memory/statistic', {}).then(value => {
        resolve(value);
      });
    });

    return promise;
  }


}
