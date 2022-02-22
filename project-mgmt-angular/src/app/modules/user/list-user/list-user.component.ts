import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared-user/services/user.service';

@Component({
  selector: 'app-list',
  templateUrl: './list-user.component.html',
  styleUrls: ['./list-user.component.css']
})

export class ListComponent implements OnInit {
  
  public users : any[] = [];

  // Sprint 5 -- inject user service
  constructor(private _userService: UserService) {
  }

  // Sprint 5 -- 3) Bind to user data on server
  // invoke getall user api on init : subscribe to user data to retrieve and display users list
  ngOnInit(): void {
    this._userService.getAllUsers().subscribe(data => this.users = data)
  }

}