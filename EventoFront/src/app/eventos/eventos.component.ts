import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
})
export class EventosComponent implements OnInit {
  public eventos: any = [];
  private _filtroLista: string = '';
  public eventosFiltrado: any = [];
  public get filtroLista(): string{
   return this._filtroLista;
  }

  public set filtroLista(value: string){
     this._filtroLista = value;
     this.eventosFiltrado = this.filtroLista ? this.filtroEventos(this.filtroLista) : this.eventos;
  }

  filtroEventos(filtrarPor: string): any{
  filtrarPor = filtrarPor.toLocaleLowerCase();
  console.log(filtrarPor)
  return this.eventos.filter(
    evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
    evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
  )
}
  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.GetEventos();
  }

  public GetEventos(): void {
    this.http.get('https://localhost:44310/api/eventos/').subscribe(
      response =>{
        this.eventos = response
        this.eventosFiltrado = this.eventos;
      },

      error => console.log(error)
    )
  }
}
