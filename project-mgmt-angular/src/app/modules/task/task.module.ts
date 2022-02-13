//1. Task Module
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/modules/shared/shared.module';
import { RouterModule } from "@angular/router";
import { ListTaskComponent } from './list-task/list-task.component';
import { AddTaskComponent } from './add-task/add-task.component';
import { UpdateDeleteTaskComponent } from './update-delete-task/update-delete-task.component';

// 4. Routes
const ROUTES = [
  { path: '', component: ListTaskComponent},
  { path: 'add', component: AddTaskComponent},
  { path: 'update-delete', component: UpdateDeleteTaskComponent}
];


@NgModule({
  declarations: [
    ListTaskComponent,
    AddTaskComponent,
    UpdateDeleteTaskComponent
  ],
  imports: [
    RouterModule.forChild(ROUTES),
    FormsModule,
    CommonModule,
    SharedModule
  ]
})
export class TaskModule { }
