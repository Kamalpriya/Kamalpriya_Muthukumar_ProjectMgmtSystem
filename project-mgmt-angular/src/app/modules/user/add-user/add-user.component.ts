import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { UserService } from '../shared-user/services/user.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})

export class AddUserComponent implements OnInit {
  addForm = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    email: new FormControl(''),
    password: new FormControl(''),
  });

  savedNewUser : boolean = false;

  constructor(private _userService: UserService) { }
  
  ngOnInit(): void {
  }

  // Sprint 5 -- invoke create user api on save
  onSave()
  {
    this.savedNewUser = false;
    this._userService.createUser(this.addForm.value).subscribe(data => {});
    this.savedNewUser = true;
  }
}
