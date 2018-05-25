import {Directive, Input, OnChanges, SimpleChanges} from '@angular/core';
import {AbstractControl, NG_VALIDATORS, NgModel, ValidationErrors, Validator, ValidatorFn, Validators} from '@angular/forms';

@Directive({
  selector: '[appMatchfields]',
  providers: [{
    provide: NG_VALIDATORS,
    useExisting: MatchfieldsDirective,
    multi: true
  }]
})
export class MatchfieldsDirective implements Validator, OnChanges {

  @Input() appMatchfields: AbstractControl;

  private validationFunction = Validators.nullValidator;

  ngOnChanges(changes: SimpleChanges): void {
    const change = changes['appMatchfields'];
    if (change) {
      const otherFieldModel = change.currentValue;
      this.validationFunction = fieldMatchesValidator(otherFieldModel);
    } else {
      this.validationFunction = Validators.nullValidator;
    }
  }

  validate(c: AbstractControl): ValidationErrors | null {
    return this.validationFunction(c);
  }

}

export function fieldMatchesValidator(otherFieldModel: AbstractControl): ValidatorFn {
  return (control: AbstractControl): ValidationErrors => {
    const result = control.value === otherFieldModel.value;
    if (result) {
      delete otherFieldModel.errors['fieldMatches'];
    } else {
      otherFieldModel.setErrors({'fieldMatches': {match: false}});
    }
    return result ? null : {'fieldMatches': {match: false}};
  };
}
