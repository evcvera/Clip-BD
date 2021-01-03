import {Component, OnInit} from '@angular/core';
import {NewUser} from '../../models/new-user';
import {Router} from '@angular/router';
import {NbDateService} from '@nebular/theme';
import {RegistrationService} from '../../services/registration.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {


  reg = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

  name = '';
  lastName = '';
  cuil: number;
  email = '';
  reEmail = '';
  password = '';
  rePassword = '';
  accountName = '';
  date: any;


  recordarme = false;
  usuario: NewUser = new NewUser();


  max: Date;
  min: Date;

  flagName = 0;
  flagLastName = 0;
  flagPassword = 0;
  flagAccountName = 0;
  flagRePassword = 0;
  /*flagDate = false;*/
  flagDate = true;
  flagCuil = 0;
  flagEmail = 0;
  flagReEmail = 0;

  flagExistEmail = false;

  allIsOk = false;
  registrationSuccess = false;

  newUser = {
    name: '',
    lastName: '',
    cuil: 0,
    email: '',
    password: '',
  };

  constructor(public router: Router,
              protected dateService: NbDateService<Date>,
              private registrationService: RegistrationService) {
  }

  ngOnInit(): void {
    this.min = this.dateService.addYear(this.dateService.today(), -100);
    this.max = this.dateService.addYear(this.dateService.today(), -18);
    this.date = this.max;
  }

  firstName(): void {
    this.usuario.name = this.name;
    if (this.name && this.name.length <= 2 && this.name.length > 0) {
      this.flagName = 1;
    }
    if (this.name.length === 0) {
      this.flagName = 0;
    }
    if (this.name.length > 2) {
      this.flagName = 2;
    }
  }

  userLastName(): void {
    this.usuario.lastName = this.lastName;
    if (this.lastName && this.lastName.length <= 2 && this.lastName.length > 0) {
      this.flagLastName = 1;
    }
    if (this.lastName.length === 0) {
      this.flagLastName = 0;
    }
    if (this.lastName.length > 2) {
      this.flagLastName = 2;
    }
  }

  firstPassword(): void {
    this.usuario.password = this.password;
    if (this.password && this.password.length <= 7 && this.password.length > 0) {
      this.flagPassword = 1;
    }
    if (this.password.length === 0) {
      this.flagPassword = 0;
    }
    if (this.password.length > 7) {
      this.flagPassword = 2;
    }
  }

  secondPassword(): void {
    if (this.rePassword && this.rePassword !== this.password) {
      this.flagRePassword = 1;
    }
    if (this.rePassword.length === 0) {
      this.flagRePassword = 0;
    }
    if (this.rePassword === this.password) {
      this.flagRePassword = 2;
    }
  }

  cuilUser(): void {
    this.usuario.cuil = this.cuil.toString();
    if (this.cuil && this.cuil.toString().length <= 9 && this.cuil.toString().length > 0) {
      this.flagCuil = 1;
    }
    if (this.cuil.toString().length === 0) {
      this.flagCuil = 0;
    }
    if (this.cuil.toString().length > 9) {
      this.flagCuil = 2;
    }
  }

  accountNameMet(): void {
    if (this.accountName && this.accountName.length <= 4 && this.accountName.length > 0) {
      this.flagAccountName = 1;
    }
    if (this.accountName.length === 0) {
      this.flagAccountName = 0;
    }
    if (this.accountName.length > 4) {
      this.flagAccountName = 2;
    }
  }


  userReMail(): void {
    this.flagExistEmail = false;
    if (this.email !== this.reEmail) {
      this.flagReEmail = 1;
    } else {
      this.flagReEmail = 2;
    }
  }


  userMail(): void {
    this.flagExistEmail = false;
    this.usuario.email = this.email;
    this.userReMail();
    if (this.email.length === 0) {
      this.flagEmail = 0;
    }
    if (this.email.length > 0 && this.reg.test(this.email)) {
      this.flagEmail = 2;
    }
    if (this.email.length > 0 && !this.reg.test(this.email)) {
      this.flagEmail = 1;
    }
    /*console.log(!!'evcvera@gmail.com'.match(this.reg));
    console.log('abcdefghi'.match(this.reg));
    console.log(this.reg.test('evcvera@gmail.com'));
    console.log(this.reg.test('evcvera@gmail.com'));*/
  }

  selectDate($event: any): void {
    this.date = $event;
    this.flagDate = true;
  }


  submit(): void {
    this.registrationService.registration(this.usuario).subscribe(
      data => {
        if (data) {
          console.log('Se registro correctamente.');
          this.allIsOk = true;
        } else {
          console.log('El email ya existe.');
          this.flagExistEmail = true;
        }
      },
      error => {
        console.log('Error');
      });

  }

}
