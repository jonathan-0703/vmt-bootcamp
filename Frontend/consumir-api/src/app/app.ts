import { Component } from '@angular/core';
import { EmployeesComponent } from './employees/employees';
import { DepartmentsComponent } from './departments/departments';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [EmployeesComponent, DepartmentsComponent],
  templateUrl: './app.html'
})
export class AppComponent { }