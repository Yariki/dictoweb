import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {DeckComponent} from './deck.component';
import {DeckStartComponent} from './deck-start/deck-start.component';
import {DeckDetailsComponent} from './deck-details/deck-details.component';

const decksRoutes: Routes = [
  {path: 'decks',  component: DeckComponent, children: [
      {path: '', component: DeckStartComponent},
      {path: ':id', component: DeckDetailsComponent}
    ]}
]


@NgModule({
  imports: [RouterModule.forChild(decksRoutes)],
  exports: [RouterModule]
})
export class DeckRoutingModule {

}
