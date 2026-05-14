import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Flights } from "./flights/flights";
import { Passengers } from "./passengers/passengers";

@Component({
  selector: 'app-root',
  imports: [Flights, Passengers],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('practica2');
}
