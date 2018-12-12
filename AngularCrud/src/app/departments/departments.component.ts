import { Component, OnInit } from '@angular/core';
import { department } from './department';
import { DepartmentService } from '../department.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-departments',
  templateUrl: './departments.component.html',
  styleUrls: ['./departments.component.css']
})
export class DepartmentsComponent implements OnInit {


  constructor(private departmentService:DepartmentService) { }
  DepartmentId:number;
  DepartmentName:string;
  DepartmentDescription:string;
  departments:Observable<department[]>


  ngOnInit() {
    this.getDepartment();

  }
  getDepartment(){
    // console.log("DepartmentName is :"+ this.DepartmentName + "and Department Description : "  +this.DepartmentDescription )
     this.departments=this.departmentService.getDepartmentDetails()
 console.log(this.departments);
  }
 

}
