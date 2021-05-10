import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ModalModule } from 'ngx-bootstrap/modal';
import {ToastrModule} from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventosComponent } from './components/eventos/eventos.component';
import { PalestrantesComponent } from './components/palestrantes/palestrantes.component';
import { NavComponent } from './shared/nav/nav.component';
import { FormsModule } from '@angular/forms';
import { EventoService } from './services/evento.service';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { ContatosComponent } from './components/contatos/contatos.component';
import { PerfilComponent } from './components/perfil/perfil.component';
import { DasboardComponent } from './components/dasboard/dasboard.component';
import { TituloComponent } from './shared/Titulo/Titulo.component';


@NgModule({
  declarations: [
    AppComponent,
    EventosComponent,
    PalestrantesComponent,
    ContatosComponent,
    PerfilComponent,
    DasboardComponent,
    TituloComponent,
      NavComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    FormsModule,
    TooltipModule.forRoot(),
    BsDropdownModule.forRoot(),
    ModalModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-top-right',
      preventDuplicates: true,
      progressBar: true
    }),
    NgxSpinnerModule
  ],
  providers: [EventoService],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],

})
export class AppModule { }
