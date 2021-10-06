import { Http } from '@angular/http';
import { Injectable } from '@angular/core';


@Injectable()
export class ApiService {

  constructor(private http: Http) { }

  public getAllContracter(){
    return this.http.get('https://localhost:5001/api/Contracter/GetAllContracter')

  }

}

