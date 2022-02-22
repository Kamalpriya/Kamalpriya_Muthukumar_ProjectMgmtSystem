import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ProjectService } from '../shared-project/services/project.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-update-delete-project',
  templateUrl: './update-delete-project.component.html',
  styleUrls: ['./update-delete-project.component.css']
})

export class UpdateDeleteProjectComponent implements OnInit {
  updateDeleteForm = new FormGroup({
    name: new FormControl(''),
    detail: new FormControl(''),
  });

  savedProject : boolean = false;
  
  constructor(private _projectService: ProjectService, private router: ActivatedRoute) {}

  ngOnInit(): void {
    // Sprint 5 -- 3) Bind to pre-filled data based on project id, on update-delete form
    this._projectService.getProjectById(this.router.snapshot.params['id']).subscribe((data: any) => {
      this.updateDeleteForm = new FormGroup({
        id: new FormControl(this.router.snapshot.params['id']),
        name: new FormControl(data['name']),
        detail: new FormControl(data['detail']),
      });
    });
  }
  
  // Sprint 5 -- invoke update project api on save
  onSave()
  {
    this.savedProject = false;
    this._projectService.updateProject(this.updateDeleteForm.get('id')!.value, this.updateDeleteForm.value).subscribe(data => {});
    this.savedProject = true;
  }

  // Sprint 5 -- invoke delete project api on delete
  onDelete()
  {
    this.savedProject = false;
    this._projectService.deleteProject(this.updateDeleteForm.get('id')!.value).subscribe(data => {});
    this.savedProject = true;
  }

}
