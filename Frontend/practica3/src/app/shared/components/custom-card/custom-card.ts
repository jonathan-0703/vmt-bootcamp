import {
  Component,
  Input,
  Output,
  EventEmitter
} from '@angular/core';

import { CommonModule } from '@angular/common';

import {
  MatCardModule
} from '@angular/material/card';

import {
  MatButtonModule
} from '@angular/material/button';

import {
  MatIconModule
} from '@angular/material/icon';

@Component({
  selector: 'app-custom-card',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule
  ],
  templateUrl: './custom-card.html',
  styleUrl: './custom-card.scss',
})
export class CustomCard {

  @Input() id = '';

  @Input() image = '';

  @Input() title = '';

  @Input() subtitle = '';


  @Output()
  details =
    new EventEmitter<string>();

  @Output()
  edit =
    new EventEmitter<string>();

  @Output()
  delete =
    new EventEmitter<string>();


  showDetails() {

    this.details.emit(this.id);

  }

  editCard() {

    this.edit.emit(this.id);

  }

  deleteCard() {

    this.delete.emit(this.id);

  }

}