import { Component, inject, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';


import { Api } from '../service/api';

import { CustomCard } from '../../../shared/components/custom-card/custom-card';
import { DynamicField } from '../../../shared/components/dynamic-form-modal/interfaces/dynamic';
import { DynamicFormModal } from '../../../shared/components/dynamic-form-modal/dynamic-form-modal';
import { MatButtonModule } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { IRecipe } from '../interfaces/recipes';


@Component({
  selector: 'app-recipes',
  standalone: true,
  imports: [
    CommonModule,
    CustomCard,
    DynamicFormModal,
    MatButtonModule,
    MatIcon
  ],
  templateUrl: './recipes.html',
  styleUrl: './recipes.scss',
})
export class Recipes implements OnInit {

  recipeFields: DynamicField[] = [

    {
      key: 'name',
      label: 'Name',
      type: 'text',
      required: true
    },
    {
      key: 'country',
      label: 'Country',
      type: 'text',
      required: true
    },

    {
      key: 'description',
      label: 'Description',
      type: 'text',
      required: true
    }
  ];

  isModalOpen = signal(false);


  private apiService = inject(Api);

  recipes = signal<IRecipe[]>([]);
  recipesDetails = signal<IRecipe | null>(null);

  formMode =
    signal<'create' | 'edit'>(
      'create'
    );

  isFormOpen = signal(false);
  selectedRecipe = signal<IRecipe | null>(null);

  openCreateModal() {

    this.formMode.set('create');

    this.selectedRecipe.set(null);

    this.isFormOpen.set(true);

  }

  openEditModal(recipe: IRecipe) {

    this.formMode.set('edit');

    this.selectedRecipe.set(recipe);

    this.isFormOpen.set(true);

  }

  closeFormModal() {

    this.isFormOpen.set(false);

  }

  ngOnInit() {
    this.loadRecipes();
  }

  closeModal() {
    this.isModalOpen.set(false);
  }

  loadRecipes() {
    this.apiService.getRecipes().subscribe({
      next: (data) => this.recipes.set(data),
      error: (error) => console.error(error)
    });
  }

  loadRecipeDetails(id: string) {
    this.apiService.getRecipeById(id).subscribe({
      next: (res) => {
        this.recipesDetails.set(res);
        this.isModalOpen.set(true);
      },
      error: console.error
    });
  }
  saveRecipe(recipeData: Partial<IRecipe>) {

    const currentRecipe =
      this.selectedRecipe();

    if (currentRecipe) {

      this.apiService
        .updateRecipe(
          currentRecipe.id,
          recipeData
        )
        .subscribe({

          next: () => {

            this.loadRecipes();

            this.closeFormModal();

          },

          error: console.error

        });

      return;
    }
    this.apiService
      .createRecipe(recipeData)
      .subscribe({

        next: () => {

          this.loadRecipes();

          this.closeFormModal();

        },

        error: console.error

      });

  }



  //Eliminar Receta  
  deleteRecipe(id: string) {
    this.apiService.deleteRecipe(id).subscribe({
      next: () => {
        console.log('Recipe deleted');
        this.loadRecipes();
      },
      error: (error) => console.error('Error deleting recipe:', error)
    });
  }
}
