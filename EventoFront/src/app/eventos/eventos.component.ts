import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Evento } from '../models/Evento';
import { EventoService } from '../services/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
})
export class EventosComponent implements OnInit {
  modalRef: BsModalRef;
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
  constructor(private eventoService: EventoService, private modalService: BsModalService,  private toastr: ToastrService) {}

  ngOnInit(): void {
    this.GetEventos();
  }

  public GetEventos(): void {
    const observer = {
      next: (evento: Evento[]) => {
        this.eventos = evento;
        this.eventosFiltrado = this.eventos;
      },
      error: (error: any) => console.log(error)
    };
    this.eventoService.getEvento().subscribe(observer);
  }
  openModal(template: TemplateRef<any>): void{
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef.hide();
    this.toastr.success('Deletado com sucesso!');
  }

  decline(): void {
    this.modalRef.hide();
  }


}
