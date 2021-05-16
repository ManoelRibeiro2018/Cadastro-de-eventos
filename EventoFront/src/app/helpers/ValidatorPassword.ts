import { group } from "@angular/animations";
import { AbstractControl, FormGroup } from "@angular/forms";

export class ValidatorPassword {
  static MusMatch(controlName: string, matchingControlName:string): any{
    return(group: AbstractControl) =>{
      const formGroup = group as FormGroup;
      const control = formGroup.controls[controlName];
      const matchingControl = formGroup.controls[matchingControlName];

      if(matchingControl.errors && !matchingControl.errors.MusMatch){
        return null;
      }

      if(control.value != matchingControl.value){
        matchingControl.setErrors({MusMatch:true});
      }else{
        matchingControl.setErrors(null);
      }

      return null;
    }
  }
}
