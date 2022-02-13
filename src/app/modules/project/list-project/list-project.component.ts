import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-list-project',
  templateUrl: './list-project.component.html',
  styleUrls: ['./list-project.component.css']
})
export class ListProjectComponent implements OnInit {
  ProjectList = [{Id: 1, Name: 'TestProject1', Detail: 'This is a test project', CreatedOn: '10/12/2021'},
  {Id: 2, Name: 'TestProject2', Detail: 'This is a test project', CreatedOn: '10/12/2021'},
  {Id: 3, Name: 'TestProject3', Detail: 'This is a test project', CreatedOn: '10/12/2021'},
  {Id: 4, Name: 'TestProject4', Detail: 'This is a test project', CreatedOn: '10/12/2021'}]
  constructor() { }

  ngOnInit(): void {
  }

}
