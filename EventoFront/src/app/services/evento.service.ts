import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Evento } from '../models/Evento';


@Injectable({
  providedIn: 'root'
})
export class EventoService {
  baseURL = 'https://localhost:44310/api/eventos/';

  constructor(private http: HttpClient) { }

  public getEvento(): Observable<Evento[]>{
    return this.http.get<Evento[]>(this.baseURL);
  }

  public getEventosByTema(tema ): Observable<Evento[]>{
    return this.http.get<Evento[]>(`${this.baseURL}/${tema}`);
  }

  public getEventoById(id): Observable<Evento>{
    return this.http.get<Evento>(`${this.baseURL}/${id}`);
  }
}
