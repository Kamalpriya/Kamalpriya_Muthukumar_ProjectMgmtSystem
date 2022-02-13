// 4. Routing
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from 'src/app/components/login/login.component';
import { UserModule } from 'src/app/modules/user/user.module';
import { ProjectModule } from 'src/app/modules/project/project.module';
import { TaskModule } from 'src/app/modules/task/task.module';

//4. Routes defined
const routes: Routes = [
  {
    path: 'users', loadChildren: () => UserModule
  },
  {
    path: 'projects', loadChildren: () => ProjectModule
  },
  {
    path: 'tasks', loadChildren: () => TaskModule
  },
  {
    path: '', component: LoginComponent
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ],
  declarations: [
  ]
})
export class AppRoutingModule { }

export const RoutingModules = [UserModule, ProjectModule, TaskModule]