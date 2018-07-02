import {Injectable} from '@angular/core';
import {HttpService} from './http.service';
import {Deck} from '../models/deck';

@Injectable()
export class DeckService {

  constructor(private httpService: HttpService) {
  }

  getList(): Promise<Deck[]> {
    const promise = new Promise<Deck[]>(resolve => {
      this.httpService.get<any>('deck/list', null).then(result => {
        resolve(result.result);
      });
    });
    return promise;
  }

  add(deck: Deck)  {
    this.httpService.post<any>('deck/add', deck);
  }

  edit(deck: Deck) {
    this.httpService.post<any>('deck/edit', deck);
  }

}
