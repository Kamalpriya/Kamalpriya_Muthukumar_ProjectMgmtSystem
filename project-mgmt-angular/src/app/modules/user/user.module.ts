//1. User Module
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/modules/shared/shared.module';
import { RouterModule } from "@angular/router";
import { ListComponent } from './list-user/list-user.component';
import { AddUserComponent } from './add-user/add-user.component';
import { UpdateDeleteUserComponent } from './update-delete-user/update-delete-user.component';

// 4. Routes
const ROUTES = [
  { path: '', component: ListComponent},
  { path: 'add', component: AddUserComponent},
  { path: 'update-delete/:id', component: UpdateDeleteUserComponent}
];

@NgModule({
  declarations: [
    ListComponent,
    AddUserComponent,
    UpdateDeleteUserComponent,
  ],
  imports: [
    RouterModule.forChild(ROUTES),
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    SharedModule
  ]
})
export class UserModule { }
