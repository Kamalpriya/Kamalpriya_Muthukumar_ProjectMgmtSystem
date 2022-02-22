import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { UserService } from '../shared-user/services/user.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-update-delete-user',
  templateUrl: './update-delete-user.component.html',
  styleUrls: ['./update-delete-user.component.css']
})

export class UpdateDeleteUserComponent implements OnInit {
  updateDeleteForm = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    email: new FormControl(''),
    password: new FormControl(''),
  });

  savedUser : boolean = false;

  constructor(private _userService: UserService, private router: ActivatedRoute) {}

  ngOnInit(): void {
    // Sprint 5 -- 3) Bind to pre-filled data based on user id, on update-delete form
    this._userService.getUserById(this.router.snapshot.params['id']).subscribe((data: any) => {
      this.updateDeleteForm = new FormGroup({
        id: new FormControl(this.router.snapshot.params['id']),
        firstName: new FormControl(data['firstName']),
        lastName: new FormControl(data['lastName']),
        email: new FormControl(data['email']),
        password: new FormControl(data['password']),
      });
    });
  }
  
  // Sprint 5 -- invoke update user api on save
  onSave()
  {
    this.savedUser = false;
    this._userService.updateUser(this.updateDeleteForm.get('id')!.value, this.updateDeleteForm.value).subscribe(data => {});
    this.savedUser = true;
  }

  // Sprint 5 -- invoke delete user api on delete
  onDelete()
  {
    this.savedUser = false;
    this._userService.deleteUser(this.updateDeleteForm.get('id')!.value).subscribe(data => {});
    this.savedUser = true;
  }

}
