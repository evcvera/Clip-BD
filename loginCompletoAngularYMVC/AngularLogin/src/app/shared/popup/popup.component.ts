import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import {EditUserService} from '../../services/edit-user.service';

@Component({
  selector: 'app-popup',
  templateUrl: './popup.component.html',
  styleUrls: ['./popup.component.scss']
})
export class PopupComponent implements OnInit {

  email = 'asdasd';
  password = '';
  newPassword = '';

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
              public editUser: EditUserService) {
  }

  ngOnInit(): void {
  }

/*  editPassword(): void {
    console.log(this.email);
    const password = 'adsdas';
    this.editUser.changePassword(this.email, password).subscribe(
      data => {
        if (data) {
          console.log(data);
        } else {
          console.log('El email ya existe.');
        }
      },
      error => {
        console.log('Error');
      });
  }*/
}
