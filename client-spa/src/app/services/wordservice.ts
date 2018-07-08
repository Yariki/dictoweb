import {HttpService} from './http.service';
import {Injectable} from '@angular/core';
import {UserWordsInfo} from '../models/userwordsinfo';
import {LevelType, Word} from '../models/word';
import {DeckWords} from '../models/deckwords';

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

  updateLevel(id: number, wordLevel: LevelType) {
    this.httpService.post('word/updatelevel', {wordId: id, level: wordLevel });
  }

  getWordsWithoutDeck(): Promise<Word[]> {
    const promise = new Promise<Word[]>(resolve => {
      this.httpService.get<Word[]>('word/words',{ }).then(result => {
        resolve(result);
      });
    });
    return promise;
  }

  getDeckWords(deckId: number): Promise<Word[]> {
    const promise = new Promise<Word[]>(resolve => {
      this.httpService.get<Word[]>('word/wordsdeck', { deckId: deckId}).then(result => {
        resolve(result);
      });
    });

    return promise;
  }

  updateWordDesk(data: DeckWords): Promise<boolean> {
    const promise = new Promise<boolean>(resolve => {
      this.httpService.post('word/addwordtodeck', data).then(result => {
        resolve(result != null);
      });
    });
    return promise;
  }

  deleteWordDeck(data: DeckWords): Promise<boolean> {
    const promise = new Promise<boolean>(resolve => {
      this.httpService.post('word/deletewordtodeck', data).then(result => {
        resolve(true);
      });
    });
    return promise;
  }



}
