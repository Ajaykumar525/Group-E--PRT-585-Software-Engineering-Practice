import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private httpClient: HttpClient) { }

  public getAllContracter(){
    return this.httpClient.get('https://localhost:5001/api/Teacher/GetAllContracter');
  }

  public deleteContracter(Id){
    return this.httpClient.get('https://localhost:5001/api/Teacher/DeleteContracter?Id='+Id);
  }

  public createContracter(Name, Exp){
    return this.httpClient.get('https://localhost:5001/api/Contracter/AddContracter?name='+Name+'&experience='+Exp);
  }
}
