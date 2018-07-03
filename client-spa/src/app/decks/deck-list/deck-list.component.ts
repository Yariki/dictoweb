import {Component, OnDestroy, OnInit} from '@angular/core';
import {DeckService} from '../../services/deck.service';
import {Deck} from '../../models/deck';
import {ActivatedRoute, Router} from '@angular/router';
import {Subscription} from 'rxjs';

@Component({
  selector: 'app-deck-list',
  templateUrl: './deck-list.component.html',
  styleUrls: ['./deck-list.component.css']
})
export class DeckListComponent implements OnInit, OnDestroy {

  decks: Deck[];
  private subcription: Subscription;

  constructor(private deckService: DeckService, private router: Router, private activeRoute: ActivatedRoute) { }

  ngOnDestroy(): void {
    this.subcription.unsubscribe();
  }

  ngOnInit() {
    this.deckService.getList().then(result => {
      this.decks = result;
    });
    this.subcription =  this.deckService.recipesChanged.subscribe((result: Deck[]) => {
      this.decks = result;
    });
  }

  onNewDeck() {
    this.router.navigate(['new'],{ relativeTo: this.activeRoute});
  }

}
