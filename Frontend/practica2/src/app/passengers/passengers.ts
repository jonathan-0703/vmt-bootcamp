import { Component, inject, OnInit, signal } from '@angular/core';

import { Api } from '../service/api';
import { Passenger } from './interfaces/passengers';
import { Flight } from '../flights/interfaces/flights';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-passengers',
  imports: [CommonModule],
  templateUrl: './passengers.html',
  styleUrl: './passengers.scss',
})
export class Passengers implements OnInit {

  //Modal
  isModalOpen = signal(false);
  openMenuId: string | null = null;

  //Funciones para el Modal
  toggleMenu(id: string) {
    this.openMenuId = this.openMenuId === id ? null : id;
  }

  closeMenu() {
    this.openMenuId = null;
  }

  closeModal() {
    this.isModalOpen.set(false);
  }
  //Inyección del Servicio
  private apiService = inject(Api);

  //Datos
  passengers = signal<Passenger[]>([]);
  passengerDetails = signal<Passenger | null>(null);

  ngOnInit() {
    this.loadPassengers();
  }

  // Funciones CRUD
  // Cargar datos
  loadPassengers() {
    this.apiService.getpassengers().subscribe({
      next: (data) => this.passengers.set(data),
      error: (error) => console.error('Error fetching passengers:', error)
    })
  }

  // Cargar detalles Pasajero
  loadPassengerDetails(id: string) {
    this.apiService.getpassengerById(id).subscribe({
      next: (res) => {
        this.passengerDetails.set(res);
        this.isModalOpen.set(true);

      },
      error: console.error
    });
  }
  //Crear Pasajero
  createPassenger() {
    const newPassenger: Partial<Passenger> = {
      nationality: 'Ecuatoriana Created',
      email: 'new.passenger@example.com',
      avatar: 'https://cdn.jsdelivr.net/gh/faker-js/assets-person-portrait/female/512/72.jpg',
      name: 'nv-passenger1 created',

    };

    this.apiService.crearpassenger(newPassenger).subscribe({
      next: (data) => {
        console.log('Passenger created:', data);
        this.loadPassengers();
      },
      error: (error) => console.error('Error creating passenger:', error)
    });

  }

  //Actualizar Pasajero
  updatePassenger(id: string) {
    const updatedPassenger: Partial<Passenger> = {
      name: "Maria -Update",
      email: "maria.-update@example.com",
      nationality: "Ecuatoriana -Updated",
      avatar: 'https://cdn.jsdelivr.net/gh/faker-js/assets-person-portrait/female/512/1.jpg'
    };

    this.apiService.updatePassenger(id, updatedPassenger).subscribe({
      next: (data) => {
        console.log('Passenger updated:', data);
        this.loadPassengers();
      },
      error: (error) => console.error('Error updating passenger:', error)
    });
  }

  //Eliminar Pasajero
  deletePassenger(id: string) {
    this.apiService.deletePassenger(id).subscribe({
      next: () => {
        console.log('Passenger deleted');
        this.loadPassengers();
      },
      error: (error) => console.error('Error deleting passenger:', error)
    });
  }

}
