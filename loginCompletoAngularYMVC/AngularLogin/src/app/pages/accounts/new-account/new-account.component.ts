import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import {EditUserService} from '../../../services/edit-user.service';
import {AuthenticationService} from '../../../services/authentication.service';
import {NewAccount} from '../../../models/WalletAccount/new-account';
import {WalletAccountService} from '../../../services/wallet-account.service';

@Component({
  selector: 'app-new-account',
  templateUrl: './new-account.component.html',
  styleUrls: ['./new-account.component.scss']
})

export class NewAccountComponent implements OnInit {

  newAccount: NewAccount = new NewAccount();

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
              public editUser: EditUserService,
              private authenticationService: AuthenticationService,
              public walletAccountService: WalletAccountService) { }

  ngOnInit(): void {
    this.newAccount.Balance = 100000;
    this.newAccount.Email = this.authenticationService.currentUserValue.loginUser.Email;
  }

  sendData(): void {
    this.walletAccountService.newWalletAccount(this.newAccount).subscribe(
      data => {
        if (data) {
          console.log('Es true');
        } else {
          console.log('El false');
        }
      },
      error => {
        console.log('Error');
      });
  }
}
