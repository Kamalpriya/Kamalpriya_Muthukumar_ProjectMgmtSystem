import { Component, OnInit } from '@angular/core';
import { TaskService } from '../shared-task/services/task.service';

@Component({
  selector: 'app-list-task',
  templateUrl: './list-task.component.html',
  styleUrls: ['./list-task.component.css']
})

export class ListTaskComponent implements OnInit {
  public tasks : any[] = [];

  // Sprint 5 -- inject task service
  constructor(private _taskService: TaskService) {
  }

  // Sprint 5 -- 3) Bind to tasks data on server
  // invoke getall task api on init : subscribe to task data to retrieve and display tasks list
  ngOnInit(): void {
    this._taskService.getAllTasks().subscribe(data => this.tasks = data)
  }

}
