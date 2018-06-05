import {HttpService} from './http.service';
import {Injectable} from '@angular/core';
import {UserWordsInfo} from '../models/userwordsinfo';
import {Word} from '../models/word';

@Injectable()
export class WordService {

  constructor(private  httpService: HttpService) {}

  getWordsInfo(): Promise<UserWordsInfo> {
    const promise = new Promise<UserWordsInfo>(resolve => {
      this.httpService.get<UserWordsInfo>('word/wordsinfo', {}).then(result => {
        resolve(result);
      });
    });
    return promise;
  }

  updateWord(word: Word): void {
    this.httpService.post('word/update', word);
  }

}
