import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {DeckComponent} from './deck.component';
import {DeckStartComponent} from './deck-start/deck-start.component';
import {DeckDetailsComponent} from './deck-details/deck-details.component';
import {DeckEditComponent} from './deck-edit/deck-edit.component';
import {AuthGuardService} from '../auth/auth-guard.service';

const decksRoutes: Routes = [
  {path: 'decks',  component: DeckComponent, canActivate: [AuthGuardService], children: [
      {path: '', component: DeckStartComponent, canActivate: [AuthGuardService]},
      {path: 'new', component: DeckEditComponent, canActivate: [AuthGuardService]},
      {path: ':id', component: DeckDetailsComponent, canActivate: [AuthGuardService]}
    ]}
]


@NgModule({
  imports: [RouterModule.forChild(decksRoutes)],
  exports: [RouterModule]
})
export class DeckRoutingModule {

}
