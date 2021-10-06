import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { Router } from '@angular/router';



@Component({
  selector: 'app-table-list',
  templateUrl: './table-list.component.html',
  styleUrls: ['./table-list.component.scss']
})

  export class TableListComponent implements OnInit {
    customerList: any;
    customerID: any;
    customer_Name: any;
    customer_Surname: any;
    contact_Email: any;
    contact_Number: any;
    constructor(private apiService: ApiService, private router: Router) { }
  
    ngOnInit(): void {
      this.apiService.getAllCustomers().subscribe((response: any)=>
      {
        this.customerList = response.result_set;
        console.log(this.customerList);
      }
      );
    }
  
    deleteCustomer(Id: any): void {
      this.apiService.deleteCustomer(Id)
        .subscribe(
          response => {
            console.log(response);
          }
          );
          window.location.reload();
    }
  
    createCustomer(data:any): void {
      this.customer_Name = data.name;
      this.customer_Surname = data.surname;
      this.contact_Email = data.email;
      this.contact_Number = data.contact;
      this.apiService.createCustomer(this.customer_Name, this.customer_Surname, this.contact_Email, this.contact_Number)
        .subscribe(
          response => {
            console.log(response);
          }
          );
          window.location.reload();
    }
  
    updateCustomer(data:any): void {
      this.customerID = data.customerID;
      this.customer_Name = data.customer_Name;
      this.customer_Surname = data.customer_Surname;
      this.contact_Email = data.contact_Email;
      this.contact_Number = data.contact_Number;
      this.apiService.updateCustomer(this.customerID,this.customer_Name, this.customer_Surname, this.contact_Email, this.contact_Number)
        .subscribe(
          response => {
            console.log(response);
          }
          );
          window.location.reload();
    }
  }
  