import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {LoginComponent} from './pages/login/login.component';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {JwtInterceptor} from './helpers/jwt.interceptor';
import {ErrorInterceptor} from './helpers/error.interceptor';
import {HomeComponent} from './pages/home/home.component';
import {RegistrationComponent} from './pages/registration/registration.component';
import {NbButtonModule, NbCardModule, NbDatepickerModule, NbIconModule} from '@nebular/theme';
import {AccountsComponent} from './pages/accounts/accounts.component';
import {PopoverModule} from 'ngx-smart-popover';
import {ErrorComponent} from './pages/error/error.component';
import {MyProfileComponent} from './pages/my-profile/my-profile.component';
import {NoopAnimationsModule} from '@angular/platform-browser/animations';
import {MatButtonModule} from '@angular/material/button';
import {MatDialogModule} from '@angular/material/dialog';
import {PopupComponent} from './shared/popup/popup.component';
import {NewPasswordComponent} from './pages/my-profile/new-password/new-password.component';
import {NewAccountComponent} from './pages/accounts/new-account/new-account.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    RegistrationComponent,
    AccountsComponent,
    ErrorComponent,
    MyProfileComponent,
    PopupComponent,
    NewPasswordComponent,
    NewAccountComponent,
  ],
  entryComponents: [PopupComponent,
    NewPasswordComponent,
    NewAccountComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NbCardModule,
    NbDatepickerModule.forRoot(),
    PopoverModule,
    NbIconModule,
    NbButtonModule,
    NoopAnimationsModule,
    MatButtonModule,
    MatDialogModule,
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
