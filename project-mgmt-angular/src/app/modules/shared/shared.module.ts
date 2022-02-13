//1. Shared Module - for header and sidebar components
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SidebarComponent } from './sidebar/sidebar.component';
import { HeaderComponent } from './header/header.component';
import { RouterModule } from "@angular/router";

@NgModule({
  declarations: [
    HeaderComponent,
    SidebarComponent
  ],
  imports: [
    RouterModule,
    CommonModule
  ],
  exports: [HeaderComponent, SidebarComponent] 
})
export class SharedModule { }
