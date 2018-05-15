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

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    AuthModule,
    AppRoutingModule,
  ],
  providers: [AuthService, HttpService, AuthGuardService,  WordService],

  bootstrap: [AppComponent]
})
export class AppModule { }
