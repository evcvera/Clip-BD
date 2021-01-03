import { Component, OnInit } from '@angular/core';
import { Cliente } from 'src/app/models/cliente';
import { ValuesService } from 'src/app/services/values.service';
import {AuthenticationService} from '../../services/authentication.service';
import {User} from '../../models/user';
import {CoinsService} from '../../services/coins.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  values: Cliente[];
  userLogged: User;

  constructor(private valuesService: ValuesService,
              private authenticationService: AuthenticationService,
              public coinsService: CoinsService) {
    this.userLogged = authenticationService.currentUserSubject.value;
    this.coinsService.traerBtc();
    /*console.log(authenticationService.currentUserSubject.value);*/

  }

  ngOnInit(): void {
    this.valuesService.getAll().subscribe(v => {
      this.values = v;
    });
  }

}
