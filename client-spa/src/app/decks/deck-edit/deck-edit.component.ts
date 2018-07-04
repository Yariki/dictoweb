import { Component, OnInit } from '@angular/core';
import {DeckService} from '../../services/deck.service';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {Deck} from '../../models/deck';

@Component({
  selector: 'app-deck-edit',
  templateUrl: './deck-edit.component.html',
  styleUrls: ['./deck-edit.component.css']
})
export class DeckEditComponent implements OnInit {

  id: number;
  editMode = false;
  deckForm: FormGroup;

  private currentDeck: Deck;

  constructor( private deckService: DeckService, private router: Router, private route: ActivatedRoute ) { }

  ngOnInit() {

    this.route.params.subscribe((params: Params) => {
      this.id = +params['id'];
      this.editMode = params['id'] != null;
      this.initForm();
    });
  }

  private initForm() {
    let deckName = '';
    let deckDescription = '';
    if (this.editMode) {
      this.currentDeck = this.deckService.getDeck(this.id);
      if (this.currentDeck != null) {
        deckName = this.currentDeck.name;
        deckDescription = this.currentDeck.description;
      }
    }
    this.deckForm = new FormGroup({
      'name': new FormControl(deckName, Validators.required),
      'description': new FormControl(deckDescription)
    });
  }

  onSubmit() {
    if (this.editMode && this.currentDeck !== null) {
      this.currentDeck.name = this.deckForm.value['name'];
      this.currentDeck.description = this.deckForm.value['description'];
      this.deckService.edit(this.currentDeck).then(result => {
        this.onCancel();
      });
    } else {
      const deck = new Deck();
      deck.name = this.deckForm.value['name'];
      deck.description = this.deckForm.value['description'];
      this.deckService.add(deck).then(reuslt => {
        this.onCancel();
      });
    }

  }

  onCancel() {
    this.router.navigate(['../'], {relativeTo: this.route});
    this.deckService.refresh();
  }

}
