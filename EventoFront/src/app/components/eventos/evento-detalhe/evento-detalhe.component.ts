import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';

@Component({
  selector: 'app-evento-detalhe',
  templateUrl: './evento-detalhe.component.html',
  styleUrls: ['./evento-detalhe.component.scss']
})
export class EventoDetalheComponent implements OnInit {
  form: FormGroup;
  public Dsconfig(): any{
    return{
    adaptivePosition: true ,
    dateInputFormat: 'DD/MM/YYYY hh:mm a',
    containerClass: 'theme-default',
    showWeekNumbers: false
  };
  }
  get f(): any {
    return this.form.controls;
  }
  constructor(private fb: FormBuilder, private localeService: BsLocaleService) {
    this.localeService.use('pt-Br');

   }

  ngOnInit(): void {
    this.validation();
  }

  public validation(): void{
    this.form = this.fb.group({
      tema: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      local: ['', Validators.required],
      dataEvento: ['', Validators.required],
      qtdPessoas: ['', [Validators.required, Validators.max(1200000) ]],
      imageUrl: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      telefone: ['', Validators.required]
    });
  }

  public resetForm(): void{
    this.form.reset();
  }
}
