import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorPassword } from '@app/helpers/ValidatorPassword';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.scss']
})
export class PerfilComponent implements OnInit {

  form: FormGroup;
   get f(){
    return this.form.controls;
  }

  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.validation();
  }
    private validation(): void{
      const formOptions: AbstractControlOptions ={
        validators: ValidatorPassword.MusMatch('senha', 'confirmaSenha')
        }
      this.form = this.fb.group({
        titulo: ['', [Validators.required], Validators.minLength(4)],
        primeiroNome: ['', [Validators.required], Validators.minLength(4)],
        ultimoNome: ['', [Validators.required], Validators.minLength(4)],
        email: ['', [Validators.required, Validators.email]],
        telefone: ['', Validators.required],
        funcao: ['', Validators.required],
        descricao: ['', Validators.required],
        senha: ['', [Validators.required], Validators.minLength(4)],
        confirmaSenha: ['', Validators.required],
      },formOptions)
    }
}
