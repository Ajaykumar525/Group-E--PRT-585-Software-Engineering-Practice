import { Component, OnInit } from '@angular/core';
import { ApiService } from 'app/service/api.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-table-list',
  templateUrl: './table-list.component.html',
  styleUrls: ['./table-list.component.css']
})
export class TableListComponent implements OnInit {
  categoryList;
  id;
  name;
  gender;
  constructor(private apiService: ApiService, private router: Router) { }

  ngOnInit(): void {
    this.apiService.getAllCategories().subscribe((response: any)=>
    {
      this.categoryList = response.result_set;
      console.log(this.categoryList);
    }
    );
  }

  deleteCategory(Id): void {
    this.apiService.deleteCategory(Id)
      .subscribe(
        response => {
          console.log(response);
        }
        );
        window.location.reload();
  }

  createCategory(data): void {
    this.name = data.name;
    this.gender = data.gender;
    this.apiService.createCategory(this.name, this.gender)
      .subscribe(
        response => {
          console.log(response);
        }
        );
        window.location.reload();
  }

  updateCategory(data): void {
    this.id = data.id;
    this.name = data.name;
    this.gender = data.gender;
    this.apiService.updateCategory(this.id,this.name, this.gender)
      .subscribe(
        response => {
          console.log(response);
        }
        );
        window.location.reload();
  }
}
