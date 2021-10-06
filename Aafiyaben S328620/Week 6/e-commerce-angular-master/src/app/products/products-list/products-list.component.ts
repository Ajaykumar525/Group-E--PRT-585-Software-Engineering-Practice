import { Http } from '@angular/http';
import { ApiService } from './../../api.service';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-products-list',
  templateUrl: './products/products-list/products-list.component',
  
})
export class ProductListComponent implements OnInit {
  contracterList;
  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.apiService.getAllContracter().subscribe((response: any)=>
    {
      this.contracterList = response.result_set;
      console.log(this.contracterList);
    }
    );
  }

  deleteTeacher(Id): void {
    this.apiService.deleteContracter(Id)
      .subscribe(
        response => {
          console.log(response);
        }
        );
  }

  createTeacher(name, exp): void {
    this.apiService.createContracter(name, exp)
      .subscribe(
        response => {
          console.log(response);
        }
        );
  }
}
