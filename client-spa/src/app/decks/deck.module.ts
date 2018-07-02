import {NgModule} from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {SharedModule} from '../shared/shared.module';
import {AuthRoutingModule} from '../auth/auth-routing.module';
import {HttpClientModule} from '@angular/common/http';
import {CommonModule} from '@angular/common';
import {DeckListComponent} from './deck-list/deck-list.component';
import {DeckComponent} from './deck.component';
import {DeckRoutingModule} from './deck.routing-module';
import {DeckStartComponent} from './deck-start/deck-start.component';
import {DeckDetailsComponent} from './deck-details/deck-details.component';
import { DeckItemComponent } from './deck-list/deck-item/deck-item.component';


@NgModule({
  declarations: [
    DeckListComponent,
    DeckComponent,
    DeckStartComponent,
    DeckDetailsComponent,
    DeckItemComponent
  ],
  imports: [
    FormsModule,
    AuthRoutingModule,
    HttpClientModule,
    SharedModule,
    DeckRoutingModule
  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class DeckModule {

}
