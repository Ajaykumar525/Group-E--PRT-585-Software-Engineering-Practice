import { Component, OnInit } from '@angular/core';
import { ApiService } from 'app/service/api.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
userList;
id;
name;
contact;
email;
address;

  constructor(private apiService : ApiService) { }

  ngOnInit() {
    this.apiService.getAllUsers().subscribe((response: any)=>
    {
      this.userList = response.result_set;
      console.log(this.userList);
    }
    );
  }

  deleteUser(Id): void {
    this.apiService.deleteUser(Id)
      .subscribe(
        response => {
          console.log(response);
        }
        );
        window.location.reload();
  }

  createUser(data): void {
    this.name = data.name;
    this.contact = data.contact;
    this.email = data.email;
    this.address = data.address;
    this.apiService.createUser(this.name, this.contact,this.email,this.address)
      .subscribe(
        response => {
          console.log(response);
        }
        );
        window.location.reload();
  }

  updateUser(data): void {
    this.id = data.id;
    this.name = data.name;
    this.contact = data.contact;
    this.email = data.email;
    this.address = data.address;
    this.apiService.updateUser(this.id,this.name, this.contact,this.email,this.address)
      .subscribe(
        response => {
          console.log(response);
        }
        );
        window.location.reload();
  }
}
