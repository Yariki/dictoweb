import {FormGroup} from '@angular/forms';

export class Registrationvalidator {

  static validate(registrationFormGroup: FormGroup) {
    const password = registrationFormGroup.controls.password.value;
    const confirmPassword = registrationFormGroup.controls.retypepassword.value;

    if (confirmPassword.lenght <= 0) {
      return null;
    }
    if (confirmPassword !== password) {
      return {
        doesMatchPassword: true
      };
    }
    return null;
  }

}
