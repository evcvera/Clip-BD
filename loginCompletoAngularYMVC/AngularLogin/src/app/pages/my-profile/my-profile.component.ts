import {Component, OnInit} from '@angular/core';
import {AuthenticationService} from '../../services/authentication.service';
import {PopupComponent} from '../../shared/popup/popup.component';
import {MatDialog} from '@angular/material/dialog';
import {NewPasswordComponent} from './new-password/new-password.component';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.scss']
})
export class MyProfileComponent implements OnInit {

  constructor(public dialog: MatDialog,
              public authenticationService: AuthenticationService) {
  }

  ngOnInit(): void {
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(NewPasswordComponent, {data: {title: 'Cambiar contraseña'}});

    dialogRef.afterClosed().subscribe(result => {
      /*console.log(`Dialog result: ${result}`);*/
    });
  }

}
