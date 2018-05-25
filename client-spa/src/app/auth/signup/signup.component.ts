import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, NgForm, Validators} from '@angular/forms';
import {Registrationvalidator} from '../../shared/helpers/registrationvalidator';
import {AuthService} from '../../services/auth.service';
import {User} from '../../models/user';
import {Router} from '@angular/router';

@Component({
  selector: 'app-singup',
  templateUrl: './singup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  registrationFormGroup: FormGroup;
  passwordsGroup: FormGroup;


  constructor(private formBuilder: FormBuilder, private authService: AuthService, private router: Router ) {
    this.passwordsGroup = this.formBuilder.group({
      password: ['', Validators.required],
      retypepassword: ['', Validators.required]
    }, {
      validator: Registrationvalidator.validate.bind(this)
    });

    this.registrationFormGroup = this.formBuilder.group({
      firstname: ['', Validators.required],
      lastname: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      passwordGroup: this.passwordsGroup
    });
  }

  ngOnInit() {
  }

  onSignUp() {
    const user = new User();
    user.firstname = this.registrationFormGroup.controls.firstname.value;
    user.lastname = this.registrationFormGroup.controls.lastname.value;
    user.email = this.registrationFormGroup.controls.email.value;
    user.password = this.passwordsGroup.controls.password.value;

    this.authService.singup(user).then(res => {
      if (res) {
        this.router.navigate(['/']);
      }
    });
  }
}
