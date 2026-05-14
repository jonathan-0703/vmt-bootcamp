import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { enviroment } from '../../../enviroment/Enviroment';
import { IChef } from '../interfaces/chefs';

@Injectable({
  providedIn: 'root',
})
export class Api {

  // URL base de la API
  private apiUrl = enviroment.apiUrl;
  private _http = inject(HttpClient);


  // API para consultar
  getChefs(): Observable<IChef[]> {
    return this._http.get<IChef[]>(`${this.apiUrl}/chefs`)
  }
  // API para consultar por ID
  getChefById(id: string) {
    return this._http.get<IChef>(`${this.apiUrl}/chefs/${id}`);
  }


  // API para crear
  createChef(chef: Partial<IChef>): Observable<IChef> {
    return this._http.post<IChef>(`${this.apiUrl}/chefs`, chef);
  }



  // API para actualizar
  updateChef(id: string, chef: Partial<IChef>): Observable<IChef> {
    return this._http.put<IChef>(`${this.apiUrl}/chefs/${id}`, chef);
  }


  // API para eliminar
  deleteChef(id: string): Observable<void> {
    return this._http.delete<void>(`${this.apiUrl}/chefs/${id}`);
  }

}


