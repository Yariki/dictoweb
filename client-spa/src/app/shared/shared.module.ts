import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatchfieldsDirective} from './directives/match-fields/matchfields.directive';
import {Registrationvalidator} from './helpers/registrationvalidator';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [
    MatchfieldsDirective

  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatchfieldsDirective,
  ]
})
export class SharedModule { }
