import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-list-task',
  templateUrl: './list-task.component.html',
  styleUrls: ['./list-task.component.css']
})
export class ListTaskComponent implements OnInit {
  TaskList = [{Id: 1, Project: 'TestProject1', Details: 'This is a test task', AssignedToUser: 'John Doe', Status: 'New', CreatedOn: '10/12/2021'},
  {Id: 2, Project: 'TestProject1', Details: 'This is a test task', AssignedToUser: 'John Doe', Status: 'QA', CreatedOn: '10/12/2021'},
  {Id: 3, Project: 'TestProject2', Details: 'This is a test task', AssignedToUser: 'Bob Martin', Status: 'New', CreatedOn: '10/12/2021'},
  {Id: 4, Project: 'TestProject3', Details: 'This is a test task', AssignedToUser: 'John Doe', Status: 'InProgress', CreatedOn: '10/12/2021'},
  {Id: 5, Project: 'TestProject1', Details: 'This is a test task', AssignedToUser: 'John Skeet', Status: 'Completed', CreatedOn: '10/12/2021'},
  {Id: 6, Project: 'TestProject4', Details: 'This is a test task', AssignedToUser: 'Mark Seeman', Status: 'InProgress', CreatedOn: '10/12/2021'}]

  constructor() { }

  ngOnInit(): void {
  }

}
