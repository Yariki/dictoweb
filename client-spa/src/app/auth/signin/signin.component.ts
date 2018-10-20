import { Component, OnInit } from '@angular/core';
import {AuthService} from '../../services/auth.service';
import {NgForm} from '@angular/forms';
import {Router} from '@angular/router';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {

  IsError = false;
  message = '';

  constructor( private authService: AuthService, private router: Router) {
  }

  ngOnInit() {
  }

  onSignIn(form: NgForm) {
    const email = form.value.email;
    const password = form.value.password;

    this.authService.singin(email, password).then((response) => {
      this.IsError = false;
      console.log(response);
      this.router.navigate(['']);
    }).catch(response => {
      this.IsError = true;
      if ( response.error) {
        this.message = response.error;
      }
      console.log(response);
    });
  }

}
