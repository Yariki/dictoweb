import { Component, OnInit } from '@angular/core';
import {DeckService} from '../../services/deck.service';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {Deck} from '../../models/deck';


@Component({
  selector: 'app-deck-details',
  templateUrl: './deck-details.component.html',
  styleUrls: ['./deck-details.component.css']
})
export class DeckDetailsComponent implements OnInit {

  deck: Deck;


  constructor(private deckService: DeckService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.deck = this.deckService.getDeck(+params['id']);
    });
  }

  onEdit() {
    this.router.navigate(['edit'],{relativeTo: this.route});
  }

}
