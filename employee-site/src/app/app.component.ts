import { Component } from '@angular/core';
import { Employee } from './models/employee';
import { EmployeeService } from './services/employee.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'employee-site';

  employees: Employee[] = [];

  employeeToEdit?: Employee;

  constructor(private employeeService: EmployeeService){}

  ngOnInit() : void {
    this.employeeService
      .getEmployees()
      .subscribe((result: Employee[]) => (this.employees = result));
  }

  updateEmployeeList(employees: Employee[]){
    this.employees = employees;
  }

  initNewEmployee(){
    this.employeeToEdit = new Employee();
  }

  editEmployee(empoloyee: Employee){
    this.employeeToEdit = empoloyee;
  }
}
