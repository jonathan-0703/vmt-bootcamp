import { Component, inject, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DynamicFormModal } from '../../../shared/components/dynamic-form-modal/dynamic-form-modal';


import { Api } from '../service/api';

import { CustomCard } from '../../../shared/components/custom-card/custom-card';
import { DynamicField } from '../../../shared/components/dynamic-form-modal/interfaces/dynamic';
import { MatButtonModule } from '@angular/material/button';
import { MatIcon } from "@angular/material/icon";
import { IChef } from '../interfaces/chefs';

@Component({
  selector: 'app-chefs',
  standalone: true,
  imports: [
    CommonModule,
    CustomCard,
    DynamicFormModal,
    MatButtonModule,
    MatIcon
  ],
  templateUrl: './chefs.html',
  styleUrl: './chefs.scss',
})
export class Chefs implements OnInit {


  chefFields: DynamicField[] = [

    {
      key: 'name',
      label: 'Name',
      type: 'text',
      required: true
    },
    {
      key: 'gender',
      label: 'Gender',
      type: 'text',
      required: true
    },
    {
      key: 'city',
      label: 'City',
      type: 'text',
      required: true
    },
    {
      key: 'country',
      label: 'Country',
      type: 'text',
      required: true
    }
  ];

  formMode =
    signal<'create' | 'edit'>(
      'create'
    );
  isFormOpen = signal(false);
  selectedChef = signal<IChef | null>(null);


  isModalOpen = signal(false);
  openMenuId: string | null = null;

  private apiService = inject(Api);



  chefs = signal<IChef[]>([]);
  chefDetails = signal<IChef | null>(null);


  ngOnInit() {
    this.loadChefs();
  }

  toggleMenu(id: string) {
    this.openMenuId = this.openMenuId === id ? null : id;
  }

  closeMenu() {
    this.openMenuId = null;
  }

  closeModal() {
    this.isModalOpen.set(false);
  }

  openCreateModal() {

    this.formMode.set('create');

    this.selectedChef.set(null);

    this.isFormOpen.set(true);

  }

  openEditModal(chef: IChef) {

    this.formMode.set('edit');

    this.selectedChef.set(chef);

    this.isFormOpen.set(true);

  }

  closeFormModal() {

    this.isFormOpen.set(false);

  }

  loadChefs() {
    this.apiService.getChefs().subscribe({
      next: (data) => this.chefs.set(data),
      error: (error) => console.error(error)
    });
  }

  loadChefDetails(id: string) {
    this.apiService.getChefById(id).subscribe({
      next: (res) => {
        this.chefDetails.set(res);
        this.isModalOpen.set(true);
      },
      error: console.error
    });
  }

  saveChef(chefData: Partial<IChef>) {

    const currentChef =
      this.selectedChef();

    if (currentChef) {

      this.apiService
        .updateChef(
          currentChef.id,
          chefData
        )
        .subscribe({

          next: () => {

            this.loadChefs();

            this.closeFormModal();

          },

          error: console.error

        });

      return;
    }
    this.apiService
      .createChef(chefData)
      .subscribe({

        next: () => {

          this.loadChefs();

          this.closeFormModal();

        },

        error: console.error

      });

  }

  deleteChef(id: string) {
    this.apiService.deleteChef(id).subscribe({
      next: () => {
        console.log('Chef deleted');
        this.loadChefs();
      },
      error: (error) => console.error('Error deleting student:', error)
    });
  }

}
