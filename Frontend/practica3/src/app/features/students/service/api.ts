import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { Student } from '../interfaces/students';
import { enviroment } from '../../../Enviroment';





@Injectable({
  providedIn: 'root',
})
export class Api {

  // URL base de la API
  private apiUrl = enviroment.apiUrl;
  private _http = inject(HttpClient);


  // API para consultar
  getStudents(): Observable<Student[]> {
    return this._http.get<Student[]>(`${this.apiUrl}/students`)
  }



  // API para consultar por ID
  getStudentById(id: string) {
    return this._http.get<Student>(`${this.apiUrl}/students/${id}`);
  }


  // API para crear
  createStudent(student: Partial<Student>): Observable<Student> {
    return this._http.post<Student>(`${this.apiUrl}/students`, student);
  }



  // API para actualizar
  updateStudent(id: string, student: Partial<Student>): Observable<Student> {
    return this._http.put<Student>(`${this.apiUrl}/students/${id}`, student);
  }


  // API para eliminar
  deleteStudent(id: string): Observable<void> {
    return this._http.delete<void>(`${this.apiUrl}/students/${id}`);
  }

}


