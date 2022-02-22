//1. Task Module
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/modules/shared/shared.module';
import { RouterModule } from "@angular/router";
import { ListTaskComponent } from './list-task/list-task.component';
import { AddTaskComponent } from './add-task/add-task.component';
import { UpdateDeleteTaskComponent } from './update-delete-task/update-delete-task.component';

// 4. Routes
const ROUTES = [
  { path: '', component: ListTaskComponent},
  { path: 'add', component: AddTaskComponent},
  { path: 'update-delete/:id', component: UpdateDeleteTaskComponent}
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
    ReactiveFormsModule,
    SharedModule
  ]
})
export class TaskModule { }
