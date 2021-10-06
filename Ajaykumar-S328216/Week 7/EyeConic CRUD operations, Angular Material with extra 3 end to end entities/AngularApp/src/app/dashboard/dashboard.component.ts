import { Component, OnInit } from '@angular/core';
import { ApiService } from 'app/service/api.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  productList;
  name;
  price;
  quantity;
  public listItems: Array<string> = [
    'Classic Eyeglasses',
    'Digital UV Protection',
    'Matte Black',
    'Polarized round metal',
    'Rayban Polarized Black',
    'Women rounded red'
];

  constructor( private apiService: ApiService ) { }
 
  ngOnInit() {
    this.apiService.getAllProducts().subscribe((response: any)=>
    {
      this.productList = response.result_set;
      console.log(this.productList);
    }
    );
  }

  createProduct(data): void {
    this.name = data.name;
    this.price = data.price;
    this.quantity = data.quantity;
    this.apiService.createProduct(this.name, this.price, this.quantity)
      .subscribe(
        response => {
          console.log(response);
        }
        );
        window.location.reload();
  }
}
