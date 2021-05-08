import { Component, OnInit } from '@angular/core';
import { Evento } from '../models/Evento';
import { EventoService } from '../services/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
})
export class EventosComponent implements OnInit {
  public eventos: Evento[] = [];
  private _filtroLista: string = '';
  public eventosFiltrado: Evento[] = [];
  public get filtroLista(): string{
   return this._filtroLista;
  }

  public set filtroLista(value: string){
     this._filtroLista = value;
     this.eventosFiltrado = this.filtroLista ? this.filtroEventos(this.filtroLista) : this.eventos;
  }

  public filtroEventos(filtrarPor: string): Evento[]{
  filtrarPor = filtrarPor.toLocaleLowerCase();
  console.log(filtrarPor)
  return this.eventos.filter(
    evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
    evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
  )
}
  constructor(private eventoService: EventoService) {}

  ngOnInit(): void {
    this.GetEventos();
  }

  public GetEventos(): void {
    this.eventoService.getEvento().subscribe(
      (_evento: Evento[]) =>{
        this.eventos = _evento
        this.eventosFiltrado = this.eventos;
      },

      error => console.log(error)
    )
  }
}
