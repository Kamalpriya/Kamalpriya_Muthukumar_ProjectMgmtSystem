import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ProjectService } from '../../project/shared-project/services/project.service';
import { UserService } from '../../user/shared-user/services/user.service';
import { TaskService } from '../shared-task/services/task.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-update-delete-task',
  templateUrl: './update-delete-task.component.html',
  styleUrls: ['./update-delete-task.component.css']
})

export class UpdateDeleteTaskComponent implements OnInit {
  updateDeleteForm = new FormGroup({
    projectId: new FormControl(''),
    assignedToUserId: new FormControl(''),
    status: new FormControl(''),
    detail: new FormControl('')
  });

  public users : any[] = [];
  public projects : any[] = [];

  savedTask : boolean = false;

  constructor(private _taskService: TaskService, private _projectService: ProjectService, private _userService: UserService, private router: ActivatedRoute) { 
  }
  
  ngOnInit(): void {
    // Sprint 5 -- 3) Bind to pre-filled data based on task id, on update-delete form
    this._taskService.getTaskById(this.router.snapshot.params['id']).subscribe((data: any) => {
      this.updateDeleteForm = new FormGroup({
        id: new FormControl(this.router.snapshot.params['id']),
        projectId: new FormControl(data['projectId']),
        assignedToUserId: new FormControl(data['assignedToUserId']),
        status: new FormControl(data['status']),
        detail: new FormControl(data['detail']),
      });
    });
    this._projectService.getAllProjects().subscribe(data => this.projects = data)
    this._userService.getAllUsers().subscribe(data => this.users = data)
  }

  // Sprint 5 -- invoke update task api on save
  onSave()
  {
    this.savedTask = false;
    this._taskService.updateTask(this.updateDeleteForm.get('id')!.value, this.updateDeleteForm.value).subscribe(data => {});
    this.savedTask = true;
  }

  // Sprint 5 -- invoke delete task api on delete
  onDelete()
  {
    this.savedTask = false;
    this._taskService.deleteTask(this.updateDeleteForm.get('id')!.value).subscribe(data => {});
    this.savedTask = true;
  }
}
