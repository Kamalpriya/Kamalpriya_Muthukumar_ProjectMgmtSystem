import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ProjectService } from '../shared-project/services/project.service';

@Component({
  selector: 'app-add-project',
  templateUrl: './add-project.component.html',
  styleUrls: ['./add-project.component.css']
})

export class AddProjectComponent implements OnInit {
  addForm = new FormGroup({
    name: new FormControl(''),
    detail: new FormControl(''),
  });

  savedNewProject : boolean = false;

  constructor(private _projectService: ProjectService) { }
  
  ngOnInit(): void {
  }

  // Sprint 5 -- invoke create project api on save
  onSave()
  {
    this.savedNewProject = false;
    this._projectService.createProject(this.addForm.value).subscribe(data => {});
    this.savedNewProject = true;
  }

}
