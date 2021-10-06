import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {
  productList: any;
  name: any;
  product_Price: any;
  product_Category: any;
  product_id: any;

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.apiService.getAllProducts().subscribe((response: any)=>
    {
      this.productList = response.result_set;
      console.log(this.productList);
    }
    );
  }
  createProduct(data:any): void {
    this.name = data.name;
    this.product_Price = data.product_Price;
    this.product_Category = data.product_Category;
    this.apiService.createProduct(this.name, this.product_Price, this.product_Category)
      .subscribe(
        response => {
          console.log(response);
        }
        );
        window.location.reload();
  }
  updateProduct(data: any): void {
    this.product_id = data.product_id;
    this.name = data.name;
    this.product_Price = data.product_Price;
    this.product_Category = data.product_Category;
    this.apiService.updateProduct(this.product_id, this.name, this.product_Price, this.product_Category)
      .subscribe(
        response => {
          console.log(response);
        }
        );
        window.location.reload();
  }
  deleteProduct(Id: any): void {
    this.apiService.deleteProduct(Id)
      .subscribe(
        response => {
          console.log(response);
        }
        );
        window.location.reload();
  }
}
