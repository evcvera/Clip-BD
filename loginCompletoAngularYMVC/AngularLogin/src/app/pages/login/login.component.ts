import {Component, OnInit} from '@angular/core';
import {FormControl, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {AuthenticationService} from 'src/app/services/authentication.service';
import {CoinsService} from '../../services/coins.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  returnUrl: string;
  error = '';
  usernameControl = new FormControl('', Validators.required);
  passwordControl = new FormControl('', Validators.required);

  constructor(
    public router: Router,
    private route: ActivatedRoute,
    private authenticationService: AuthenticationService,
  ) {
  }

  ngOnInit(): void {
    this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/';

  }

  onSubmit(): void {
    this.authenticationService.login(this.usernameControl.value, this.passwordControl.value)
      .subscribe(
        data => {
          if (data !== false) {
            this.router.navigate([this.returnUrl]);
          } else {
            this.error = 'EMAIL Y/O CONTRASEÑA INCORRECTOS.';
          }
        },
        error => {
          this.error = error;
        }
      );
  }
}
