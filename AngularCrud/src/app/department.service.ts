
import { Observable} from 'rxjs';

import { department } from './departments/department';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService  {

 
  constructor(private http:HttpClient) { }
  private _url="https://localhost:5001/api/Departments";
 
  
  getDepartmentDetails():Observable<department[]>
  {
    return this.getDepartment();
  }
  getDepartment(): Observable<department[]> {
      return this.http.get<department[]>(this._url);
  }
}
