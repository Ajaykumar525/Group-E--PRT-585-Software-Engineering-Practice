import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';


@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.scss']
})
export class CategoryListComponent implements OnInit {
  categoryList: any;
  name: any;
  category_id: any;
  category_gender: any;

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.apiService.getAllCategories().subscribe((response: any)=>
    {
      this.categoryList = response.result_set;
      console.log(this.categoryList);
    }
    );
  }
  createCategory(data:any): void {
    this.name = data.name;
    this.category_gender = data.category_gender;
    this.apiService.createCategory(this.name, this.category_gender)
      .subscribe(
        response => {
          console.log(response);
        }
        );
        window.location.reload();
  }
  deleteCategory(Id: any): void {
    this.apiService.deleteCategory(Id)
      .subscribe(
        response => {
          console.log(response);
        }
        );
        window.location.reload();
  }
  updateCategory(data: any): void {
    this.category_id = data.category_id;
    this.name = data.name;
    this.category_gender = data.category_gender;
    this.apiService.updateCategory(this.category_id, this.name, this.category_gender)
      .subscribe(
        response => {
          console.log(response);
        }
        );
        window.location.reload();
  }
}
