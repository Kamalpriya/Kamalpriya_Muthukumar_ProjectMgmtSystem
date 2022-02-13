//1. Project Module
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/modules/shared/shared.module';
import { RouterModule } from "@angular/router";
import { ListProjectComponent } from './list-project/list-project.component';
import { AddProjectComponent } from './add-project/add-project.component';
import { UpdateDeleteProjectComponent } from './update-delete-project/update-delete-project.component';

// 4. Routes
const ROUTES = [
  { path: '', component: ListProjectComponent},
  { path: 'add', component: AddProjectComponent},
  { path: 'update-delete', component: UpdateDeleteProjectComponent},
];

@NgModule({
  declarations: [
    ListProjectComponent,
    AddProjectComponent,
    UpdateDeleteProjectComponent,
  ],
  imports: [
    RouterModule.forChild(ROUTES),
    FormsModule,
    CommonModule,
    SharedModule
  ]
})
export class ProjectModule { }
