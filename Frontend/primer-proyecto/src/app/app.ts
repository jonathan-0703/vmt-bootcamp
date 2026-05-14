import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponente } from "./header-componente/header-componente";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, HeaderComponente],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('primer-proyecto');
}
