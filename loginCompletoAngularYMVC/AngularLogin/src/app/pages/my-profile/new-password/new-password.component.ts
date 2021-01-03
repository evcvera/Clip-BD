import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import {EditUserService} from '../../../services/edit-user.service';
import {ChangeUserPassword} from '../../../models/User/change-user-password';
import {AuthenticationService} from '../../../services/authentication.service';

@Component({
  selector: 'app-new-password',
  templateUrl: './new-password.component.html',
  styleUrls: ['./new-password.component.scss']
})
export class NewPasswordComponent implements OnInit {

  userData: ChangeUserPassword = new ChangeUserPassword();
  title: string;
  newRePassword: string;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
              public editUser: EditUserService,
              private authenticationService: AuthenticationService) {
    this.title = this.data.name;
    this.userData.email = authenticationService.currentUserSubject.value.loginUser.Email;
  }

  ngOnInit(): void {
  }

  editPassword(): void {
    console.log();
    console.log(this.userData);
    /*this.userData.email = email;
    this.userData.password = password;
    this.userData.newPassword = newPassword;*/
    this.editUser.changePassword(this.userData).subscribe(
      data => {
        if (data) {
          console.log(data);
        } else {
          console.log(data);
        }
      },
      error => {
        console.log('Error');
      });
  }

  onSubmit(): any {
    console.log('hola');
  }
}
