import { ApiService } from './../../api.service';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pages-tables-list',
  templateUrl: './tables.component.html',
  
})
export class TablesComponent implements OnInit {
  contracterList;
  id;
  name;
  contact;
  email;
  constructor(private apiService: ApiService, private router: Router) { }

  ngOnInit(): void {
    this.apiService.getAllContracters().subscribe((response: any)=>
    {
      this.contracterList = response.result_set;
      console.log(this.contracterList);
    }
    );
  }

  deleteContracter(Id): void {
    this.apiService.deleteContracter(Id)
      .subscribe(
        response => {
          console.log(response);
        }
        );
        window.location.reload();
  }

  createContracter(Contracter): void {
    this.id = Contracter.contracter_id;
    this.name = Contracter.name;
    this.contact = Contracter.contact;
    this.email = Contracter.email
    this.apiService.createContracter(this.name, this.contact, this.email)
      .subscribe(
        response => {
          console.log(response);
        }
        );
        window.location.reload();
  }

  updateContracter(Contracter): void {
    this.id = Contracter.contracter_id;
    this.name = Contracter.name;
    this.contact = Contracter.contact;
    this.email = Contracter.email
    this.apiService.updateContracter(this.id, this.name, this.contact, this.email)
      .subscribe(
        response => {
          console.log(response);
        }
        );
        window.location.reload();
  }
}
