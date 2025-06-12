import { Injectable } from '@angular/core';
import { Usluga } from '../models/usluga';
import { Observable, of } from 'rxjs';
import { UslugaBody } from '../models/usluga-body';

@Injectable({
  providedIn: 'root'
})
export class ListaService {
  private readonly API_URL = 'https://localhost:5010/api/uslugi';

  constructor(private http: HttpClient) {}

  get(): Observable<Usluga[]> {
    return this.http.get<Usluga[]>(this.API_URL);
  }

  getByID(id: number): Observable<Usluga> {
    return this.http.get<Usluga>(`${this.API_URL}/${id}`);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.API_URL}/${id}`);
  }

  put(id: number, body: UslugaBody): Observable<void> {
    return this.http.put<void>(`${this.API_URL}/${id}`, body);
  }

  post(body: UslugaBody): Observable<void> {
    return this.http.post<void>(this.API_URL, body);
  }
}
