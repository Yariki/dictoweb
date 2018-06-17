import { Component, OnInit } from '@angular/core';
import {LetterItem} from '../../models/letteritem';

@Component({
  selector: 'app-level3',
  templateUrl: './level3.component.html',
  styleUrls: ['./level3.component.css']
})
export class Level3Component implements OnInit {

  letters: LetterItem[] = [
    new LetterItem('e', 5),
    new LetterItem('h', 1),
    new LetterItem('c', 0),
    new LetterItem('r', 2),
    new LetterItem('o', 3),
    new LetterItem('m', 4),
  ];

  words: LetterItem[] = [] ;

  private currentCorrectIndex = 0;


  constructor() {
    // chrome
    //  c-0 h-1 r-2 o-3 m-4 e-5

  }

  ngOnInit() {
  }


  onItemCLick(obj: any, index: number) {
    const item = this.letters[index];
    if (item.order === this.currentCorrectIndex) {
      this.words.push(item);
      this.currentCorrectIndex++;
      this.letters[index] = new LetterItem('', -1);
    } else {
      this.letters.sort((l, r): number => {
        if (l.order < r.order) {return -1; }
        if (l.order > r.order) {return 1; }
        return 0;
      });

      for (let i = 0; i < this.letters.length; i++ ) {
        if (this.letters[i].order === -1) {continue; }
        this.words.push(this.letters[i]);
      }



    }
  }

}
