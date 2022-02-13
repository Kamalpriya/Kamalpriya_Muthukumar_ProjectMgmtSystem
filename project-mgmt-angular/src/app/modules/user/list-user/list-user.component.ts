import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-list',
  templateUrl: './list-user.component.html',
  styleUrls: ['./list-user.component.css']
})

export class ListComponent implements OnInit {
  UserList = [{Id: 1, FirstName: 'John', LastName: 'Doe', Email: 'john.doe@test.com'},
  {Id: 2, FirstName: 'John', LastName: 'Skeet', Email: 'john.skeet@test.com'},
  {Id: 3, FirstName: 'Mark', LastName: 'Seeman', Email: 'mark.seeman@test.com'},
  {Id: 4, FirstName: 'Bob', LastName: 'Martin', Email: 'bob.martin@test.com'}]

  constructor() {
  }

  ngOnInit(): void {
  }
}
