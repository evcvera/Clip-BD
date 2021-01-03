import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from './pages/home/home.component';
import {LoginComponent} from './pages/login/login.component';
import {AuthGuard} from './helpers/auth.guard';
import {RegistrationComponent} from './pages/registration/registration.component';
import {AccountsComponent} from './pages/accounts/accounts.component';
import {ErrorComponent} from './pages/error/error.component';
import {MyProfileComponent} from './pages/my-profile/my-profile.component';

const routes: Routes = [
  {path: '', component: HomeComponent, canActivate: [AuthGuard]},
  {path: 'accounts', component: AccountsComponent, canActivate: [AuthGuard]},
  {path: 'profile', component: MyProfileComponent, canActivate: [AuthGuard]},
  {path: 'login', component: LoginComponent},
  {path: 'registration', component: RegistrationComponent},
  {path: 'error', component: ErrorComponent},
  {path: '**', redirectTo: 'error'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
