import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SupermemoryComponent } from './supermemory.component';
import { SmsettingsComponent } from './smsettings/smsettings.component';
import { SmrepeatingComponent } from './smrepeating/smrepeating.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {AuthRoutingModule} from '../auth/auth-routing.module';
import {HttpClientModule} from '@angular/common/http';
import {SharedModule} from '../shared/shared.module';
import {DeckRoutingModule} from '../decks/deck.routing-module';
import {SupermemoryRoutingModule} from './supermemory.routing-module';

@NgModule({
  declarations: [SupermemoryComponent, SmsettingsComponent, SmrepeatingComponent],
  imports: [
    CommonModule,
    FormsModule,
    AuthRoutingModule,
    HttpClientModule,
    SharedModule,
    SupermemoryRoutingModule
  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class SupermemoryModule { }
