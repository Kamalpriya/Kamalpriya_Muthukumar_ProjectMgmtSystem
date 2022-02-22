import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { AppRoutingModule, RoutingModules } from './app-routing/app-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { UserService } from './modules/user/shared-user/services/user.service';
import { HttpClientModule } from '@angular/common/http'; // HttpClientModule

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
  ],

  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule, // HttpClientModule
    ReactiveFormsModule,
    RoutingModules
  ],
  providers: [UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
