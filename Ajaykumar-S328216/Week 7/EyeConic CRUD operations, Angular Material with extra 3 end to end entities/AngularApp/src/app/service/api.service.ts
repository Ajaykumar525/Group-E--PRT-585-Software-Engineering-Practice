import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private httpClient: HttpClient) { }

  public getAllTeachers(){
    return this.httpClient.get('https://localhost:5001/api/Teacher/GetAllTeachers');
  }

  public deleteTeacher(Id){
    return this.httpClient.get('https://localhost:5001/api/Teacher/DeleteTeacher?Id='+Id);
  }

  public createTeacher(Name, Exp){
    return this.httpClient.get('https://localhost:5001/api/Teacher/AddTeacher?name='+Name+'&experience='+Exp);
  }

  public updateTeacher(Id, Name, Exp){
    return this.httpClient.get('https://localhost:5001/api/Teacher/UpdateTeacher?id='+Id+'&name='+Name+'&experience='+Exp);
  }

  public getAllProducts(){
    return this.httpClient.get('https://localhost:5001/api/Product/GetAllProducts');
  }

  public createProduct(Name, Price, Quantity){
    return this.httpClient.get('https://localhost:5001/api/Product/AddProduct?ProductName='+Name+'&price='+Price+'&qty='+Quantity);
  }

  public getAllCategories(){
    return this.httpClient.get('https://localhost:5001/api/Category/GetAllCategories');
  }

  public deleteCategory(Id){
    return this.httpClient.get('https://localhost:5001/api/Category/DeleteCategory?id='+Id);
  }

  public createCategory(Name, Gender){
    return this.httpClient.get('https://localhost:5001/api/Category/AddCategory?name='+Name+'&gender='+Gender);
  }

  public updateCategory(Id, Name, Gender){
    return this.httpClient.get('https://localhost:5001/api/Category/UpdateCategory?id='+Id+'&name='+Name+'&gender='+Gender);
  }

  public getAllUsers(){
    return this.httpClient.get('https://localhost:5001/api/User/GetAllUsers');
  }

  public deleteUser(Id){
    return this.httpClient.get('https://localhost:5001/api/User/DeleteUser?id='+Id);
  }

  public createUser(Name, Contact, Email, Address){
    return this.httpClient.get('https://localhost:5001/api/User/AddUser?name='+Name+'&contact='+Contact+'&email='+Email+'&address='+Address);
  }

  public updateUser(Id, Name, Contact, Email, Address){
    return this.httpClient.get('https://localhost:5001/api/User/UpdateUser?id='+Id+'&name='+Name+'&contact='+Contact+'&email='+Email+'&address='+Address);
  }
}
