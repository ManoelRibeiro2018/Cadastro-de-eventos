import { Component, OnInit } from '@angular/core';
import { AbstractControl, AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorPassword } from '@app/helpers/ValidatorPassword';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  form: FormGroup;

  get f(){
   return this.form.controls;
  }

  constructor(private fb : FormBuilder) { }

  ngOnInit(): void {
    this.validation();
  }

  private validation(): void{
    const formOptions: AbstractControlOptions ={
    validators: ValidatorPassword.MusMatch('senha', 'confirmaSenha')
    }
    this.form = this.fb.group({
      primeiroNome: ['', Validators.required],
      ultimoNome: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      usuario: ['', Validators.required],
      senha: ['', [Validators.required, Validators.minLength(6)]],
      confirmaSenha: ['', Validators.required],
    },formOptions);
  }

}
