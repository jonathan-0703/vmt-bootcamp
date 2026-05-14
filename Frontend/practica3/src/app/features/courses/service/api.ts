import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';


import { Observable } from 'rxjs';

import { Course } from '../interfaces/courses';
import { enviroment } from '../../../Enviroment';


@Injectable({
  providedIn: 'root',
})
export class Api {

  // URL base de la API
  private apiUrl = enviroment.apiUrl;
  private _http = inject(HttpClient);


  // API para consultar

  getCourses(): Observable<Course[]> {
    return this._http.get<Course[]>(`${this.apiUrl}/courses`)
  }


  // API para consultar por ID
  getCourseById(id: string) {
    return this._http.get<Course>(`${this.apiUrl}/courses/${id}`);
  }

  // API para crear
  createCourse(course: Partial<Course>): Observable<Course> {
    return this._http.post<Course>(`${this.apiUrl}/courses`, course);
  }



  // API para actualizar
  updateCourse(id: string, course: Partial<Course>): Observable<Course> {
    return this._http.put<Course>(`${this.apiUrl}/courses/${id}`, course);
  }



  // API para eliminar
  deleteCourse(id: string): Observable<void> {
    return this._http.delete<void>(`${this.apiUrl}/courses/${id}`);
  }

}


