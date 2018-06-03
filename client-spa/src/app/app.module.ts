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

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    Level1Component,
    LeveltasklistComponent,
  ],
  imports: [
    BrowserModule,
    CommonModule,
    AuthModule,
    AppRoutingModule,
  ],
  providers: [AuthService, HttpService, AuthGuardService,  WordService, LevelsService],

  bootstrap: [AppComponent]
})
export class AppModule { }
