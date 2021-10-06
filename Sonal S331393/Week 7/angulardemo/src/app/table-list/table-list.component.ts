import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-table-list',
  templateUrl: './table-list.component.html',
  styleUrls: ['./table-list.component.scss']
})
export class TableListComponent implements OnInit {
  teacherList: any;
  id: any;
  name: any;

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.apiService.getAllTeachers().subscribe((response: any)=>
    {
      this.teacherList = response.result_set;
      console.log(this.teacherList);
    }
    );
  }
  deleteTeacher(Id: any): void {
    this.apiService.deleteTeacher(Id)
      .subscribe(
        response => {
          console.log(response);
        }
        );
        window.location.reload();
  }
  createTeacher(data: { name: any; }): void {
    this.name = data.name;
    this.apiService.createTeacher(this.name)
      .subscribe(
        response => {
          console.log(response);
        }
        );
        window.location.reload();
  }
  updateTeacher(data: any): void {
    this.id = data.teacher_id;
    this.name = data.name;
    this.apiService.updateTeacher(this.id,this.name)
      .subscribe(
        response => {
          console.log(response);
        }
        );
        window.location.reload();
  }
}
