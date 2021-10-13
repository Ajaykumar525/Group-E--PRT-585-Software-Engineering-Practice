import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private httpClient: HttpClient) { }

  public getAllTeachers(){
    return this.httpClient.get('https://localhost:5001/api/Teacher/GetAllContracter');
  }

  public deleteTeacher(Id){
    return this.httpClient.get('https://localhost:5001/api/Teacher/DeleteContracter?Id='+Id);
  }

  public createTeacher(Name, Exp){
    return this.httpClient.get('https://localhost:5001/api//AddTeacher?name='+Name+'&experience='+Exp);
  }
}
