import { Component, inject, OnInit, signal } from '@angular/core';
import { Api } from '../service/api';
import { Flight } from './interfaces/flights';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-flights',
  imports: [CommonModule],
  templateUrl: './flights.html',
  styleUrl: './flights.scss',
})
export class Flights implements OnInit {


  //Modal
  isModalOpen = signal(false);
  openMenuId: string | null = null;
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
  flights = signal<Flight[]>([]);
  flightDetails = signal<Flight | null>(null);

  ngOnInit() {
    this.loadFlights();
  }

  //Funciones CRUD
  // Cargar datos
  loadFlights() {
    this.apiService.getflights().subscribe({
      next: (data) => this.flights.set(data),
      error: (error) => console.error('Error fetching flights:', error)
    })
  }

  // Cargar detalles
  loadFlightDetails(id: string) {
    this.apiService.getflightById(id).subscribe({
      next: (res) => {
        this.flightDetails.set(res);
        this.isModalOpen.set(true);

      },
      error: console.error
    });
  }
  //Crear Vuelo
  createFlight() {
    const newFlight: Partial<Flight> = {
      price: 200,
      departure: '2024-07-01T10:00:00Z',
      destination: 'fl New York created',
      origin: 'Los Angeles International Airport (LAX) created',
      flightNumber: 123445632823
    };

    this.apiService.crearflight(newFlight).subscribe({
      next: (data) => {
        console.log('Flight created:', data);
        this.loadFlights();
      },
      error: (error) => console.error('Error creating flight:', error)
    });

  }

  //Actualizar Vuelo
  updateFlight(id: string) {
    const updatedFlight: Partial<Flight> = {
      origin: 'fl -Updated',
      destination: 'Ecuador -Updated',
      price: 25000,
      departure: '2024-08-01T10:00:00Z',
      flightNumber: 987654321
    };

    this.apiService.updateFlight(id, updatedFlight).subscribe({
      next: (data) => {
        console.log('Flight updated:', data);
        this.loadFlights();
      },
      error: (error) => console.error('Error updating flight:', error)
    });
  }

  //Eliminar Vuelo
  deleteFlight(id: string) {
    this.apiService.deleteFlight(id).subscribe({
      next: () => {
        console.log('Flight deleted');
        this.loadFlights();
      },
      error: (error) => console.error('Error deleting flight:', error)
    });
  }
}
