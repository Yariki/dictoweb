import {Component, Input, OnInit} from '@angular/core';
import {Deck} from '../../../models/deck';

@Component({
  selector: 'app-deck-item',
  templateUrl: './deck-item.component.html',
  styleUrls: ['./deck-item.component.css']
})
export class DeckItemComponent implements OnInit {

  @Input() deck: Deck;

  constructor() { }

  ngOnInit() {
  }

}
