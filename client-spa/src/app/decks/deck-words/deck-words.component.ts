import { Component, OnInit } from '@angular/core';
import {WordService} from '../../services/wordservice';
import {DeckService} from '../../services/deck.service';
import {Word} from '../../models/word';
import {Deck} from '../../models/deck';
import {ArgumentOutOfRangeError} from 'rxjs';
import {DeckWords} from '../../models/deckwords';

@Component({
  selector: 'app-deck-words',
  templateUrl: './deck-words.component.html',
  styleUrls: ['./deck-words.component.css']
})
export class DeckWordsComponent implements OnInit {

  freeWords: Word[] = [];
  decks: Deck[] = [];
  selectedWords: Word[];
  isChanged: boolean = false;

  private selectedDeck: Deck;
  private deletedWords: Word[];

  constructor(private wordService: WordService, private deckService: DeckService ) {

  }

  ngOnInit() {
    const deck = new Deck();
    deck.id = -1;
    this.decks.push(deck);
    this.updateFreeWords();
    this.deckService.getList().then(result => {
      result.forEach(d => this.decks.push(d));
    });
  }

  onChange(ev: any) {
    this.wordService.getDeckWords(ev).then(result => {
      if (result != null) {
        this.selectedWords = result;
      } else {
        this.selectedWords = [];
      }
      this.deletedWords = [];
    });
    this.isChanged = false;
    const id = +ev;
    this.selectedDeck = this.decks.filter(d => d.id === id)[0];
  }

  onAddWordToDeck(index: number) {
    if (index > -1 && this.selectedWords != null) {
      const word = this.freeWords[index];
      this.freeWords.splice(index, 1);
      this.selectedWords.push(word);
      this.isChanged = true;
    }
  }

  onRemoveWordFromDeck(index: number) {
    if (this.deletedWords != null && index > -1 && index < this.selectedWords.length) {
      const word = this.selectedWords[index];
      this.selectedWords.splice(index, 1);
      this.deletedWords.push(word);
      this.isChanged = true;
    }
  }

  onSave() {

    if (this.deletedWords.length > 0) {
      const deleteWords = new DeckWords();
      deleteWords.deckid = null;
      deleteWords.wordids =  [];
      this.deletedWords.forEach(w => deleteWords.wordids.push(w.id));
      this.wordService.deleteWordDeck(deleteWords).then(result => {
        this.saveWords();
      });
    } else {
      this.saveWords();
    }
  }

  private saveWords() {
    if (this.selectedDeck != null && this.selectedWords != null && this.selectedWords.length > 0) {
      const wordsDeck = new DeckWords();
      wordsDeck.deckid = this.selectedDeck.id;
      wordsDeck.wordids = [];
      this.selectedWords.forEach(w => wordsDeck.wordids.push(w.id));
      this.wordService.updateWordDesk(wordsDeck).then(result => {
        this.isChanged = false;
        this.updateFreeWords();
      });
    } else {
      this.updateFreeWords();
    }
  }

  private updateFreeWords() {
    this.wordService.getWordsWithoutDeck().then(result => {
      this.freeWords = result;
    });
  }

}
