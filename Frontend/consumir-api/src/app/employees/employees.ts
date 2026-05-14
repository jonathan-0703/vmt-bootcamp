import { Component, inject, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Api } from './service/api';
import { Employee } from './interfaces/employees';



@Component({
  selector: 'app-employees',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './employees.html',
  styleUrl: './employees.scss'
})
export class EmployeesComponent implements OnInit {

  openMenuId: string | null = null;

  toggleMenu(id: string) {
    this.openMenuId = this.openMenuId === id ? null : id;
  }

  closeMenu() {
    this.openMenuId = null;
  }
  isModalOpen = signal(false);
  closeModal() {
    this.isModalOpen.set(false);
  }

  private api = inject(Api);


  employees = signal<Employee[]>([]);
  employee = signal<Employee | null>(null);

  ngOnInit(): void {
    this.loadEmployees();
  }



  loadEmployees() {

    this.api.getEmployees().subscribe({
      next: (res) => this.employees.set(res),
      error: console.error
    });
  }

  loadEmployeeById(id: string) {
    this.api.getEmployeeById(id).subscribe({
      next: (res) => {
        this.employee.set(res);
        this.isModalOpen.set(true);
      },
      error: console.error
    });
  }
  createEmployee() {
    const newEmployee: Partial<Employee> = {
      id: '',
      name: 'Nuevo Usuario',
      email: 'nuevo@email.com',
      phone: '000-000-000',
      position: 'Developer',
      department: 'IT',
      salary: 1000,
      avatar: 'https://i.pravatar.cc/150?img=3',
    };

    this.api.crearEmeployee(newEmployee).subscribe({
      next: () => {
        this.loadEmployees();
      },
      error: console.error
    });
  }

  updateEmployee(empleado: Employee) {

    const updatedEmployee: Partial<Employee> = {
      name: "Carlos Mendez Edited",
      email: "carlos@gmail.com",
      phone: '000-000-000',
      position: 'Developer',
      department: 'IT',
      salary: 1000,
      avatar: 'https://i.pravatar.cc/150?img=9',
    };

    this.api.updateEmployee(empleado.id, updatedEmployee).subscribe({
      next: () => {
        this.employees.update(list =>
          list.map(emp =>
            emp.id === empleado.id
              ? { ...emp, ...updatedEmployee }
              : emp
          )
        );
      },
      error: () => console.error("Error al editar empleado")
    });
  }

  deleteEmployee(empleado: Employee) {

    if (!confirm(`¿Eliminar a ${empleado.name}?`)) return;

    this.api.deleteEmployee(empleado.id).subscribe({
      next: () => {
        this.employees.update(list =>
          list.filter(emp => emp.id !== empleado.id)
        );
      },
      error: () => console.error("Error al eliminar empleado")
    });
  }
}