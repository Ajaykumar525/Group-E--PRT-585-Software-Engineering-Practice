import { ApiService } from './../../api.service';
import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';
@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {
  contracterList;
  constructor(private ApiService: ApiService)  { }

  ngOnInit(): void {
    this.ApiService.getAllContracter().subscribe((Response: any)=>
    {
      this.contracterList = Response.result_set;
      console.log(this.contracterList);
    }
    );
  }

}
