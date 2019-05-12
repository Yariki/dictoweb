import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatchfieldsDirective} from './directives/match-fields/matchfields.directive';
import {Registrationvalidator} from './helpers/registrationvalidator';
import { HighlightDirective } from './directives/highlight/highlight.directive';
import {DeleteMessage} from './messages/delete.message';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [
    MatchfieldsDirective,
    HighlightDirective,
    DeleteMessage
  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatchfieldsDirective,
    HighlightDirective,
    DeleteMessage
  ],
  entryComponents: [DeleteMessage]
})
export class SharedModule { }
