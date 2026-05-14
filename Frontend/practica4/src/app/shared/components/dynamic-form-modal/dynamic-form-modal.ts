import { Component, Input, Output, EventEmitter, inject, OnChanges } from '@angular/core';

import { CommonModule } from '@angular/common';

import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

import { MatDialogModule } from '@angular/material/dialog';

import { MatFormFieldModule } from '@angular/material/form-field';

import { MatInputModule } from '@angular/material/input';

import { MatButtonModule } from '@angular/material/button';
import { DynamicField } from './interfaces/dynamic';

@Component({
  selector: 'app-dynamic-form-modal',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule
  ],
  templateUrl: './dynamic-form-modal.html',
  styleUrl: './dynamic-form-modal.scss',
})
export class DynamicFormModal implements OnChanges {

  private fb = inject(FormBuilder);

  @Input() title = '';

  @Input() fields: DynamicField[] = [];

  @Input() data: any = null;

  @Input() mode:
    'create' | 'edit' = 'create';

  @Output() save =
    new EventEmitter<any>();

  @Output() close =
    new EventEmitter<void>();

  form!: FormGroup;

  ngOnChanges() {
    this.buildForm();
  }

  buildForm() {

    const controls: any = {};

    this.fields.forEach(field => {

      const validators = [];

      if (field.required) {

        validators.push(
          Validators.required
        );

      }

      if (field.type === 'email') {

        validators.push(
          Validators.email
        );

      }

      controls[field.key] = [

        this.data?.[field.key] || '',

        validators

      ];

    });

    this.form = this.fb.group(controls);

  }

  onSubmit() {

    if (this.form.invalid) {

      this.form.markAllAsTouched();

      return;
    }

    this.save.emit(this.form.value);

  }

}