import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private httpClient: HttpClient) { }

  public getAllCustomers(){
    return this.httpClient.get('https://localhost:5001/api/Customer/GetAllCustomers');
  }
  public deleteCustomer(Id: any){
    return this.httpClient.get('https://localhost:5001/api/Customer/DeleteCustomer?Id='+Id);
  }
  public createCustomer(name: string, surname : string, email: string, contact : string){
    return this.httpClient.get('https://localhost:5001/api/Customer/AddCustomer?customer_Name='+name+'&Customer_Surname='+surname+'&contact_Email='+email+'&contact_Number='+contact);
  }
  public updateCustomer(Id: any, name:string,surname : string, email: string, contact : string){
      return this.httpClient.get('https://localhost:5001/api/Customer/UpdateCustomer?customerID='+Id+'&customer_Name='+name+'&Customer_Surname='+surname+'&contact_Email='+email+'&contact_Number='+contact);
  
  }
}
