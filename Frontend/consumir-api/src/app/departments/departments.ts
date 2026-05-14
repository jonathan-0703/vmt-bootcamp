import { Component, inject, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Department } from './interfaces/departments';
import { Api } from './service/api';




@Component({
  selector: 'app-departments',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './departments.html',
  styleUrl: './departments.scss'
})
export class DepartmentsComponent implements OnInit {

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

  private api = inject(Api);

  departments = signal<Department[]>([]);
  department = signal<Department | null>(null);

  ngOnInit(): void {
    this.loadDepartments();
  }

  loadDepartments() {
    this.api.getdepartments().subscribe({
      next: (res) => this.departments.set(res),
      error: console.error
    });
  }

  loadDepartmentById(id: string) {
    this.api.getDepartmentById(id).subscribe({
      next: (res) => {
        this.department.set(res);
        this.isModalOpen.set(true);
      },
      error: console.error
    });
  }

  createDepartment() {
    const newDepartment: Partial<Department> = {
      id: '',
      name: 'Devops',
      description: 'Nube'
    };

    this.api.crearDepartment(newDepartment).subscribe({
      next: () => this.loadDepartments(),
      error: console.error
    });
  }

  updateDepartment(department: Department) {

    const updatedDepartment: Partial<Department> = {
      name: "Departamento Editado",
      description: "Descripción actualizada",
      managerName: "Nuevo Manager actualizado"
    };

    this.api.updateDepartment(department.id, updatedDepartment).subscribe({
      next: () => {
        this.departments.update(list =>
          list.map(dep =>
            dep.id === department.id
              ? { ...dep, ...updatedDepartment }
              : dep
          )
        );
      },
      error: () => console.error("Error al editar departamento")
    });
  }

  deleteDepartment(department: Department) {

    if (!confirm(`¿Eliminar el departamento ${department.name}?`)) return;

    this.api.deleteDepartment(department.id).subscribe({
      next: () => {
        this.departments.update(list =>
          list.filter(dep => dep.id !== department.id)
        );
      },
      error: () => console.error("Error al eliminar departamento")
    });
  }
}