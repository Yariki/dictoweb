import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatchfieldsDirective} from './directives/match-fields/matchfields.directive';
import {Registrationvalidator} from './helpers/registrationvalidator';
import { HighlightDirective } from './directives/highlight/highlight.directive';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [
    MatchfieldsDirective,
    HighlightDirective

  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatchfieldsDirective,
    HighlightDirective
  ]
})
export class SharedModule { }
