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
  private filtroListado = '';
  public eventosFiltrado: Evento[] = [];
  public get filtroLista(): string{
   return this.filtroListado;
  }

  public set filtroLista(value: string){
     this.filtroListado = value;
     this.eventosFiltrado = this.filtroLista ? this.filtroEventos(this.filtroLista) : this.eventos;
  }

  public filtroEventos(filtrarPor: string): Evento[]{
  filtrarPor = filtrarPor.toLocaleLowerCase();
  return this.eventos.filter(
    evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
    evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
  );
}
  constructor(private eventoService: EventoService) {}

  ngOnInit(): void {
    this.GetEventos();
  }

  public GetEventos(): void {
    const observer = {
      next: (evento: Evento[]) =>{
        this.eventos = evento;
        this.eventosFiltrado = this.eventos;
      },
      error: (error: any) => console.log(error)
    }
    this.eventoService.getEvento().subscribe(observer);
  }
}
