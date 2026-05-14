import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { enviroment } from '../Enviroment';
import { Flight } from '../flights/interfaces/flights';
import { Observable } from 'rxjs';
import { Passenger } from '../passengers/interfaces/passengers';




@Injectable({
  providedIn: 'root',
})
export class Api {

  // URL base de la API
  private apiUrl = enviroment.apiUrl;
  private _http = inject(HttpClient);


  // API para consultar
  getflights(): Observable<Flight[]> {
    return this._http.get<Flight[]>(`${this.apiUrl}/flights`)
  }
  getpassengers(): Observable<Passenger[]> {
    return this._http.get<Passenger[]>(`${this.apiUrl}/passengers`)
  }


  // API para consultar por ID
  getflightById(id: string) {
    return this._http.get<Flight>(`${this.apiUrl}/flights/${id}`);
  }
  getpassengerById(id: string) {
    return this._http.get<Passenger>(`${this.apiUrl}/passengers/${id}`);
  }

  // API para crear
  crearflight(flight: Partial<Flight>): Observable<Flight> {
    return this._http.post<Flight>(`${this.apiUrl}/flights`, flight);
  }
  crearpassenger(passenger: Partial<Passenger>): Observable<Passenger> {
    return this._http.post<Passenger>(`${this.apiUrl}/passengers`, passenger);
  }


  // API para actualizar
  updateFlight(id: string, flight: Partial<Flight>): Observable<Flight> {
    return this._http.put<Flight>(`${this.apiUrl}/flights/${id}`, flight);
  }
  updatePassenger(id: string, passenger: Partial<Passenger>): Observable<Passenger> {
    return this._http.put<Passenger>(`${this.apiUrl}/passengers/${id}`, passenger);
  }


  // API para eliminar
  deleteFlight(id: string): Observable<void> {
    return this._http.delete<void>(`${this.apiUrl}/flights/${id}`);
  }
  deletePassenger(id: string): Observable<void> {
    return this._http.delete<void>(`${this.apiUrl}/passengers/${id}`);
  }
}


