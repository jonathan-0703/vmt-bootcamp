import { Component, inject, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';

import { Course } from './interfaces/courses';
import { Api } from './service/api';

import { CustomCard } from '../../shared/components/custom-card/custom-card';
import { DynamicField } from '../../shared/components/dynamic-form-modal/interfaces/dynamic';
import { DynamicFormModal } from '../../shared/components/dynamic-form-modal/dynamic-form-modal';
import { MatButtonModule } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { Student } from '../students/interfaces/students';

@Component({
  selector: 'app-courses',
  standalone: true,
  imports: [
    CommonModule,
    CustomCard,
    DynamicFormModal,
    MatButtonModule,
    MatIcon
  ],
  templateUrl: './courses.html',
  styleUrl: './courses.scss',
})
export class Courses implements OnInit {

  courseFields: DynamicField[] = [

    {
      key: 'name',
      label: 'Name',
      type: 'text',
      required: true
    },
    {
      key: 'instructor',
      label: 'Instructor',
      type: 'text',
      required: true
    },
    {
      key: 'level',
      label: 'Level',
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

  courses = signal<Course[]>([]);
  courseDetails = signal<Course | null>(null);

  formMode =
    signal<'create' | 'edit'>(
      'create'
    );

  isFormOpen = signal(false);
  selectedCourse = signal<Course | null>(null);

  openCreateModal() {

    this.formMode.set('create');

    this.selectedCourse.set(null);

    this.isFormOpen.set(true);

  }

  openEditModal(course: Course) {

    this.formMode.set('edit');

    this.selectedCourse.set(course);

    this.isFormOpen.set(true);

  }

  closeFormModal() {

    this.isFormOpen.set(false);

  }

  ngOnInit() {
    this.loadCourses();
  }

  closeModal() {
    this.isModalOpen.set(false);
  }

  loadCourses() {
    this.apiService.getCourses().subscribe({
      next: (data) => this.courses.set(data),
      error: (error) => console.error(error)
    });
  }

  loadCourseDetails(id: string) {
    this.apiService.getCourseById(id).subscribe({
      next: (res) => {
        this.courseDetails.set(res);
        this.isModalOpen.set(true);
      },
      error: console.error
    });
  }
  saveCourse(courseData: Partial<Course>) {

    const currentCourse =
      this.selectedCourse();

    if (currentCourse) {

      this.apiService
        .updateCourse(
          currentCourse.id,
          courseData
        )
        .subscribe({

          next: () => {

            this.loadCourses();

            this.closeFormModal();

          },

          error: console.error

        });

      return;
    }
    this.apiService
      .createCourse(courseData)
      .subscribe({

        next: () => {

          this.loadCourses();

          this.closeFormModal();

        },

        error: console.error

      });

  }



  //Eliminar Curso  
  deleteCourse(id: string) {
    this.apiService.deleteCourse(id).subscribe({
      next: () => {
        console.log('Course deleted');
        this.loadCourses();
      },
      error: (error) => console.error('Error deleting course:', error)
    });
  }
}
