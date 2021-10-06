import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {
  userList: any;
  user_Firstname: any;
  user_Lastname: any;
  user_Email: any;
  user_id: any;

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.apiService.getAllUsers().subscribe((response: any)=>
    {
      this.userList = response.result_set;
      console.log(this.userList);
    }
    );
  }
  createUser(data:any): void {
    this.user_Firstname = data.user_Firstname;
    this.user_Lastname = data.user_Lastname;
    this.user_Email = data.user_Email;
    this.apiService.createUser(this.user_Firstname, this.user_Lastname, this.user_Email)
      .subscribe(
        response => {
          console.log(response);
        }
        );
        window.location.reload();
  }
  updateUser(data: any): void {
    this.user_id = data.user_id;
    this.user_Firstname = data.user_Firstname;
    this.user_Lastname = data.user_Lastname;
    this.user_Email = data.user_Email;
    this.apiService.updateUser(this.user_id, this.user_Firstname, this.user_Lastname, this.user_Email)
      .subscribe(
        response => {
          console.log(response);
        }
        );
        window.location.reload();
  }
  deleteUser(Id: any): void {
    this.apiService.deleteUser(Id)
      .subscribe(
        response => {
          console.log(response);
        }
        );
        window.location.reload();
  }
}
