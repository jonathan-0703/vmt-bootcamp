import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';


import { Observable } from 'rxjs';


import { enviroment } from '../../../enviroment/Enviroment';
import { IRecipe } from '../interfaces/recipes';



@Injectable({
  providedIn: 'root',
})
export class Api {

  // URL base de la API
  private apiUrl = enviroment.apiUrl;
  private _http = inject(HttpClient);


  // API para consultar

  getRecipes(): Observable<IRecipe[]> {
    return this._http.get<IRecipe[]>(`${this.apiUrl}/recipes`)
  }


  // API para consultar por ID
  getRecipeById(id: string) {
    return this._http.get<IRecipe>(`${this.apiUrl}/recipes/${id}`);
  }

  // API para crear
  createRecipe(recipe: Partial<IRecipe>): Observable<IRecipe> {
    return this._http.post<IRecipe>(`${this.apiUrl}/recipes`, recipe);
  }



  // API para actualizar
  updateRecipe(id: string, recipe: Partial<IRecipe>): Observable<IRecipe> {
    return this._http.put<IRecipe>(`${this.apiUrl}/recipes/${id}`, recipe);
  }



  // API para eliminar
  deleteRecipe(id: string): Observable<void> {
    return this._http.delete<void>(`${this.apiUrl}/recipes/${id}`);
  }

}


