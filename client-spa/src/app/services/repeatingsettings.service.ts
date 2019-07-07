import {Injectable} from '@angular/core';

@Injectable()
export class RepeatingsettingsService {

  private _newwords: number;
  private _minutes: number;

  constructor() {}


  get newwords(): number {
    return this._newwords;
  }

  set newwords(value: number) {
    this._newwords = value;
  }

  get minutes(): number {
    return this._minutes;
  }

  set minutes(value: number) {
    this._minutes = value;
  }
}
