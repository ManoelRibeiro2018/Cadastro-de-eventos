import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContatosComponent } from './components/contatos/contatos.component';
import { DasboardComponent } from './components/dasboard/dasboard.component';
import { EventosComponent } from './components/eventos/eventos.component';

import { PalestrantesComponent } from './components/palestrantes/palestrantes.component';
import { PerfilComponent } from './components/perfil/perfil.component';

const routes: Routes = [
  {path: 'eventos', component: EventosComponent},
  {path: 'palestrante', component: PalestrantesComponent},
  {path: 'contatos', component: ContatosComponent},
  {path: 'perfil', component: PerfilComponent},
  {path: 'dasboard', component: DasboardComponent},
  {path: '', redirectTo: 'dasboard', pathMatch: 'full'},
  {path: '**', redirectTo: 'dasboard', pathMatch: 'full'}


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
   declarations: [
  ]
})
export class AppRoutingModule { }
