import {
  Component,
  Input,
  Output,
  EventEmitter,
  inject,
  viewChild,
  TemplateRef
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
import { MatDialog, MatDialogModule } from '@angular/material/dialog';

@Component({
  selector: 'app-custom-card',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatDialogModule
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

  private dialog = inject(MatDialog);
  deleteDialogTemplate = viewChild.required<TemplateRef<unknown>>('deleteDialogTemplate');

  showDetails() {

    this.details.emit(this.id);

  }

  editCard() {

    this.edit.emit(this.id);

  }

  deleteCard() {
    this.dialog.open(this.deleteDialogTemplate(), {
      width: '400px',
      panelClass: 'custom-dialog-container',
      disableClose: true
    });
  }

  confirmDelete() {
    this.delete.emit(this.id);
    this.dialog.closeAll();
  }

  cancelDelete() {
    this.dialog.closeAll();
  }
}
