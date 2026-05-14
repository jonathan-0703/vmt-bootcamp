import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Department } from '../interfaces/departments';
import { enviroment } from '../../enviroment';


@Injectable({
  providedIn: 'root',
})
export class Api {

  private apiUrl = enviroment.apiUrl;
  private _http = inject(HttpClient);



  getdepartments(): Observable<Department[]> {
    return this._http.get<Department[]>(`${this.apiUrl}/departments`)
  }

  getDepartmentById(id: string) {
    return this._http.get<Department>(`${this.apiUrl}/departments/${id}`);
  }

  crearDepartment(department: Partial<Department>): Observable<Department> {
    return this._http.post<Department>(`${this.apiUrl}/departments`, department);
  }

  updateDepartment(id: string, department: Partial<Department>): Observable<Department> {
    return this._http.put<Department>(`${this.apiUrl}/departments/${id}`, department);
  }

  deleteDepartment(id: string): Observable<void> {
    return this._http.delete<void>(`${this.apiUrl}/departments/${id}`);
  }
}
