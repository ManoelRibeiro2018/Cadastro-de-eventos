import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Evento } from '../../../models/Evento';
import { EventoService } from '../../../services/evento.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { Router } from '@angular/router';

@Component({
  selector: 'app-evento-lista',
  templateUrl: './evento-lista.component.html',
  styleUrls: ['./evento-lista.component.scss']
})
export class EventoListaComponent implements OnInit {

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
  // tslint:disable-next-line: max-line-length
  constructor(private eventoService: EventoService, private modalService: BsModalService,  private toastr: ToastrService, private spinner: NgxSpinnerService, private router: Router) {}

  ngOnInit(): void {
    this.GetEventos();
    this.spinner.show();

    setTimeout(() => {
     /** spinner ends after 5 seconds */
   }, 5000);
  }

  public GetEventos(): void {
    const observer = {
      next: (evento: Evento[]) => {
        this.eventos = evento;
        this.eventosFiltrado = this.eventos;
      },
      error: (error: any) =>{
        this.spinner.hide();
        this.toastr.error('Erro ao carregar os eventos');
      },
      complete: () => this.spinner.hide()
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

  detalheEvento(id: number): void{
    this.router.navigate([`eventos/detalhe/${id}`]);
  }

}
