import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HeaderComponent } from './core/header/header.component';
import { HomeComponent } from './core/home/home.component';
import {AuthModule} from './auth/auth.module';

import {AppRoutingModule} from './app-routing.module';
import {AuthService} from './services/auth.service';
import {HttpService} from './services/http.service';
import {CommonModule} from '@angular/common';
import {AuthGuardService} from './auth/auth-guard.service';
import {WordService} from './services/wordservice';
import { Level1Component } from './levels/level1/level1.component';
import { LeveltasklistComponent } from './levels/leveltasklist/leveltasklist.component';
import {LevelsService} from './services/levels.service';
import { Level2Component } from './levels/level2/level2.component';
import { Level3Component } from './levels/level3/level3.component';
import {DeckModule} from './decks/deck.module';
import {DeckService} from './services/deck.service';
import { WordListComponent } from './words/word-list/word-list.component';
import { WordDetailComponent } from './words/word-detail/word-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    Level1Component,
    LeveltasklistComponent,
    Level2Component,
    Level3Component,
    WordListComponent,
    WordDetailComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    AuthModule,
    AppRoutingModule,
    DeckModule
  ],
  providers: [AuthService, HttpService, AuthGuardService,  WordService, LevelsService, DeckService],

  bootstrap: [AppComponent]
})
export class AppModule { }
