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
  public deleteTeacher(Id: any){
    return this.httpClient.get('https://localhost:5001/api/Teacher/DeleteTeacher?Id='+Id);
  }
  public createTeacher(Name: string){
    return this.httpClient.get('https://localhost:5001/api/Teacher/AddTeacher?name='+Name);
  }
  public updateTeacher(Id: any, Name: string){
    return this.httpClient.get('https://localhost:5001/api/Teacher/UpdateTeacher?id='+Id+'&name='+Name);
  }

  public getAllCategories(){
    return this.httpClient.get('https://localhost:5001/api/Category/GetAllCategories');
  }
  public createCategory(Name: string, category_gender: string){
    return this.httpClient.get('https://localhost:5001/api/Category/AddCategory?name='+Name+'&category_gender='+category_gender);
  }
  public deleteCategory(Id: any){
    return this.httpClient.get('https://localhost:5001/api/Category/DeleteCategory?id='+Id);
  }
  public updateCategory(Id: any, Name: string, category_gender: string){
    return this.httpClient.get('https://localhost:5001/api/Category/UpdateCategory?id='+Id+'&name='+Name+'&Category_gender='+category_gender);
  }

  public getAllProducts(){
    return this.httpClient.get('https://localhost:5001/api/Product/GetAllProducts');
  }
  public createProduct(Name: string, product_Price: string, product_Category: string){
    return this.httpClient.get('https://localhost:5001/api/Product/AddProduct?name='+Name+'&Product_Price='+product_Price+'&Product_Category='+product_Category);
  }
  public updateProduct(Id: any, Name: string, product_Price: string, product_Category: string){
    return this.httpClient.get('https://localhost:5001/api/Product/UpdateProduct?id='+Id+'&name='+Name+'&Product_Price='+product_Price+'&Product_Category='+product_Category);
  }
  public deleteProduct(Id: any){
    return this.httpClient.get('https://localhost:5001/api/Product/DeleteProduct?id='+Id);
  }

  public getAllUsers(){
    return this.httpClient.get('https://localhost:5001/api/User/GetAllUsers');
  }
  public createUser(User_Firstname: string, user_Lastname: string, user_Email: string){
    return this.httpClient.get('https://localhost:5001/api/User/AddUser?User_Firstname='+User_Firstname+'&user_Lastname='+user_Lastname+'&user_Email='+user_Email);
  }
  public updateUser(Id: any, user_Firstname: string, user_Lastname: string, user_Email: string){
    return this.httpClient.get('https://localhost:5001/api/User/UpdateUser?id='+Id+'&User_Firstname='+user_Firstname+'&User_Lastname='+user_Lastname+'&User_Email='+user_Email);
  }
  public deleteUser(Id: any){
    return this.httpClient.get('https://localhost:5001/api/User/DeleteUser?id='+Id);
  }
}
