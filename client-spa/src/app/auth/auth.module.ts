import {NgModule} from '@angular/core';
import {SignupComponent} from './signup/signup.component';
import {SigninComponent} from './signin/signin.component';
import {FormsModule} from '@angular/forms';
import {AuthRoutingModule} from './auth-routing.module';
import {AuthGuardService} from './auth-guard.service';
import {HttpClientModule} from '@angular/common/http';
import {SharedModule} from '../shared/shared.module';

@NgModule( {
  declarations: [
    SignupComponent,
    SigninComponent
  ],
  imports: [
    FormsModule,
    AuthRoutingModule,
    HttpClientModule,
    SharedModule
  ],
})
export class AuthModule {
}
