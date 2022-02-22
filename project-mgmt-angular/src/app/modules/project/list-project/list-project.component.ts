import { Component, OnInit } from '@angular/core';
import { ProjectService } from '../shared-project/services/project.service';

@Component({
  selector: 'app-list-project',
  templateUrl: './list-project.component.html',
  styleUrls: ['./list-project.component.css']
})

export class ListProjectComponent implements OnInit {
  public projects : any[] = [];

  // Sprint 5 -- inject project service
  constructor(private _projectService: ProjectService) {
  }

  // Sprint 5 -- 3) Bind to project data on server
  // invoke getall project api on init : subscribe to project data to retrieve and display projects list
  ngOnInit(): void {
    this._projectService.getAllProjects().subscribe(data => this.projects = data)
  }

}
