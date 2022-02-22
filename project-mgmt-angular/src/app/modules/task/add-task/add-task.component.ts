import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ProjectService } from '../../project/shared-project/services/project.service';
import { UserService } from '../../user/shared-user/services/user.service';
import { TaskService } from '../shared-task/services/task.service';

@Component({
  selector: 'app-add-task',
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.css']
})

export class AddTaskComponent implements OnInit {
  addForm = new FormGroup({
    projectId: new FormControl(''),
    assignedToUserId: new FormControl(''),
    detail: new FormControl('')
  });

  public users : any[] = [];
  public projects : any[] = [];

  savedNewTask : boolean = false;

  constructor(private _taskService: TaskService, private _projectService: ProjectService, private _userService: UserService) { 
  }
  
  ngOnInit(): void {
    this._projectService.getAllProjects().subscribe(data => this.projects = data)
    this._userService.getAllUsers().subscribe(data => this.users = data)
  }

  // Sprint 5 -- invoke create task api on save
  onSave()
  {
    this.savedNewTask = false;
    this._taskService.createTask(this.addForm.value).subscribe(data => {});
    this.savedNewTask = true;
  }

}
