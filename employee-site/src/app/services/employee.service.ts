import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs/internal/Observable';
import { Employee } from '../models/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private url = "Employee";

  constructor(private http: HttpClient) { }

  public getEmployees() : Observable<Employee[]>{

    return this.http.get<Employee[]>('https://localhost:7067/api/Employee');
    // Was '${environment.apiUrl}/${this.url}' but gave error
  }

  public updateEmployee(employee: Employee) : Observable<Employee[]>{

    return this.http.put<Employee[]>('https://localhost:7067/api/Employee', employee);
    // Was '${environment.apiUrl}/${this.url}' but gave error
  }

  public createEmployee(employee: Employee) : Observable<Employee[]>{

    return this.http.post<Employee[]>('https://localhost:7067/api/Employee', employee);
    // Was '${environment.apiUrl}/${this.url}' but gave error
  }
}
