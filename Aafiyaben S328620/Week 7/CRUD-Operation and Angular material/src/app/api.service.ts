import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private httpClient: HttpClient) { }

  public getAllContracters(){
    return this.httpClient.get('https://localhost:5001/api/Contracter/GetAllContracters');
  }

  public deleteContracter(Id){
    return this.httpClient.get('https://localhost:5001/api/Contracter/DeleteContracter?Id='+Id);
  }

  public createContracter(name, contact, email){
    return this.httpClient.get('https://localhost:5001/api/Contracter/AddContracter?name='+name+'&contact='+contact+ '&email='+email);
  }

  public updateContracter(id, name, contact, email){
    return this.httpClient.get('https://localhost:5001/api/Contracter/UpdateContracter?id='+id+'&name='+name+'&contact='+contact+ '&email='+email);
  }
}
