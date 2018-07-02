import { Component, OnInit } from '@angular/core';
import {DeckService} from '../../services/deck.service';
import {Deck} from '../../models/deck';

@Component({
  selector: 'app-deck-list',
  templateUrl: './deck-list.component.html',
  styleUrls: ['./deck-list.component.css']
})
export class DeckListComponent implements OnInit {

  decks: Deck[];

  constructor(private deckService: DeckService) { }

  ngOnInit() {
    this.deckService.getList().then(result => {
      this.decks = result;
    });
  }

  onNewDeck() {

  }

}
