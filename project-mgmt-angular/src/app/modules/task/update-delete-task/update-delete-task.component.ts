import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-update-delete-task',
  templateUrl: './update-delete-task.component.html',
  styleUrls: ['./update-delete-task.component.css']
})
export class UpdateDeleteTaskComponent implements OnInit {
  ProjectList = [{Id: 1, Name: 'TestProject1', Detail: 'This is a test project', CreatedOn: '10/12/2021'},
  {Id: 2, Name: 'TestProject2', Detail: 'This is a test project', CreatedOn: '10/12/2021'},
  {Id: 3, Name: 'TestProject3', Detail: 'This is a test project', CreatedOn: '10/12/2021'},
  {Id: 4, Name: 'TestProject4', Detail: 'This is a test project', CreatedOn: '10/12/2021'}]

  UserList = [{Id: 1, FirstName: 'John', LastName: 'Doe', Email: 'john.doe@test.com'},
  {Id: 2, FirstName: 'John', LastName: 'Skeet', Email: 'john.skeet@test.com'},
  {Id: 3, FirstName: 'Mark', LastName: 'Seeman', Email: 'mark.seeman@test.com'},
  {Id: 4, FirstName: 'Bob', LastName: 'Martin', Email: 'bob.martin@test.com'}]
  constructor() { }

  ngOnInit(): void {
  }

}
