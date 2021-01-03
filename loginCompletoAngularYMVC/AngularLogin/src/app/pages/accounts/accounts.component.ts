import {Component, OnInit} from '@angular/core';
import {MatDialog} from '@angular/material/dialog';
import {AuthenticationService} from '../../services/authentication.service';
import {NewAccountComponent} from './new-account/new-account.component';
import {WalletAccountService} from '../../services/wallet-account.service';
import {NewAccount} from '../../models/WalletAccount/new-account';


@Component({
  selector: 'app-accounts',
  templateUrl: './accounts.component.html',
  styleUrls: ['./accounts.component.scss']
})
export class AccountsComponent implements OnInit {

  constructor(public dialog: MatDialog,
              public authenticationService: AuthenticationService,
              public walletAccountService: WalletAccountService) {
    this.walletAccountService.getWalletAccount();
  }

  ngOnInit(): void {
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(NewAccountComponent, {data: {title: 'Crear nueva cuenta'}});

    dialogRef.afterClosed().subscribe(result => {
      /*console.log(`Dialog result: ${result}`);*/
    });
  }
}
