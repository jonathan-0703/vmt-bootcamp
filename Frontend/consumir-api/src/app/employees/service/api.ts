import { inject, Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from '../interfaces/employees';
import { enviroment } from '../../enviroment';


@Injectable({
  providedIn: 'root',
})
export class Api {

  private apiUrl = enviroment.apiUrl;
  private _http = inject(HttpClient);


  getEmployees(): Observable<Employee[]> {
    return this._http.get<Employee[]>(`${this.apiUrl}/employees`);
  }

  getEmployeeById(id: string) {
    return this._http.get<Employee>(`${this.apiUrl}/employees/${id}`);
  }
  crearEmeployee(employee: Partial<Employee>): Observable<Employee> {
    return this._http.post<Employee>(`${this.apiUrl}/employees`, employee);
  }

  updateEmployee(id: string, employee: Partial<Employee>): Observable<Employee> {
    return this._http.put<Employee>(`${this.apiUrl}/employees/${id}`, employee);
  }

  deleteEmployee(id: string): Observable<void> {
    return this._http.delete<void>(`${this.apiUrl}/employees/${id}`);
  }


}
