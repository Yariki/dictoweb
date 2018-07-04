import {Injectable} from '@angular/core';
import {HttpService} from './http.service';
import {Deck} from '../models/deck';
import {Subject} from 'rxjs';

@Injectable()
export class DeckService {

  recipesChanged = new Subject<Deck[]>();

  private decks: Deck[];

  constructor(private httpService: HttpService) {
  }

  getList(): Promise<Deck[]> {
    const promise = new Promise<Deck[]>(resolve => {
      this.httpService.get<any>('deck/list', null).then(result => {
        this.decks = result;
        resolve(result);
      });
    });
    return promise;
  }

  add(deck: Deck): Promise<any>  {
    const promise = new Promise<any>( resolve => {
      this.httpService.post<any>('deck/add', deck).then(result => {
        resolve(result);
      });
    });

    return promise;
  }

  edit(deck: Deck): Promise<any>  {
    const promise = new Promise<any>(resolve => {
      this.httpService.post<any>('deck/edit', deck).then(result => {
        resolve(result);
      });
    });
    return promise;
  }

  getDeck(id: number): Deck {
    return this.decks.find(d => d.id === id);
  }

  refresh() {
    this.getList().then(result => {
      this.recipesChanged.next(this.decks);
    });
  }

}
