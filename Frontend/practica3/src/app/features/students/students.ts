import { Component, inject, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DynamicFormModal } from '../../shared/components/dynamic-form-modal/dynamic-form-modal';

import { Student } from './interfaces/students';
import { Api } from './service/api';

import { CustomCard } from '../../shared/components/custom-card/custom-card';
import { DynamicField } from '../../shared/components/dynamic-form-modal/interfaces/dynamic';
import { MatButtonModule } from '@angular/material/button';
import { MatIcon } from "@angular/material/icon";

@Component({
  selector: 'app-students',
  standalone: true,
  imports: [
    CommonModule,
    CustomCard,
    DynamicFormModal,
    MatButtonModule,
    MatIcon
  ],
  templateUrl: './students.html',
  styleUrl: './students.scss',
})
export class Students implements OnInit {


  studentFields: DynamicField[] = [

    {
      key: 'name',
      label: 'Name',
      type: 'text',
      required: true
    },

    {
      key: 'email',
      label: 'Email',
      type: 'email',
      required: true
    }
  ];

  formMode =
    signal<'create' | 'edit'>(
      'create'
    );
  isFormOpen = signal(false);
  selectedStudent = signal<Student | null>(null);


  isModalOpen = signal(false);
  openMenuId: string | null = null;

  private apiService = inject(Api);

  students = signal<Student[]>([]);
  studentDetails = signal<Student | null>(null);

  ngOnInit() {
    this.loadStudents();
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

    this.selectedStudent.set(null);

    this.isFormOpen.set(true);

  }

  openEditModal(student: Student) {

    this.formMode.set('edit');

    this.selectedStudent.set(student);

    this.isFormOpen.set(true);

  }

  closeFormModal() {

    this.isFormOpen.set(false);

  }

  loadStudents() {
    this.apiService.getStudents().subscribe({
      next: (data) => this.students.set(data),
      error: (error) => console.error(error)
    });
  }

  loadStudentDetails(id: string) {
    this.apiService.getStudentById(id).subscribe({
      next: (res) => {
        this.studentDetails.set(res);
        this.isModalOpen.set(true);
      },
      error: console.error
    });
  }

  saveStudent(studentData: Partial<Student>) {

    const currentStudent =
      this.selectedStudent();

    if (currentStudent) {

      this.apiService
        .updateStudent(
          currentStudent.id,
          studentData
        )
        .subscribe({

          next: () => {

            this.loadStudents();

            this.closeFormModal();

          },

          error: console.error

        });

      return;
    }
    this.apiService
      .createStudent(studentData)
      .subscribe({

        next: () => {

          this.loadStudents();

          this.closeFormModal();

        },

        error: console.error

      });

  }

  deleteStudent(id: string) {
    this.apiService.deleteStudent(id).subscribe({
      next: () => {
        console.log('Student deleted');
        this.loadStudents();
      },
      error: (error) => console.error('Error deleting student:', error)
    });
  }

}
