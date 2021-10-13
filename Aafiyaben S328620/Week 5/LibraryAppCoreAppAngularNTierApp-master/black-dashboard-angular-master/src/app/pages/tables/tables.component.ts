import { ApiService } from '../../api.service';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-tables',
  templateUrl: './tables.component.html',
  
})
export class TableListComponent implements OnInit {
  contracter;
  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.apiService.getAllTeachers().subscribe((response: any)=>
    {
      this.contracter = response.result_set;
      console.log(this.contracter);
    }
    );
  }

  deleteTeacher(Id): void {
    this.apiService.deleteTeacher(Id)
      .subscribe(
        response => {
          console.log(response);
        }
        );
  }

  createTeacher(name, exp): void {
    this.apiService.createTeacher(name, exp)
      .subscribe(
        response => {
          console.log(response);
        }
        );
  }
}
